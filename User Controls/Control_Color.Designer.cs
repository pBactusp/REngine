namespace REngine
{
    partial class Control_Color
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
            this.colorLA = new System.Windows.Forms.Label();
            this.colorPIBO = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.colorPIBO)).BeginInit();
            this.SuspendLayout();
            // 
            // colorLA
            // 
            this.colorLA.AutoSize = true;
            this.colorLA.Location = new System.Drawing.Point(3, 4);
            this.colorLA.Name = "colorLA";
            this.colorLA.Size = new System.Drawing.Size(31, 13);
            this.colorLA.TabIndex = 0;
            this.colorLA.Text = "Color";
            // 
            // colorPIBO
            // 
            this.colorPIBO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPIBO.Location = new System.Drawing.Point(40, 3);
            this.colorPIBO.Name = "colorPIBO";
            this.colorPIBO.Size = new System.Drawing.Size(15, 15);
            this.colorPIBO.TabIndex = 1;
            this.colorPIBO.TabStop = false;
            this.colorPIBO.Click += new System.EventHandler(this.colorPIBO_Click);
            // 
            // Control_Color
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.colorPIBO);
            this.Controls.Add(this.colorLA);
            this.Name = "Control_Color";
            this.Size = new System.Drawing.Size(58, 21);
            ((System.ComponentModel.ISupportInitialize)(this.colorPIBO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label colorLA;
        private System.Windows.Forms.PictureBox colorPIBO;
    }
}
