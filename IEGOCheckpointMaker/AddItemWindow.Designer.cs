namespace IEGOCheckpointMaker
{
    partial class AddItemWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPhase = new System.Windows.Forms.Panel();
            this.comboBoxPhaseText = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPhaseNumber = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonAddNewOne = new System.Windows.Forms.Button();
            this.buttonOpenCondition = new System.Windows.Forms.Button();
            this.textBoxCondition = new System.Windows.Forms.TextBox();
            this.panelPhase.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRot)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosY)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosX)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownType)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPhase
            // 
            this.panelPhase.Controls.Add(this.buttonOpenCondition);
            this.panelPhase.Controls.Add(this.comboBoxPhaseText);
            this.panelPhase.Controls.Add(this.label4);
            this.panelPhase.Controls.Add(this.comboBoxPhaseNumber);
            this.panelPhase.Controls.Add(this.label3);
            this.panelPhase.Controls.Add(this.label2);
            this.panelPhase.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPhase.Location = new System.Drawing.Point(0, 0);
            this.panelPhase.Name = "panelPhase";
            this.panelPhase.Size = new System.Drawing.Size(782, 33);
            this.panelPhase.TabIndex = 1;
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
            // panel5
            // 
            this.panel5.Controls.Add(this.numericUpDownRot);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 167);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(782, 38);
            this.panel5.TabIndex = 10;
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
            this.panel4.Location = new System.Drawing.Point(0, 129);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(782, 38);
            this.panel4.TabIndex = 9;
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
            this.panel3.Location = new System.Drawing.Point(0, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(782, 38);
            this.panel3.TabIndex = 8;
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
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 38);
            this.panel2.TabIndex = 7;
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
            // buttonInsert
            // 
            this.buttonInsert.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonInsert.Location = new System.Drawing.Point(0, 205);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(782, 23);
            this.buttonInsert.TabIndex = 12;
            this.buttonInsert.Text = "Insert";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.ButtonInsert_Click);
            // 
            // buttonAddNewOne
            // 
            this.buttonAddNewOne.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddNewOne.Location = new System.Drawing.Point(0, 228);
            this.buttonAddNewOne.Name = "buttonAddNewOne";
            this.buttonAddNewOne.Size = new System.Drawing.Size(782, 23);
            this.buttonAddNewOne.TabIndex = 13;
            this.buttonAddNewOne.Text = "Add new one";
            this.buttonAddNewOne.UseVisualStyleBackColor = true;
            this.buttonAddNewOne.Click += new System.EventHandler(this.ButtonAddNewOne_Click);
            // 
            // buttonOpenCondition
            // 
            this.buttonOpenCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonOpenCondition.Location = new System.Drawing.Point(649, 0);
            this.buttonOpenCondition.Name = "buttonOpenCondition";
            this.buttonOpenCondition.Size = new System.Drawing.Size(133, 23);
            this.buttonOpenCondition.TabIndex = 8;
            this.buttonOpenCondition.Text = "Open Condition";
            this.buttonOpenCondition.UseVisualStyleBackColor = true;
            this.buttonOpenCondition.Click += new System.EventHandler(this.ButtonOpenCondition_Click);
            // 
            // textBoxCondition
            // 
            this.textBoxCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxCondition.Location = new System.Drawing.Point(0, 33);
            this.textBoxCondition.Name = "textBoxCondition";
            this.textBoxCondition.Size = new System.Drawing.Size(782, 20);
            this.textBoxCondition.TabIndex = 14;
            // 
            // AddItemWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 369);
            this.Controls.Add(this.buttonAddNewOne);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBoxCondition);
            this.Controls.Add(this.panelPhase);
            this.Name = "AddItemWindow";
            this.Text = "AddItemWindow";
            this.panelPhase.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRot)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosY)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosX)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPhase;
        private System.Windows.Forms.ComboBox comboBoxPhaseText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPhaseNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown numericUpDownRot;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown numericUpDownPosY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown numericUpDownPosX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDownType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonAddNewOne;
        private System.Windows.Forms.Button buttonOpenCondition;
        private System.Windows.Forms.TextBox textBoxCondition;
    }
}