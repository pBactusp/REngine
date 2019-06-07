namespace REngine
{
    partial class TransformControl
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
            this.SuspendLayout();
            // 
            // mainGRBO
            // 
            this.mainGRBO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGRBO.Location = new System.Drawing.Point(3, 3);
            this.mainGRBO.Name = "mainGRBO";
            this.mainGRBO.Size = new System.Drawing.Size(172, 198);
            this.mainGRBO.TabIndex = 0;
            this.mainGRBO.TabStop = false;
            this.mainGRBO.Text = "Transform";
            // 
            // TransformControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainGRBO);
            this.Name = "TransformControl";
            this.Size = new System.Drawing.Size(178, 204);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox mainGRBO;
    }
}
