namespace REngine
{
    partial class Control_Light
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainGRBO = new System.Windows.Forms.GroupBox();
            this.colorCOCO = new REngine.Control_Color();
            this.label1 = new System.Windows.Forms.Label();
            this.intensityNUPDO = new System.Windows.Forms.NumericUpDown();
            this.visibleCHEBO = new System.Windows.Forms.CheckBox();
            this.ambientCHEBO = new System.Windows.Forms.CheckBox();
            this.mainGRBO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intensityNUPDO)).BeginInit();
            this.SuspendLayout();
            // 
            // mainGRBO
            // 
            this.mainGRBO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGRBO.Controls.Add(this.ambientCHEBO);
            this.mainGRBO.Controls.Add(this.visibleCHEBO);
            this.mainGRBO.Controls.Add(this.colorCOCO);
            this.mainGRBO.Controls.Add(this.label1);
            this.mainGRBO.Controls.Add(this.intensityNUPDO);
            this.mainGRBO.Location = new System.Drawing.Point(3, 3);
            this.mainGRBO.Name = "mainGRBO";
            this.mainGRBO.Size = new System.Drawing.Size(140, 130);
            this.mainGRBO.TabIndex = 0;
            this.mainGRBO.TabStop = false;
            this.mainGRBO.Text = "Light";
            // 
            // colorCOCO
            // 
            this.colorCOCO.Location = new System.Drawing.Point(6, 81);
            this.colorCOCO.Name = "colorCOCO";
            this.colorCOCO.Size = new System.Drawing.Size(58, 21);
            this.colorCOCO.TabIndex = 2;
            this.colorCOCO.Color_Changed += new System.EventHandler(this.colorCOCO_Color_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Intensity";
            // 
            // intensityNUPDO
            // 
            this.intensityNUPDO.DecimalPlaces = 3;
            this.intensityNUPDO.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.intensityNUPDO.Location = new System.Drawing.Point(6, 55);
            this.intensityNUPDO.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.intensityNUPDO.Name = "intensityNUPDO";
            this.intensityNUPDO.Size = new System.Drawing.Size(96, 20);
            this.intensityNUPDO.TabIndex = 0;
            this.intensityNUPDO.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intensityNUPDO.ValueChanged += new System.EventHandler(this.intensityNUPDO_ValueChanged);
            // 
            // visibleCHEBO
            // 
            this.visibleCHEBO.AutoSize = true;
            this.visibleCHEBO.Checked = true;
            this.visibleCHEBO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.visibleCHEBO.Location = new System.Drawing.Point(6, 19);
            this.visibleCHEBO.Name = "visibleCHEBO";
            this.visibleCHEBO.Size = new System.Drawing.Size(56, 17);
            this.visibleCHEBO.TabIndex = 3;
            this.visibleCHEBO.Text = "Visible";
            this.visibleCHEBO.UseVisualStyleBackColor = true;
            this.visibleCHEBO.CheckedChanged += new System.EventHandler(this.visibleCHEBO_CheckedChanged);
            // 
            // ambientCHEBO
            // 
            this.ambientCHEBO.AutoSize = true;
            this.ambientCHEBO.Location = new System.Drawing.Point(6, 108);
            this.ambientCHEBO.Name = "ambientCHEBO";
            this.ambientCHEBO.Size = new System.Drawing.Size(64, 17);
            this.ambientCHEBO.TabIndex = 4;
            this.ambientCHEBO.Text = "Ambient";
            this.ambientCHEBO.UseVisualStyleBackColor = true;
            this.ambientCHEBO.CheckedChanged += new System.EventHandler(this.ambientCHEBO_CheckedChanged);
            // 
            // Control_Light
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.mainGRBO);
            this.Name = "Control_Light";
            this.Size = new System.Drawing.Size(146, 136);
            this.mainGRBO.ResumeLayout(false);
            this.mainGRBO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intensityNUPDO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox mainGRBO;
        private Control_Color colorCOCO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown intensityNUPDO;
        private System.Windows.Forms.CheckBox ambientCHEBO;
        private System.Windows.Forms.CheckBox visibleCHEBO;
    }
}
