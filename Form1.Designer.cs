namespace REngine
{
    partial class Form1
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
            this.displayPB = new System.Windows.Forms.PictureBox();
            this.renderBU = new System.Windows.Forms.Button();
            this.importBU = new System.Windows.Forms.Button();
            this.fromFuncBU = new System.Windows.Forms.Button();
            this.propPRLI = new REngine.PropertiesList();
            this.fromNoiseBU = new System.Windows.Forms.Button();
            this.removeBU = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.displayPB)).BeginInit();
            this.SuspendLayout();
            // 
            // displayPB
            // 
            this.displayPB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayPB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.displayPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.displayPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.displayPB.Location = new System.Drawing.Point(136, 85);
            this.displayPB.Name = "displayPB";
            this.displayPB.Size = new System.Drawing.Size(477, 353);
            this.displayPB.TabIndex = 0;
            this.displayPB.TabStop = false;
            this.displayPB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.displayPB_MouseClick);
            this.displayPB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.displayPB_MouseMove);
            // 
            // renderBU
            // 
            this.renderBU.Location = new System.Drawing.Point(12, 13);
            this.renderBU.Name = "renderBU";
            this.renderBU.Size = new System.Drawing.Size(118, 66);
            this.renderBU.TabIndex = 1;
            this.renderBU.Text = "Render";
            this.renderBU.UseVisualStyleBackColor = true;
            this.renderBU.Click += new System.EventHandler(this.renderBU_Click);
            // 
            // importBU
            // 
            this.importBU.Location = new System.Drawing.Point(12, 85);
            this.importBU.Name = "importBU";
            this.importBU.Size = new System.Drawing.Size(118, 56);
            this.importBU.TabIndex = 2;
            this.importBU.Text = "Import";
            this.importBU.UseVisualStyleBackColor = true;
            this.importBU.Click += new System.EventHandler(this.importBU_Click);
            // 
            // fromFuncBU
            // 
            this.fromFuncBU.Location = new System.Drawing.Point(12, 147);
            this.fromFuncBU.Name = "fromFuncBU";
            this.fromFuncBU.Size = new System.Drawing.Size(118, 56);
            this.fromFuncBU.TabIndex = 4;
            this.fromFuncBU.Text = "From function";
            this.fromFuncBU.UseVisualStyleBackColor = true;
            this.fromFuncBU.Click += new System.EventHandler(this.fromFuncBU_Click);
            // 
            // propPRLI
            // 
            this.propPRLI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propPRLI.Location = new System.Drawing.Point(619, 13);
            this.propPRLI.Name = "propPRLI";
            this.propPRLI.Size = new System.Drawing.Size(264, 425);
            this.propPRLI.TabIndex = 3;
            // 
            // fromNoiseBU
            // 
            this.fromNoiseBU.Location = new System.Drawing.Point(12, 209);
            this.fromNoiseBU.Name = "fromNoiseBU";
            this.fromNoiseBU.Size = new System.Drawing.Size(118, 56);
            this.fromNoiseBU.TabIndex = 5;
            this.fromNoiseBU.Text = "From noise";
            this.fromNoiseBU.UseVisualStyleBackColor = true;
            this.fromNoiseBU.Click += new System.EventHandler(this.fromNoiseBU_Click);
            // 
            // removeBU
            // 
            this.removeBU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeBU.Location = new System.Drawing.Point(12, 394);
            this.removeBU.Name = "removeBU";
            this.removeBU.Size = new System.Drawing.Size(118, 44);
            this.removeBU.TabIndex = 6;
            this.removeBU.Text = "Remove selected";
            this.removeBU.UseVisualStyleBackColor = true;
            this.removeBU.Click += new System.EventHandler(this.removeBU_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 450);
            this.Controls.Add(this.removeBU);
            this.Controls.Add(this.fromNoiseBU);
            this.Controls.Add(this.fromFuncBU);
            this.Controls.Add(this.propPRLI);
            this.Controls.Add(this.importBU);
            this.Controls.Add(this.renderBU);
            this.Controls.Add(this.displayPB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.displayPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox displayPB;
        private System.Windows.Forms.Button renderBU;
        private System.Windows.Forms.Button importBU;
        private PropertiesList propPRLI;
        private System.Windows.Forms.Button fromFuncBU;
        private System.Windows.Forms.Button fromNoiseBU;
        private System.Windows.Forms.Button removeBU;
    }
}

