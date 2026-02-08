namespace IEGOCheckpointMaker
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonSaveFile = new System.Windows.Forms.Button();
            this.buttonCloseFile = new System.Windows.Forms.Button();
            this.panelLanguage = new System.Windows.Forms.Panel();
            this.radioButtonDeutsch = new System.Windows.Forms.RadioButton();
            this.radioButtonItalian = new System.Windows.Forms.RadioButton();
            this.radioButtonSpanish = new System.Windows.Forms.RadioButton();
            this.radioButtonFrench = new System.Windows.Forms.RadioButton();
            this.radioButtonEnglish = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelMain = new System.Windows.Forms.Panel();
            this.pictureBoxMapPreview = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxMapName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxMapId = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelPhase = new System.Windows.Forms.Panel();
            this.comboBoxPhaseText = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPhaseNumber = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMapContainer = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelLanguage.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMapPreview)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelPhase.SuspendLayout();
            this.panelMapContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelTop.Controls.Add(this.buttonSaveFile);
            this.panelTop.Controls.Add(this.buttonCloseFile);
            this.panelTop.Controls.Add(this.panelLanguage);
            this.panelTop.Controls.Add(this.buttonOpenFile);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(664, 55);
            this.panelTop.TabIndex = 0;
            // 
            // buttonSaveFile
            // 
            this.buttonSaveFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonSaveFile.Location = new System.Drawing.Point(649, 0);
            this.buttonSaveFile.Name = "buttonSaveFile";
            this.buttonSaveFile.Size = new System.Drawing.Size(113, 55);
            this.buttonSaveFile.TabIndex = 8;
            this.buttonSaveFile.Text = "Save your .fa";
            this.buttonSaveFile.UseVisualStyleBackColor = true;
            this.buttonSaveFile.Visible = false;
            // 
            // buttonCloseFile
            // 
            this.buttonCloseFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCloseFile.Location = new System.Drawing.Point(536, 0);
            this.buttonCloseFile.Name = "buttonCloseFile";
            this.buttonCloseFile.Size = new System.Drawing.Size(113, 55);
            this.buttonCloseFile.TabIndex = 7;
            this.buttonCloseFile.Text = "Close your .fa";
            this.buttonCloseFile.UseVisualStyleBackColor = true;
            this.buttonCloseFile.Visible = false;
            // 
            // panelLanguage
            // 
            this.panelLanguage.AutoSize = true;
            this.panelLanguage.Controls.Add(this.radioButtonDeutsch);
            this.panelLanguage.Controls.Add(this.radioButtonItalian);
            this.panelLanguage.Controls.Add(this.radioButtonSpanish);
            this.panelLanguage.Controls.Add(this.radioButtonFrench);
            this.panelLanguage.Controls.Add(this.radioButtonEnglish);
            this.panelLanguage.Controls.Add(this.label1);
            this.panelLanguage.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLanguage.Location = new System.Drawing.Point(113, 0);
            this.panelLanguage.Name = "panelLanguage";
            this.panelLanguage.Size = new System.Drawing.Size(423, 55);
            this.panelLanguage.TabIndex = 9;
            // 
            // radioButtonDeutsch
            // 
            this.radioButtonDeutsch.AutoSize = true;
            this.radioButtonDeutsch.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonDeutsch.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButtonDeutsch.Location = new System.Drawing.Point(358, 0);
            this.radioButtonDeutsch.Name = "radioButtonDeutsch";
            this.radioButtonDeutsch.Size = new System.Drawing.Size(65, 55);
            this.radioButtonDeutsch.TabIndex = 5;
            this.radioButtonDeutsch.Text = "Deutsch";
            this.radioButtonDeutsch.UseVisualStyleBackColor = false;
            // 
            // radioButtonItalian
            // 
            this.radioButtonItalian.AutoSize = true;
            this.radioButtonItalian.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonItalian.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButtonItalian.Location = new System.Drawing.Point(305, 0);
            this.radioButtonItalian.Name = "radioButtonItalian";
            this.radioButtonItalian.Size = new System.Drawing.Size(53, 55);
            this.radioButtonItalian.TabIndex = 4;
            this.radioButtonItalian.Text = "Italian";
            this.radioButtonItalian.UseVisualStyleBackColor = false;
            // 
            // radioButtonSpanish
            // 
            this.radioButtonSpanish.AutoSize = true;
            this.radioButtonSpanish.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonSpanish.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButtonSpanish.Location = new System.Drawing.Point(242, 0);
            this.radioButtonSpanish.Name = "radioButtonSpanish";
            this.radioButtonSpanish.Size = new System.Drawing.Size(63, 55);
            this.radioButtonSpanish.TabIndex = 3;
            this.radioButtonSpanish.Text = "Spanish";
            this.radioButtonSpanish.UseVisualStyleBackColor = false;
            // 
            // radioButtonFrench
            // 
            this.radioButtonFrench.AutoSize = true;
            this.radioButtonFrench.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonFrench.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButtonFrench.Location = new System.Drawing.Point(184, 0);
            this.radioButtonFrench.Name = "radioButtonFrench";
            this.radioButtonFrench.Size = new System.Drawing.Size(58, 55);
            this.radioButtonFrench.TabIndex = 2;
            this.radioButtonFrench.Text = "French";
            this.radioButtonFrench.UseVisualStyleBackColor = false;
            // 
            // radioButtonEnglish
            // 
            this.radioButtonEnglish.AutoSize = true;
            this.radioButtonEnglish.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonEnglish.Checked = true;
            this.radioButtonEnglish.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButtonEnglish.Location = new System.Drawing.Point(125, 0);
            this.radioButtonEnglish.Name = "radioButtonEnglish";
            this.radioButtonEnglish.Size = new System.Drawing.Size(59, 55);
            this.radioButtonEnglish.TabIndex = 1;
            this.radioButtonEnglish.TabStop = true;
            this.radioButtonEnglish.Text = "English";
            this.radioButtonEnglish.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 55);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choose your language :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonOpenFile.Location = new System.Drawing.Point(0, 0);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(113, 55);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Text = "Open your .fa";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelMapContainer);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Controls.Add(this.panelPhase);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Enabled = false;
            this.panelMain.Location = new System.Drawing.Point(0, 55);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(664, 450);
            this.panelMain.TabIndex = 1;
            // 
            // pictureBoxMapPreview
            // 
            this.pictureBoxMapPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxMapPreview.Location = new System.Drawing.Point(182, 44);
            this.pictureBoxMapPreview.Name = "pictureBoxMapPreview";
            this.pictureBoxMapPreview.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxMapPreview.TabIndex = 2;
            this.pictureBoxMapPreview.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxMapName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxMapId);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 33);
            this.panel1.TabIndex = 1;
            // 
            // comboBoxMapName
            // 
            this.comboBoxMapName.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxMapName.FormattingEnabled = true;
            this.comboBoxMapName.Location = new System.Drawing.Point(442, 0);
            this.comboBoxMapName.Name = "comboBoxMapName";
            this.comboBoxMapName.Size = new System.Drawing.Size(207, 21);
            this.comboBoxMapName.TabIndex = 3;
            this.comboBoxMapName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMapName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(335, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 33);
            this.label5.TabIndex = 4;
            this.label5.Text = "By name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBoxMapId
            // 
            this.comboBoxMapId.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxMapId.FormattingEnabled = true;
            this.comboBoxMapId.Location = new System.Drawing.Point(214, 0);
            this.comboBoxMapId.Name = "comboBoxMapId";
            this.comboBoxMapId.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMapId.TabIndex = 1;
            this.comboBoxMapId.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMapId_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(107, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 33);
            this.label6.TabIndex = 2;
            this.label6.Text = "By map ID";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 33);
            this.label7.TabIndex = 0;
            this.label7.Text = "Choose your map";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelPhase
            // 
            this.panelPhase.Controls.Add(this.comboBoxPhaseText);
            this.panelPhase.Controls.Add(this.label4);
            this.panelPhase.Controls.Add(this.comboBoxPhaseNumber);
            this.panelPhase.Controls.Add(this.label3);
            this.panelPhase.Controls.Add(this.label2);
            this.panelPhase.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPhase.Location = new System.Drawing.Point(0, 0);
            this.panelPhase.Name = "panelPhase";
            this.panelPhase.Size = new System.Drawing.Size(664, 33);
            this.panelPhase.TabIndex = 0;
            // 
            // comboBoxPhaseText
            // 
            this.comboBoxPhaseText.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxPhaseText.FormattingEnabled = true;
            this.comboBoxPhaseText.Location = new System.Drawing.Point(442, 0);
            this.comboBoxPhaseText.Name = "comboBoxPhaseText";
            this.comboBoxPhaseText.Size = new System.Drawing.Size(207, 21);
            this.comboBoxPhaseText.TabIndex = 3;
            this.comboBoxPhaseText.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPhaseText_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(335, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 33);
            this.label4.TabIndex = 4;
            this.label4.Text = "By text";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBoxPhaseNumber
            // 
            this.comboBoxPhaseNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxPhaseNumber.FormattingEnabled = true;
            this.comboBoxPhaseNumber.Location = new System.Drawing.Point(214, 0);
            this.comboBoxPhaseNumber.Name = "comboBoxPhaseNumber";
            this.comboBoxPhaseNumber.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPhaseNumber.TabIndex = 1;
            this.comboBoxPhaseNumber.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPhaseNumber_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(107, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "By number";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Choose your phase";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelMapContainer
            // 
            this.panelMapContainer.Controls.Add(this.pictureBoxMapPreview);
            this.panelMapContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMapContainer.Location = new System.Drawing.Point(0, 66);
            this.panelMapContainer.Name = "panelMapContainer";
            this.panelMapContainer.Size = new System.Drawing.Size(664, 384);
            this.panelMapContainer.TabIndex = 3;
            this.panelMapContainer.Resize += new System.EventHandler(this.PanelMapContainer_Resize);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 505);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelLanguage.ResumeLayout(false);
            this.panelLanguage.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMapPreview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelPhase.ResumeLayout(false);
            this.panelMapContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.RadioButton radioButtonDeutsch;
        private System.Windows.Forms.RadioButton radioButtonItalian;
        private System.Windows.Forms.RadioButton radioButtonSpanish;
        private System.Windows.Forms.RadioButton radioButtonFrench;
        private System.Windows.Forms.RadioButton radioButtonEnglish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelLanguage;
        private System.Windows.Forms.Button buttonSaveFile;
        private System.Windows.Forms.Button buttonCloseFile;
        private System.Windows.Forms.Panel panelPhase;
        private System.Windows.Forms.ComboBox comboBoxPhaseText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPhaseNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxMapName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxMapId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBoxMapPreview;
        private System.Windows.Forms.Panel panelMapContainer;
    }
}

