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
            this.panelMapInfo = new System.Windows.Forms.Panel();
            this.panelMapContainer = new System.Windows.Forms.Panel();
            this.pictureBoxMapPreview = new System.Windows.Forms.PictureBox();
            this.panelMMMInfo = new System.Windows.Forms.Panel();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.buttonOpenCondition = new System.Windows.Forms.Button();
            this.textBoxCondition = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.numericUpDownRot = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numericUpDownPosY = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numericUpDownPosX = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDownType = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxMMM = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSaveChange = new System.Windows.Forms.Button();
            this.comboBoxMapName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxMapId = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelLanguage.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMapInfo.SuspendLayout();
            this.panelMapContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMapPreview)).BeginInit();
            this.panelMMMInfo.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRot)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosY)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosX)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownType)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.panelTop.Size = new System.Drawing.Size(798, 55);
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
            this.buttonSaveFile.Click += new System.EventHandler(this.ButtonSaveFile_Click);
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
            this.panelMain.Controls.Add(this.panelMapInfo);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Enabled = false;
            this.panelMain.Location = new System.Drawing.Point(0, 55);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(798, 450);
            this.panelMain.TabIndex = 1;
            // 
            // panelMapInfo
            // 
            this.panelMapInfo.Controls.Add(this.panelMapContainer);
            this.panelMapInfo.Controls.Add(this.panelMMMInfo);
            this.panelMapInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMapInfo.Location = new System.Drawing.Point(0, 33);
            this.panelMapInfo.Name = "panelMapInfo";
            this.panelMapInfo.Size = new System.Drawing.Size(798, 417);
            this.panelMapInfo.TabIndex = 0;
            this.panelMapInfo.Resize += new System.EventHandler(this.PanelMapInfo_Resize);
            // 
            // panelMapContainer
            // 
            this.panelMapContainer.Controls.Add(this.pictureBoxMapPreview);
            this.panelMapContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMapContainer.Location = new System.Drawing.Point(431, 0);
            this.panelMapContainer.Name = "panelMapContainer";
            this.panelMapContainer.Size = new System.Drawing.Size(367, 417);
            this.panelMapContainer.TabIndex = 3;
            this.panelMapContainer.Resize += new System.EventHandler(this.PanelMapContainer_Resize);
            // 
            // pictureBoxMapPreview
            // 
            this.pictureBoxMapPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxMapPreview.Location = new System.Drawing.Point(338, 45);
            this.pictureBoxMapPreview.Name = "pictureBoxMapPreview";
            this.pictureBoxMapPreview.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxMapPreview.TabIndex = 2;
            this.pictureBoxMapPreview.TabStop = false;
            // 
            // panelMMMInfo
            // 
            this.panelMMMInfo.Controls.Add(this.buttonAddItem);
            this.panelMMMInfo.Controls.Add(this.buttonOpenCondition);
            this.panelMMMInfo.Controls.Add(this.textBoxCondition);
            this.panelMMMInfo.Controls.Add(this.panel5);
            this.panelMMMInfo.Controls.Add(this.panel4);
            this.panelMMMInfo.Controls.Add(this.panel3);
            this.panelMMMInfo.Controls.Add(this.panel2);
            this.panelMMMInfo.Controls.Add(this.comboBoxMMM);
            this.panelMMMInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMMMInfo.Enabled = false;
            this.panelMMMInfo.Location = new System.Drawing.Point(0, 0);
            this.panelMMMInfo.Name = "panelMMMInfo";
            this.panelMMMInfo.Size = new System.Drawing.Size(297, 417);
            this.panelMMMInfo.TabIndex = 4;
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddItem.Location = new System.Drawing.Point(0, 216);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(297, 23);
            this.buttonAddItem.TabIndex = 8;
            this.buttonAddItem.Text = "Add item";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.ButtonAddItem_Click);
            // 
            // buttonOpenCondition
            // 
            this.buttonOpenCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonOpenCondition.Location = new System.Drawing.Point(0, 193);
            this.buttonOpenCondition.Name = "buttonOpenCondition";
            this.buttonOpenCondition.Size = new System.Drawing.Size(297, 23);
            this.buttonOpenCondition.TabIndex = 7;
            this.buttonOpenCondition.Text = "Open Condition";
            this.buttonOpenCondition.UseVisualStyleBackColor = true;
            this.buttonOpenCondition.Click += new System.EventHandler(this.ButtonOpenCondition_Click);
            // 
            // textBoxCondition
            // 
            this.textBoxCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxCondition.Location = new System.Drawing.Point(0, 173);
            this.textBoxCondition.Name = "textBoxCondition";
            this.textBoxCondition.Size = new System.Drawing.Size(297, 20);
            this.textBoxCondition.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.numericUpDownRot);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 135);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(297, 38);
            this.panel5.TabIndex = 4;
            // 
            // numericUpDownRot
            // 
            this.numericUpDownRot.DecimalPlaces = 2;
            this.numericUpDownRot.Location = new System.Drawing.Point(154, 6);
            this.numericUpDownRot.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownRot.Minimum = new decimal(new int[] {
            65535,
            0,
            0,
            -2147483648});
            this.numericUpDownRot.Name = "numericUpDownRot";
            this.numericUpDownRot.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRot.TabIndex = 1;
            this.numericUpDownRot.ValueChanged += new System.EventHandler(this.NumericUpDownRot_ValueChanged);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 38);
            this.label11.TabIndex = 0;
            this.label11.Text = "Rotation";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.numericUpDownPosY);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 97);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(297, 38);
            this.panel4.TabIndex = 3;
            // 
            // numericUpDownPosY
            // 
            this.numericUpDownPosY.DecimalPlaces = 2;
            this.numericUpDownPosY.Location = new System.Drawing.Point(154, 6);
            this.numericUpDownPosY.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPosY.Minimum = new decimal(new int[] {
            65535,
            0,
            0,
            -2147483648});
            this.numericUpDownPosY.Name = "numericUpDownPosY";
            this.numericUpDownPosY.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPosY.TabIndex = 1;
            this.numericUpDownPosY.ValueChanged += new System.EventHandler(this.NumericUpDownPosY_ValueChanged);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 38);
            this.label10.TabIndex = 0;
            this.label10.Text = "PosY";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numericUpDownPosX);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(297, 38);
            this.panel3.TabIndex = 2;
            // 
            // numericUpDownPosX
            // 
            this.numericUpDownPosX.DecimalPlaces = 2;
            this.numericUpDownPosX.Location = new System.Drawing.Point(154, 6);
            this.numericUpDownPosX.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPosX.Minimum = new decimal(new int[] {
            65535,
            0,
            0,
            -2147483648});
            this.numericUpDownPosX.Name = "numericUpDownPosX";
            this.numericUpDownPosX.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPosX.TabIndex = 1;
            this.numericUpDownPosX.ValueChanged += new System.EventHandler(this.NumericUpDownPosX_ValueChanged);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 38);
            this.label9.TabIndex = 0;
            this.label9.Text = "PosX";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericUpDownType);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 38);
            this.panel2.TabIndex = 1;
            // 
            // numericUpDownType
            // 
            this.numericUpDownType.Location = new System.Drawing.Point(154, 6);
            this.numericUpDownType.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownType.Minimum = new decimal(new int[] {
            65535,
            0,
            0,
            -2147483648});
            this.numericUpDownType.Name = "numericUpDownType";
            this.numericUpDownType.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownType.TabIndex = 1;
            this.numericUpDownType.ValueChanged += new System.EventHandler(this.NumericUpDownType_ValueChanged);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 38);
            this.label8.TabIndex = 0;
            this.label8.Text = "Type";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxMMM
            // 
            this.comboBoxMMM.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxMMM.FormattingEnabled = true;
            this.comboBoxMMM.Location = new System.Drawing.Point(0, 0);
            this.comboBoxMMM.Name = "comboBoxMMM";
            this.comboBoxMMM.Size = new System.Drawing.Size(297, 21);
            this.comboBoxMMM.TabIndex = 0;
            this.comboBoxMMM.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMMM_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSaveChange);
            this.panel1.Controls.Add(this.comboBoxMapName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxMapId);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 33);
            this.panel1.TabIndex = 1;
            // 
            // buttonSaveChange
            // 
            this.buttonSaveChange.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonSaveChange.Enabled = false;
            this.buttonSaveChange.Location = new System.Drawing.Point(649, 0);
            this.buttonSaveChange.Name = "buttonSaveChange";
            this.buttonSaveChange.Size = new System.Drawing.Size(113, 33);
            this.buttonSaveChange.TabIndex = 9;
            this.buttonSaveChange.Text = "Save change";
            this.buttonSaveChange.UseVisualStyleBackColor = true;
            this.buttonSaveChange.Click += new System.EventHandler(this.ButtonSaveChange_Click);
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 505);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelLanguage.ResumeLayout(false);
            this.panelLanguage.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMapInfo.ResumeLayout(false);
            this.panelMapContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMapPreview)).EndInit();
            this.panelMMMInfo.ResumeLayout(false);
            this.panelMMMInfo.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRot)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosY)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosX)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownType)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxMapName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxMapId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBoxMapPreview;
        private System.Windows.Forms.Panel panelMapContainer;
        private System.Windows.Forms.Panel panelMMMInfo;
        private System.Windows.Forms.Panel panelMapInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBoxMMM;
        private System.Windows.Forms.NumericUpDown numericUpDownType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown numericUpDownPosX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxCondition;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown numericUpDownRot;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown numericUpDownPosY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonOpenCondition;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Button buttonSaveChange;
    }
}

