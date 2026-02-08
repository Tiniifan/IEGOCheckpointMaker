using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudioElevenLib.Level5.Archive.ARC0;
using StudioElevenLib.Level5.Binary;
using StudioElevenLib.Level5.Binary.Collections;
using StudioElevenLib.Level5.Text;
using StudioElevenLib.Tools;

namespace IEGOCheckpointMaker
{
    public partial class MainWindow : Form
    {
        private ARC0 IEA_FA;

        private string Language;

        private PhaseInfo[] PhaseInfos;

        private bool _isSyncing = false;
        private bool _isSyncingMaps = false;

        public MainWindow()
        {
            InitializeComponent();
            ResizeAndCenterPictureBox();
        }

        private string GetLanguage()
        {
            if (radioButtonFrench.Checked)
            {
                return "fr";
            } else if (radioButtonSpanish.Checked)
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

        private void ResizeAndCenterPictureBox()
        {
            if (pictureBoxMapPreview == null || panelMapContainer == null)
                return;

            int verticalMargin = 10;

            // Maximum square size: panel width or height - 2*margin
            int size = Math.Min(panelMapContainer.Width, panelMapContainer.Height - 2 * verticalMargin);

            // Apply size
            pictureBoxMapPreview.Width = size;
            pictureBoxMapPreview.Height = size;

            // Centre horizontally and vertically with margin
            pictureBoxMapPreview.Left = (panelMapContainer.Width - size) / 2;
            pictureBoxMapPreview.Top = verticalMargin + ((panelMapContainer.Height - 2 * verticalMargin - size) / 2);
        }


        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open FA File";
            openFileDialog1.Filter = "FA files|*.fa";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IEA_FA = new ARC0(new FileStream(openFileDialog1.FileName, FileMode.Open));
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
                // Set phase
                PhaseInfos = GetPhaseInfos();
                comboBoxPhaseNumber.Items.AddRange(PhaseInfos.Select(x => x.PhaseString.ToString()).ToArray());
                comboBoxPhaseText.Items.AddRange(GetPhaseTexts(PhaseInfos));

                // Set map
                KeyValuePair<int, string>[] maps = GetMapIds();
                comboBoxMapId.Items.AddRange(maps.Select(x => x.Value.ToString()).ToArray());
                comboBoxMapName.Items.AddRange(GetMapTexts(maps));
            } else
            {
                if (PhaseInfos != null)
                {
                    Array.Clear(PhaseInfos, 0, PhaseInfos.Length);
                }
            }

            panelMain.Enabled = fileOpened;
        }

        private void ComboBoxPhaseNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isSyncing) return;

            try
            {
                _isSyncing = true;
                comboBoxPhaseText.SelectedIndex = comboBoxPhaseNumber.SelectedIndex;
            }
            finally
            {
                _isSyncing = false;
            }
        }

        private void ComboBoxPhaseText_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isSyncing) return;

            try
            {
                _isSyncing = true;
                comboBoxPhaseNumber.SelectedIndex = comboBoxPhaseText.SelectedIndex;
            }
            finally
            {
                _isSyncing = false;
            }
        }

        private void ComboBoxMapId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isSyncingMaps) return;

            try
            {
                _isSyncingMaps = true;
                comboBoxMapName.SelectedIndex = comboBoxMapId.SelectedIndex;
            }
            finally
            {
                _isSyncingMaps = false;
            }
        }

        private void ComboBoxMapName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isSyncingMaps) return;

            try
            {
                _isSyncingMaps = true;
                comboBoxMapId.SelectedIndex = comboBoxMapName.SelectedIndex;
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
    }
}
