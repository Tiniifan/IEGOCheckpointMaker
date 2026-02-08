using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IEGOCheckpointMaker.Models;
using StudioElevenLib.Level5.Archive.ARC0;
using StudioElevenLib.Level5.Binary;
using StudioElevenLib.Level5.Binary.Collections;
using StudioElevenLib.Level5.Binary.Logic;
using StudioElevenLib.Level5.Image;
using StudioElevenLib.Level5.Text;
using StudioElevenLib.Tools;

namespace IEGOCheckpointMaker
{
    public partial class MainWindow : Form
    {
        private ARC0 IEA_FA;
        private string FileName;

        private string Language;

        private PhaseInfo[] PhaseInfos;
        private string[] PhaseTexts;

        private bool _isSyncingMaps = false;

        private Bitmap MiniMapImage;

        // MMM data structures
        private Dictionary<uint, List<MMMAppear>> MMMData;
        private List<MMMConfig> MMMConfigs;
        private Mapenv CurrentMapenv;
        private MMMAppear _selectedMMMAppear;
        private string CurrentMapId;

        public MainWindow()
        {
            InitializeComponent();
            ResizeAndCenterPictureBox();
            ResizeMapInfoPanels();
        }

        private string GetLanguage()
        {
            if (radioButtonFrench.Checked)
            {
                return "fr";
            }
            else if (radioButtonSpanish.Checked)
            {
                return "es";
            }
            else if (radioButtonItalian.Checked)
            {
                return "it";
            }
            else if (radioButtonDeutsch.Checked)
            {
                return "de";
            }
            else
            {
                return "en";
            }
        }

        private PhaseInfo[] GetPhaseInfos()
        {
            CfgBin<CfgTreeNode> charaBaseFile = new CfgBin<CfgTreeNode>();

            byte[] fileData = IEA_FA.Directory.GetFileFromFullPath("/data/res/system/phase_config.cfg.bin");
            charaBaseFile.Open(fileData);

            return charaBaseFile.Entries.FlattenEntryToClassList<PhaseInfo>("PHASE_INFO").ToArray();
        }

        private string[] GetPhaseTexts(PhaseInfo[] phaseInfos)
        {
            byte[] fileData = IEA_FA.Directory.GetFileFromFullPath(
                "/data/res/text/phase_text_" + Language + ".cfg.bin");

            T2bþ phaseText = new T2bþ(fileData);

            return phaseInfos
                .Select(phaseInfo =>
                    phaseText.Texts.TryGetValue(phaseInfo.PhaseTextId, out var text)
                        ? text.Strings[0].Text
                        : phaseInfo.PhaseString
                )
                .ToArray();
        }

        private KeyValuePair<int, string>[] GetMapIds()
        {
            VirtualDirectory mapFolder = IEA_FA.Directory.GetFolderFromFullPath("/data/map");

            if (mapFolder == null)
                return Array.Empty<KeyValuePair<int, string>>();

            return mapFolder.Folders
                .Select(f =>
                {
                    string fileName = f.Name;
                    int crc32 = unchecked((int)Crc32.Compute(Encoding.UTF8.GetBytes(fileName)));

                    return new KeyValuePair<int, string>(crc32, fileName);
                })
                .ToArray();
        }


        private string[] GetMapTexts(KeyValuePair<int, string>[] maps)
        {
            byte[] fileData = IEA_FA.Directory.GetFileFromFullPath(
                "/data/res/text/system_text_" + Language + ".cfg.bin");

            T2bþ phaseText = new T2bþ(fileData);

            return maps
                .Select(map =>
                    phaseText.Nouns.TryGetValue(map.Key, out var text)
                        ? text.Strings[0].Text
                        : map.Value
                )
                .ToArray();
        }

        private void ResizeMapInfoPanels()
        {
            if (panelMapInfo == null || panelMMMInfo == null || panelMapContainer == null)
                return;

            // Each panel occupies 50% of panelMapInfo width
            int halfWidth = panelMapInfo.Width / 2;

            panelMMMInfo.Width = halfWidth;
            panelMapContainer.Width = halfWidth;
            panelMapContainer.Left = halfWidth;
        }

        private void ResizeAndCenterPictureBox()
        {
            if (pictureBoxMapPreview == null || panelMapContainer == null)
                return;

            int margin = 10;

            // Maximum square size: panel width or height - 2*margin on all sides
            int size = Math.Min(panelMapContainer.Width - 2 * margin, panelMapContainer.Height - 2 * margin);

            // Apply size
            pictureBoxMapPreview.Width = size;
            pictureBoxMapPreview.Height = size;

            // Centre horizontally and vertically with margin on all sides
            pictureBoxMapPreview.Left = margin + (panelMapContainer.Width - 2 * margin - size) / 2;
            pictureBoxMapPreview.Top = margin + (panelMapContainer.Height - 2 * margin - size) / 2;
        }

        /// <summary>
        /// Load mapenv file and extract boundaries
        /// </summary>
        private void LoadMapenvFile(string mapId)
        {
            try
            {
                VirtualDirectory mapFolder = IEA_FA.Directory.GetFolderFromFullPath("/data/map");
                if (mapFolder == null || !mapFolder.IsFolderExists(mapId))
                    return;

                VirtualDirectory selectedMap = mapFolder.GetFolder(mapId);
                string mapenvFile = $"{mapId}_mapenv.bin";

                if (selectedMap != null && selectedMap.Files.ContainsKey(mapenvFile))
                {
                    selectedMap.Files[mapenvFile].Read();
                    byte[] mapenvData = selectedMap.Files[mapenvFile].ByteContent;

                    var ptreeMapenv = new CfgBin<PtreeNode>();
                    ptreeMapenv.Open(mapenvData);

                    PtreeNode ptreeMap = ptreeMapenv.Entries.FindByHeader("MAP_ENV");
                    if (ptreeMap != null)
                    {
                        CurrentMapenv = new Mapenv(ptreeMap);

                        // If no MMModelPos, create a default one
                        if (CurrentMapenv.MMModelPos == null)
                        {
                            CurrentMapenv.MMModelPos = new MMModelPos
                            {
                                MinX = -400,
                                MinY = -340,
                                MaxX = 400,
                                MaxY = 460
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading mapenv file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load MMM file and parse MMM_Config and MMM_APPEAR entries
        /// </summary>
        private void LoadMMMFile(string mapId)
        {
            try
            {
                VirtualDirectory mapFolder = IEA_FA.Directory.GetFolderFromFullPath("/data/map");
                if (mapFolder == null || !mapFolder.IsFolderExists(mapId))
                    return;

                VirtualDirectory selectedMap = mapFolder.GetFolder(mapId);
                string mmmFile = $"{mapId}.mmm.bin";

                if (selectedMap != null && selectedMap.Files.ContainsKey(mmmFile))
                {
                    selectedMap.Files[mmmFile].Read();
                    byte[] mmmData = selectedMap.Files[mmmFile].ByteContent;

                    var cfgBin = new CfgBin<CfgTreeNode>();
                    cfgBin.Open(mmmData);

                    // Parse MMM_Config entries
                    MMMConfigs = cfgBin.Entries.FlattenEntryToClassList<MMMConfig>("MMM_CONFIG").ToList();

                    // Parse MMM_APPEAR entries
                    var mmmAppears = cfgBin.Entries.FlattenEntryToClassList<MMMAppear>("MMM_APPEAR").ToList();

                    // Build dictionary: MMMConfig ID -> List of MMMAppear
                    MMMData = new Dictionary<uint, List<MMMAppear>>();

                    foreach (var config in MMMConfigs)
                    {
                        uint id = (uint)config.Id;
                        var appears = mmmAppears
                            .Skip(config.StartIndex)
                            .Take(config.Count)
                            .ToList();

                        MMMData[id] = appears;
                    }

                    // Enable panel and populate combobox
                    panelMMMInfo.Enabled = true;
                    PopulateMMMComboBox();
                    UpdateMiniMapWithMMM();
                    buttonSaveChange.Enabled = true;
                }
                else
                {
                    // No MMM file found, disable panel
                    panelMMMInfo.Enabled = false;
                    MMMData = null;
                    MMMConfigs = null;
                    buttonSaveChange.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading MMM file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelMMMInfo.Enabled = false;
            }
        }

        /// <summary>
        /// Populate comboBoxMMM with MMM data in format: 0x{ID} or 0x{ID} (N)
        /// </summary>
        private void PopulateMMMComboBox()
        {
            comboBoxMMM.Items.Clear();

            if (MMMData == null || MMMData.Count == 0)
                return;

            foreach (var kvp in MMMData.OrderBy(x => x.Key))
            {
                uint id = kvp.Key;
                var appears = kvp.Value;

                if (appears.Count == 0)
                    continue;

                if (appears.Count == 1)
                {
                    // Single appear: just show ID
                    comboBoxMMM.Items.Add($"0x{id:X}");
                }
                else
                {
                    // Multiple appears: add (N) suffix for each
                    for (int i = 0; i < appears.Count; i++)
                    {
                        if (i == 0)
                            comboBoxMMM.Items.Add($"0x{id:X}");
                        else
                            comboBoxMMM.Items.Add($"0x{id:X} ({i + 1})");
                    }
                }
            }
        }

        /// <summary>
        /// Convert world position to minimap pixel coordinates
        /// </summary>
        private PointF MMMPointToMiniMapPoint(float pointX, float pointY, int mapWidth, int mapHeight)
        {
            if (CurrentMapenv?.MMModelPos == null)
                return new PointF(0, 0);

            float minX = CurrentMapenv.MMModelPos.MinX;
            float minY = CurrentMapenv.MMModelPos.MinY;
            float maxX = CurrentMapenv.MMModelPos.MaxX;
            float maxY = CurrentMapenv.MMModelPos.MaxY;

            float rangeX = maxX - minX;
            float rangeY = maxY - minY;

            if (rangeX == 0) rangeX = 1;
            if (rangeY == 0) rangeY = 1;

            float scaleX = mapWidth / rangeX;
            float scaleY = mapHeight / rangeY;

            float mapX = (pointX - minX) * scaleX;
            float mapY = (pointY - minY) * scaleY;

            return new PointF(mapX, mapY);
        }

        /// <summary>
        /// Draw an arrow at the specified point with rotation
        /// </summary>
        private void DrawArrow(Graphics g, PointF point, int rotation, Brush brush)
        {
            float arrowSize = 10f;

            // Save the graphics state
            GraphicsState state = g.Save();

            // Translate to the point and rotate
            g.TranslateTransform(point.X, point.Y);
            g.RotateTransform(rotation);

            // Define arrow points (pointing up)
            PointF[] arrowPoints = new PointF[]
            {
                new PointF(0, -arrowSize),           // Top point
                new PointF(-arrowSize/2, arrowSize/2), // Bottom left
                new PointF(arrowSize/2, arrowSize/2)   // Bottom right
            };

            g.FillPolygon(brush, arrowPoints);

            // Restore the graphics state
            g.Restore(state);
        }

        /// <summary>
        /// Draw a flag at the specified point (no rotation)
        /// </summary>
        private void DrawFlag(Graphics g, PointF point, Brush brush)
        {
            float flagHeight = 12f;
            float flagWidth = 8f;
            float poleHeight = 15f;

            // Draw pole
            g.DrawLine(new Pen(brush, 2), point.X, point.Y, point.X, point.Y - poleHeight);

            // Draw flag triangle
            PointF[] flagPoints = new PointF[]
            {
                new PointF(point.X, point.Y - poleHeight),
                new PointF(point.X + flagWidth, point.Y - poleHeight + flagHeight/2),
                new PointF(point.X, point.Y - poleHeight + flagHeight)
            };

            g.FillPolygon(brush, flagPoints);
        }

        /// <summary>
        /// Update minimap image with MMM points drawn on it
        /// </summary>
        private void UpdateMiniMapWithMMM()
        {
            if (MiniMapImage == null)
                return;

            // Create a copy of the original minimap
            Bitmap displayImage = new Bitmap(MiniMapImage);

            if (MMMData != null && MMMData.Count > 0)
            {
                using (Graphics g = Graphics.FromImage(displayImage))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    // Draw all MMM points
                    foreach (var kvp in MMMData)
                    {
                        var appears = kvp.Value;
                        foreach (var appear in appears)
                        {
                            PointF point = MMMPointToMiniMapPoint(appear.PosX, appear.PosY,
                                displayImage.Width, displayImage.Height);

                            // Check if this is the selected MMM
                            bool isSelected = (_selectedMMMAppear != null &&
                                             _selectedMMMAppear == appear);

                            // Draw based on type
                            if (appear.Type == 1)
                            {
                                Brush brush = isSelected ? Brushes.Red : Brushes.Blue;
                                DrawArrow(g, point, appear.Rot, brush);
                            }
                            else if (appear.Type == 2)
                            {
                                Brush brush = isSelected ? Brushes.DarkGreen : Brushes.Green;
                                DrawFlag(g, point, brush);
                            }
                            else
                            {
                                Brush brush = isSelected ? Brushes.Red : Brushes.Blue;
                                float radius = isSelected ? 5f : 3f;
                                g.FillEllipse(brush, point.X - radius, point.Y - radius, radius * 2, radius * 2);
                            }
                        }
                    }
                }
            }

            // Display in PictureBox
            pictureBoxMapPreview.Image = displayImage;
            pictureBoxMapPreview.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// Get MMMAppear from combobox selection text
        /// </summary>
        private MMMAppear GetMMMAppearFromComboBoxSelection(string selectedText)
        {
            if (string.IsNullOrEmpty(selectedText) || MMMData == null)
                return null;

            // Parse the selected text to extract ID and index
            // Format: "0x{ID}" or "0x{ID} (N)"
            string[] parts = selectedText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
                return null;

            string idPart = parts[0].Replace("0x", "");
            if (!uint.TryParse(idPart, System.Globalization.NumberStyles.HexNumber, null, out uint id))
                return null;

            int appearIndex = 0;
            if (parts.Length > 1)
            {
                // Extract number from "(N)"
                string indexPart = parts[1].Trim('(', ')');
                if (int.TryParse(indexPart, out int parsedIndex))
                    appearIndex = parsedIndex - 1;
            }

            if (MMMData.TryGetValue(id, out var appears) && appearIndex >= 0 && appearIndex < appears.Count)
            {
                return appears[appearIndex];
            }

            return null;
        }

        /// <summary>
        /// Get MMMConfig from combobox selection text
        /// </summary>
        private MMMConfig GetMMMConfigFromComboBoxSelection(string selectedText)
        {
            if (string.IsNullOrEmpty(selectedText) || MMMConfigs == null)
                return null;

            string[] parts = selectedText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
                return null;

            string idPart = parts[0].Replace("0x", "");
            if (!uint.TryParse(idPart, System.Globalization.NumberStyles.HexNumber, null, out uint id))
                return null;

            return MMMConfigs.FirstOrDefault(c => (uint)c.Id == id);
        }

        private void LoadMap()
        {
            VirtualDirectory mapFolder = IEA_FA.Directory.GetFolderFromFullPath("/data/map");

            Bitmap miniMapImage = null;

            if (mapFolder != null)
            {
                string selectedText = comboBoxMapId.Items[comboBoxMapId.SelectedIndex].ToString();
                CurrentMapId = selectedText;

                if (mapFolder.IsFolderExists(selectedText))
                {
                    VirtualDirectory selectedMap = mapFolder.GetFolder(selectedText);

                    if (selectedMap != null)
                    {
                        string xiFile = $"{selectedText}.xi";

                        if (selectedMap.Files.ContainsKey(xiFile))
                        {
                            selectedMap.Files[xiFile].Read();
                            byte[] imageData = selectedMap.Files[xiFile].ByteContent;

                            miniMapImage = IMGC.ToBitmap(imageData);
                        }
                    }

                    // Load mapenv for boundaries
                    LoadMapenvFile(selectedText);

                    // Load MMM file
                    LoadMMMFile(selectedText);
                }
            }

            // If no image found, create a transparent bitmap with black text
            if (miniMapImage == null)
            {
                int width = pictureBoxMapPreview.Width;
                int height = pictureBoxMapPreview.Height;

                miniMapImage = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                using (Graphics g = Graphics.FromImage(miniMapImage))
                {
                    g.Clear(Color.Transparent);

                    string text = "No Minimap found";
                    Font font = new Font("Arial", 14, FontStyle.Bold);
                    SizeF textSize = g.MeasureString(text, font);

                    float x = (width - textSize.Width) / 2;
                    float y = (height - textSize.Height) / 2;

                    g.DrawString(text, font, Brushes.Black, x, y);
                }
            }

            // Store the original minimap
            MiniMapImage = miniMapImage;

            // Update display with MMM points
            UpdateMiniMapWithMMM();
        }

        /// <summary>
        /// Save MMM file with updated data
        /// </summary>
        private void SaveMMMFile()
        {
            if (string.IsNullOrEmpty(CurrentMapId) || MMMData == null || MMMConfigs == null)
                return;

            try
            {
                VirtualDirectory mapFolder = IEA_FA.Directory.GetFolderFromFullPath("/data/map");
                if (mapFolder == null || !mapFolder.IsFolderExists(CurrentMapId))
                    return;

                VirtualDirectory selectedMap = mapFolder.GetFolder(CurrentMapId);
                string mmmFile = $"{CurrentMapId}.mmm.bin";

                if (selectedMap == null)
                    return;

                CfgBin<CfgTreeNode> mmmBin = new CfgBin<CfgTreeNode>();
                mmmBin.Encoding = Encoding.GetEncoding("SHIFT-JIS");

                // Rebuild configs and appears with correct indices
                var allAppears = new List<MMMAppear>();
                var updatedConfigs = new List<MMMConfig>();

                int currentIndex = 0;

                foreach (var kvp in MMMData.OrderBy(x => x.Key))
                {
                    uint id = kvp.Key;
                    var appears = kvp.Value;

                    // Find or create config
                    var config = MMMConfigs.FirstOrDefault(c => (uint)c.Id == id);
                    if (config == null)
                    {
                        config = new MMMConfig
                        {
                            Id = (int)id,
                            Condition = string.Empty
                        };
                    }

                    // Update indices in appears
                    for (int i = 0; i < appears.Count; i++)
                    {
                        appears[i].Index = currentIndex + i;
                    }

                    // Update config indices
                    config.StartIndex = currentIndex;
                    config.Count = appears.Count;

                    updatedConfigs.Add(config);
                    allAppears.AddRange(appears);

                    currentIndex += appears.Count;
                }

                // Add nodes
                mmmBin.Entries.AddBoundedEntryFromClassList(updatedConfigs, "MMM_CONFIG_BEGIN", "MMM_CONFIG");
                mmmBin.Entries.AddBoundedEntryFromClassList(allAppears, "MMM_APPEAR_BEGIN", "MMM_APPEAR");

                // Save to file
                if (selectedMap.Files.ContainsKey(mmmFile))
                {
                    selectedMap.Files[mmmFile].ByteContent = mmmBin.Save();
                }
                else
                {
                    // Create new file if it doesn't exist
                    var newFile = new SubMemoryStream(mmmBin.Save());
                    selectedMap.Files.Add(mmmFile, newFile);
                }

                MessageBox.Show("MMM changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving MMM file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save the entire FA file
        /// </summary>
        private void SaveFAFile()
        {
            if (IEA_FA == null || string.IsNullOrEmpty(FileName))
                return;

            try
            {
                string tempPath = "./temp";

                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }

                string tempFileName = Path.Combine(tempPath, Path.GetFileName(FileName));

                // Save
                IEA_FA.Save(tempFileName);

                // Close File
                IEA_FA.Close();

                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
                }

                File.Move(tempFileName, FileName);

                // Reopen the file
                IEA_FA = new ARC0(new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open FA File";
            openFileDialog1.Filter = "FA files|*.fa";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileName = openFileDialog1.FileName;
                    IEA_FA = new ARC0(new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                    Language = GetLanguage();
                }
                catch (Exception ex)
                {
                    IEA_FA = null;
                    MessageBox.Show("Error: Could not read file: " + ex.Message);
                }
            }

            bool fileOpened = IEA_FA != null;

            buttonOpenFile.Visible = !fileOpened;
            panelLanguage.Visible = !fileOpened;
            buttonCloseFile.Visible = fileOpened;
            buttonSaveFile.Visible = fileOpened;

            if (fileOpened)
            {
                // Load phase data (but don't display in UI)
                PhaseInfos = GetPhaseInfos();
                PhaseTexts = GetPhaseTexts(PhaseInfos);

                // Set map
                KeyValuePair<int, string>[] maps = GetMapIds();
                comboBoxMapId.Items.AddRange(maps.Select(x => x.Value.ToString()).ToArray());
                comboBoxMapName.Items.AddRange(GetMapTexts(maps));
            }
            else
            {
                if (PhaseInfos != null)
                {
                    Array.Clear(PhaseInfos, 0, PhaseInfos.Length);
                }
            }

            panelMain.Enabled = fileOpened;
        }

        private void ComboBoxMapId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isSyncingMaps) return;
            if (comboBoxMapId.SelectedIndex == -1) return;

            try
            {
                _isSyncingMaps = true;
                comboBoxMapName.SelectedIndex = comboBoxMapId.SelectedIndex;
            }
            finally
            {
                _isSyncingMaps = false;
            }

            LoadMap();
        }

        private void ComboBoxMapName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isSyncingMaps) return;
            if (comboBoxMapName.SelectedIndex == -1) return;

            try
            {
                _isSyncingMaps = true;
                comboBoxMapId.SelectedIndex = comboBoxMapName.SelectedIndex;
                LoadMap();
            }
            finally
            {
                _isSyncingMaps = false;
            }
        }

        private void PanelMapContainer_Resize(object sender, EventArgs e)
        {
            ResizeAndCenterPictureBox();
        }

        private void PanelMapInfo_Resize(object sender, EventArgs e)
        {
            ResizeMapInfoPanels();
            ResizeAndCenterPictureBox();
        }

        private void ComboBoxMMM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMMM.SelectedIndex == -1)
                return;

            string selectedText = comboBoxMMM.SelectedItem.ToString();

            // Get the selected MMM appear
            _selectedMMMAppear = GetMMMAppearFromComboBoxSelection(selectedText);
            var config = GetMMMConfigFromComboBoxSelection(selectedText);

            if (_selectedMMMAppear != null)
            {
                // Fill numeric controls with MMM appear data (no Index control)
                numericUpDownType.Value = _selectedMMMAppear.Type;
                numericUpDownPosX.Value = _selectedMMMAppear.PosX;
                numericUpDownPosY.Value = _selectedMMMAppear.PosY;
                numericUpDownRot.Value = _selectedMMMAppear.Rot;
            }

            if (config != null)
            {
                // Fill condition textbox
                textBoxCondition.Text = config.Condition ?? string.Empty;
            }

            // Update minimap to highlight selected MMM
            UpdateMiniMapWithMMM();
        }

        private void NumericUpDownType_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedMMMAppear != null)
            {
                _selectedMMMAppear.Type = (int)numericUpDownType.Value;

                // Redraw with new type
                UpdateMiniMapWithMMM(); 
            }
        }

        private void NumericUpDownPosX_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedMMMAppear != null)
            {
                _selectedMMMAppear.PosX = (int)numericUpDownPosX.Value;
                UpdateMiniMapWithMMM();
            }
        }

        private void NumericUpDownPosY_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedMMMAppear != null)
            {
                _selectedMMMAppear.PosY = (int)numericUpDownPosY.Value;
                UpdateMiniMapWithMMM();
            }
        }

        private void NumericUpDownRot_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedMMMAppear != null)
            {
                _selectedMMMAppear.Rot = (int)numericUpDownRot.Value;

                // Redraw with new rotation
                UpdateMiniMapWithMMM(); 
            }
        }

        private void ButtonOpenCondition_Click(object sender, EventArgs e)
        {
            if (comboBoxMMM.SelectedIndex == -1)
                return;

            string selectedText = comboBoxMMM.SelectedItem.ToString();
            var config = GetMMMConfigFromComboBoxSelection(selectedText);

            if (config == null)
                return;

            // Check if the ./Tools/inz_cond folder exists
            string toolsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "inz_cond");
            string exePath = Path.Combine(toolsPath, "inz_cond_gui.exe");

            if (!Directory.Exists(toolsPath) || !File.Exists(exePath))
            {
                MessageBox.Show(
                    "inz_cond_gui.exe must be in the inz_cond folder within the Tools folder.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Prepare the arguments
            string arguments = "-o";

            // If Condition is a non-empty string, add it as an argument
            if (!string.IsNullOrEmpty(config.Condition))
            {
                arguments += $" {config.Condition}";
            }

            // Create the process
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = toolsPath
            };

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    // Wait for the process to finish
                    process.WaitForExit();

                    // Read the output
                    string output = process.StandardOutput.ReadToEnd().Trim();

                    // Clean up output: ignore warnings
                    string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    string base64Line = lines.LastOrDefault(line => !line.StartsWith("Warning:", StringComparison.OrdinalIgnoreCase));

                    if (base64Line == null)
                        base64Line = string.Empty;

                    // Process the result
                    if (base64Line == "-1")
                    {
                        // Return -1: set Condition to empty
                        config.Condition = string.Empty;
                        textBoxCondition.Text = string.Empty;
                    }
                    else if (!string.IsNullOrEmpty(base64Line))
                    {
                        // Base64 return: set Condition to base64
                        config.Condition = base64Line;
                        textBoxCondition.Text = base64Line;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error when launching inz_cond_gui.exe:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ButtonAddItem_Click(object sender, EventArgs e)
        {
            // Open AddItemWindow dialog
            using (var addItemWindow = new AddItemWindow(PhaseInfos, PhaseTexts))
            {
                if (addItemWindow.ShowDialog() == DialogResult.OK)
                {
                    // Get the result from the dialog
                    var newAppear = addItemWindow.NewMMMAppear;
                    var newConfig = addItemWindow.NewMMMConfig;
                    bool isNewConfig = addItemWindow.IsNewConfig;

                    if (newAppear != null)
                    {
                        if (isNewConfig && newConfig != null)
                        {
                            // Generate a new unique CRC32 key
                            uint newKey = GenerateUniqueMMMKey();

                            if (newKey == 0)
                            {
                                MessageBox.Show("Failed to generate a unique MMM key after 3 attempts.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Add new config
                            newConfig.Id = (int)newKey;
                            MMMConfigs.Add(newConfig);

                            // Add new appear list
                            MMMData[newKey] = new List<MMMAppear> { newAppear };
                        }
                        else
                        {
                            // Insert into existing config (selected in combobox)
                            if (comboBoxMMM.SelectedIndex != -1)
                            {
                                string selectedText = comboBoxMMM.SelectedItem.ToString();
                                string[] parts = selectedText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                if (parts.Length > 0)
                                {
                                    string idPart = parts[0].Replace("0x", "");
                                    if (uint.TryParse(idPart, System.Globalization.NumberStyles.HexNumber, null, out uint id))
                                    {
                                        if (MMMData.ContainsKey(id))
                                        {
                                            MMMData[id].Add(newAppear);
                                        }
                                    }
                                }
                            }
                        }

                        // Refresh UI
                        PopulateMMMComboBox();
                        UpdateMiniMapWithMMM();
                    }
                }
            }
        }

        /// <summary>
        /// Generate a unique CRC32 key that doesn't exist in MMMData
        /// Tries up to 3 times
        /// </summary>
        private uint GenerateUniqueMMMKey()
        {
            Random random = new Random();

            for (int attempt = 0; attempt < 3; attempt++)
            {
                // Generate a random GUID and compute its CRC32
                string guid = Guid.NewGuid().ToString();
                uint crc32 = Crc32.Compute(Encoding.UTF8.GetBytes(guid));

                // Check if this key already exists
                if (!MMMData.ContainsKey(crc32))
                {
                    return crc32;
                }
            }

            // Failed to generate unique key
            return 0;
        }

        private void ButtonSaveChange_Click(object sender, EventArgs e)
        {
            // Save MMM file changes
            SaveMMMFile();

            // Reload the map to reflect changes
            LoadMMMFile(CurrentMapId);
            PopulateMMMComboBox();
            UpdateMiniMapWithMMM();
        }

        private void ButtonSaveFile_Click(object sender, EventArgs e)
        {
            SaveFAFile();
        }
    }
}