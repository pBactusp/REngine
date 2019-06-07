namespace REngine
{
    partial class NoiseGenerationWindow
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
            this.displayPIBO = new System.Windows.Forms.PictureBox();
            this.heightNUPDO = new System.Windows.Forms.NumericUpDown();
            this.widthNUPDO = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.frequencyNUPDO = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.selectBU = new System.Windows.Forms.Button();
            this.cancelBU = new System.Windows.Forms.Button();
            this.generateBU = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.displayPIBO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNUPDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNUPDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNUPDO)).BeginInit();
            this.SuspendLayout();
            // 
            // displayPIBO
            // 
            this.displayPIBO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.displayPIBO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.displayPIBO.Location = new System.Drawing.Point(335, 12);
            this.displayPIBO.Name = "displayPIBO";
            this.displayPIBO.Size = new System.Drawing.Size(317, 309);
            this.displayPIBO.TabIndex = 0;
            this.displayPIBO.TabStop = false;
            // 
            // heightNUPDO
            // 
            this.heightNUPDO.Location = new System.Drawing.Point(83, 48);
            this.heightNUPDO.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.heightNUPDO.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNUPDO.Name = "heightNUPDO";
            this.heightNUPDO.Size = new System.Drawing.Size(65, 20);
            this.heightNUPDO.TabIndex = 1;
            this.heightNUPDO.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // widthNUPDO
            // 
            this.widthNUPDO.Location = new System.Drawing.Point(12, 48);
            this.widthNUPDO.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.widthNUPDO.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNUPDO.Name = "widthNUPDO";
            this.widthNUPDO.Size = new System.Drawing.Size(65, 20);
            this.widthNUPDO.TabIndex = 2;
            this.widthNUPDO.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Height:";
            // 
            // frequencyNUPDO
            // 
            this.frequencyNUPDO.Location = new System.Drawing.Point(12, 91);
            this.frequencyNUPDO.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.frequencyNUPDO.Name = "frequencyNUPDO";
            this.frequencyNUPDO.Size = new System.Drawing.Size(136, 20);
            this.frequencyNUPDO.TabIndex = 6;
            this.frequencyNUPDO.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Frequency:";
            // 
            // selectBU
            // 
            this.selectBU.Location = new System.Drawing.Point(12, 298);
            this.selectBU.Name = "selectBU";
            this.selectBU.Size = new System.Drawing.Size(75, 23);
            this.selectBU.TabIndex = 8;
            this.selectBU.Text = "Select";
            this.selectBU.UseVisualStyleBackColor = true;
            this.selectBU.Click += new System.EventHandler(this.selectBU_Click);
            // 
            // cancelBU
            // 
            this.cancelBU.Location = new System.Drawing.Point(254, 298);
            this.cancelBU.Name = "cancelBU";
            this.cancelBU.Size = new System.Drawing.Size(75, 23);
            this.cancelBU.TabIndex = 9;
            this.cancelBU.Text = "Cancel";
            this.cancelBU.UseVisualStyleBackColor = true;
            this.cancelBU.Click += new System.EventHandler(this.cancelBU_Click);
            // 
            // generateBU
            // 
            this.generateBU.Location = new System.Drawing.Point(12, 117);
            this.generateBU.Name = "generateBU";
            this.generateBU.Size = new System.Drawing.Size(136, 82);
            this.generateBU.TabIndex = 10;
            this.generateBU.Text = "Generate";
            this.generateBU.UseVisualStyleBackColor = true;
            this.generateBU.Click += new System.EventHandler(this.generateBU_Click);
            // 
            // NoiseGenerationWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(664, 333);
            this.ControlBox = false;
            this.Controls.Add(this.generateBU);
            this.Controls.Add(this.cancelBU);
            this.Controls.Add(this.selectBU);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.frequencyNUPDO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.widthNUPDO);
            this.Controls.Add(this.heightNUPDO);
            this.Controls.Add(this.displayPIBO);
            this.Name = "NoiseGenerationWindow";
            this.Text = "NoiseGenerationWindow";
            ((System.ComponentModel.ISupportInitialize)(this.displayPIBO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNUPDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNUPDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNUPDO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox displayPIBO;
        private System.Windows.Forms.NumericUpDown heightNUPDO;
        private System.Windows.Forms.NumericUpDown widthNUPDO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown frequencyNUPDO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button selectBU;
        private System.Windows.Forms.Button cancelBU;
        private System.Windows.Forms.Button generateBU;
    }
}