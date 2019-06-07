namespace REngine
{
    partial class Control_Float
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
            this.nameLA = new System.Windows.Forms.Label();
            this.valueTEBO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nameLA
            // 
            this.nameLA.AutoSize = true;
            this.nameLA.Location = new System.Drawing.Point(3, 6);
            this.nameLA.Name = "nameLA";
            this.nameLA.Size = new System.Drawing.Size(35, 13);
            this.nameLA.TabIndex = 0;
            this.nameLA.Text = "label1";
            // 
            // valueTEBO
            // 
            this.valueTEBO.Location = new System.Drawing.Point(44, 3);
            this.valueTEBO.Name = "valueTEBO";
            this.valueTEBO.Size = new System.Drawing.Size(48, 20);
            this.valueTEBO.TabIndex = 1;
            // 
            // Control_Float
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valueTEBO);
            this.Controls.Add(this.nameLA);
            this.Name = "Control_Float";
            this.Size = new System.Drawing.Size(95, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLA;
        private System.Windows.Forms.TextBox valueTEBO;
    }
}
