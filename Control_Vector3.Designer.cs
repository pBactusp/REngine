namespace REngine
{
    partial class Control_Vector3
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
            this.xFLCO = new REngine.Control_Float();
            this.yFLCO = new REngine.Control_Float();
            this.zFLCO = new REngine.Control_Float();
            this.SuspendLayout();
            // 
            // xFLCO
            // 
            this.xFLCO.Location = new System.Drawing.Point(0, 0);
            this.xFLCO.Name = "xFLCO";
            this.xFLCO.Size = new System.Drawing.Size(95, 26);
            this.xFLCO.TabIndex = 0;
            // 
            // yFLCO
            // 
            this.yFLCO.Location = new System.Drawing.Point(101, 0);
            this.yFLCO.Name = "yFLCO";
            this.yFLCO.Size = new System.Drawing.Size(95, 26);
            this.yFLCO.TabIndex = 1;
            // 
            // zFLCO
            // 
            this.zFLCO.Location = new System.Drawing.Point(201, 0);
            this.zFLCO.Name = "zFLCO";
            this.zFLCO.Size = new System.Drawing.Size(95, 26);
            this.zFLCO.TabIndex = 2;
            // 
            // Control_Vector3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.zFLCO);
            this.Controls.Add(this.yFLCO);
            this.Controls.Add(this.xFLCO);
            this.Name = "Control_Vector3";
            this.Size = new System.Drawing.Size(299, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private Control_Float xFLCO;
        private Control_Float yFLCO;
        private Control_Float zFLCO;
    }
}
