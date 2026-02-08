using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IEGOCheckpointMaker.Models;

namespace IEGOCheckpointMaker
{
    public partial class AddItemWindow : Form
    {
        private PhaseInfo[] _phaseInfos;
        private string[] _phaseTexts;
        private bool _isSyncing = false;
        private bool _isCustomCondition = false;

        public MMMAppear NewMMMAppear { get; private set; }
        public MMMConfig NewMMMConfig { get; private set; }
        public bool IsNewConfig { get; private set; }

        public AddItemWindow(PhaseInfo[] phaseInfos, string[] phaseTexts)
        {
            InitializeComponent();

            _phaseInfos = phaseInfos;
            _phaseTexts = phaseTexts;

            LoadPhaseComboBoxes();
        }

        /// <summary>
        /// Load phase data into comboboxes
        /// </summary>
        private void LoadPhaseComboBoxes()
        {
            if (_phaseInfos != null)
            {
                comboBoxPhaseNumber.Items.AddRange(_phaseInfos.Select(x => x.PhaseString.ToString()).ToArray());
            }

            if (_phaseTexts != null)
            {
                comboBoxPhaseText.Items.AddRange(_phaseTexts);
            }
        }

        /// <summary>
        /// Generate condition from selected phase
        /// Format (big endian): 00 00 00 00 0F 05 35 98 EE 4B 47 00 01 00 32 XX XX XX XX 78
        /// where XX XX XX XX is the phase number in little endian
        /// </summary>
        private void GenerateCondition()
        {
            if (_isCustomCondition || comboBoxPhaseNumber.SelectedIndex == -1)
                return;

            // Get the phase string (e.g., "1_010_010")
            string phaseString = _phaseInfos[comboBoxPhaseNumber.SelectedIndex].PhaseString;

            // Remove underscores and parse as integer
            string phaseNumberStr = phaseString.Replace("_", "");
            if (!int.TryParse(phaseNumberStr, out int phaseNumber))
                return;

            // Create the condition byte array (20 bytes total)
            byte[] condition = new byte[20];

            // Fixed prefix (big endian format given)
            condition[0] = 0x00;
            condition[1] = 0x00;
            condition[2] = 0x00;
            condition[3] = 0x00;
            condition[4] = 0x0F;
            condition[5] = 0x05;
            condition[6] = 0x35;
            condition[7] = 0x98;
            condition[8] = 0xEE;
            condition[9] = 0x4B;
            condition[10] = 0x47;
            condition[11] = 0x00;
            condition[12] = 0x01;
            condition[13] = 0x00;
            condition[14] = 0x32;

            // Convert phase number to little endian (4 bytes)
            byte[] phaseBytes = BitConverter.GetBytes(phaseNumber);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(phaseBytes);
            }

            condition[15] = phaseBytes[0];
            condition[16] = phaseBytes[1];
            condition[17] = phaseBytes[2];
            condition[18] = phaseBytes[3];

            condition[19] = 0x78;

            // Convert to base64
            string base64Condition = Convert.ToBase64String(condition);
            textBoxCondition.Text = base64Condition;
        }

        private void ComboBoxPhaseNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isSyncing) return;
            if (comboBoxPhaseNumber.SelectedIndex == -1) return;

            try
            {
                _isSyncing = true;
                comboBoxPhaseText.SelectedIndex = comboBoxPhaseNumber.SelectedIndex;

                // Clear custom condition flag when selecting from combo
                _isCustomCondition = false;

                // Generate condition
                GenerateCondition();
            }
            finally
            {
                _isSyncing = false;
            }
        }

        private void ComboBoxPhaseText_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isSyncing) return;
            if (comboBoxPhaseText.SelectedIndex == -1) return;

            try
            {
                _isSyncing = true;
                comboBoxPhaseNumber.SelectedIndex = comboBoxPhaseText.SelectedIndex;

                // Clear custom condition flag when selecting from combo
                _isCustomCondition = false;

                // Generate condition
                GenerateCondition();
            }
            finally
            {
                _isSyncing = false;
            }
        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            // Insert into existing MMM config - ignore condition
            NewMMMAppear = new MMMAppear
            {
                // Will be set correctly on save
                Index = 0,
                
                Type = (int)numericUpDownType.Value,
                PosX = (int)numericUpDownPosX.Value,
                PosY = (int)numericUpDownPosY.Value,
                Rot = (int)numericUpDownRot.Value
            };

            IsNewConfig = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonAddNewOne_Click(object sender, EventArgs e)
        {
            // Add new MMM config
            NewMMMAppear = new MMMAppear
            {
                // Will be set correctly on save
                Index = 0, 

                Type = (int)numericUpDownType.Value,
                PosX = (int)numericUpDownPosX.Value,
                PosY = (int)numericUpDownPosY.Value,
                Rot = (int)numericUpDownRot.Value
            };

            NewMMMConfig = new MMMConfig
            {
                Id = 0, // Will be set by MainWindow
                Condition = textBoxCondition.Text,
                StartIndex = 0,
                Count = 1
            };

            IsNewConfig = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonOpenCondition_Click(object sender, EventArgs e)
        {
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
            if (!string.IsNullOrEmpty(textBoxCondition.Text))
            {
                arguments += $" {textBoxCondition.Text}";
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
                        textBoxCondition.Text = string.Empty;
                    }
                    else if (!string.IsNullOrEmpty(base64Line))
                    {
                        // Base64 return: set Condition to base64
                        textBoxCondition.Text = base64Line;

                        // Mark as custom condition
                        _isCustomCondition = true;

                        // Clear combobox selections to indicate custom condition
                        _isSyncing = true;
                        comboBoxPhaseNumber.SelectedIndex = -1;
                        comboBoxPhaseText.SelectedIndex = -1;
                        comboBoxPhaseNumber.Text = string.Empty;
                        comboBoxPhaseText.Text = string.Empty;
                        _isSyncing = false;
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
    }
}