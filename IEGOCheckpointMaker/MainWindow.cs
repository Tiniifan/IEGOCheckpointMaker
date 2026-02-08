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

namespace IEGOCheckpointMaker
{
    public partial class MainWindow : Form
    {
        private ARC0 IEA_FA;

        private string Language;

        private PhaseInfo[] PhaseInfos;

        private bool _isSyncing = false;

        public MainWindow()
        {
            InitializeComponent();
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
                PhaseInfos = GetPhaseInfos();

                comboBoxPhaseNumber.Items.AddRange(PhaseInfos.Select(x => x.PhaseString.ToString()).ToArray());
                comboBoxPhaseText.Items.AddRange(GetPhaseTexts(PhaseInfos));
            } else
            {
                Array.Clear(PhaseInfos, 0, PhaseInfos.Length);
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
    }
}
