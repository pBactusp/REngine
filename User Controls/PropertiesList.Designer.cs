namespace REngine
{
    partial class PropertiesList
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
            this.mainPA = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mainPA
            // 
            this.mainPA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPA.AutoScroll = true;
            this.mainPA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPA.Location = new System.Drawing.Point(3, 3);
            this.mainPA.Name = "mainPA";
            this.mainPA.Size = new System.Drawing.Size(97, 83);
            this.mainPA.TabIndex = 0;
            // 
            // PropertiesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPA);
            this.Name = "PropertiesList";
            this.Size = new System.Drawing.Size(103, 89);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPA;
    }
}
