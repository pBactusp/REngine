namespace REngine
{
    partial class Control_ShaderList
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
            this.components = new System.ComponentModel.Container();
            this.shaderLIBO = new System.Windows.Forms.ListBox();
            this.listCOMEST = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lombertianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lombertianFacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lombertianWithTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalMapFacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distancemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solidColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.removeBU = new System.Windows.Forms.Button();
            this.listCOMEST.SuspendLayout();
            this.SuspendLayout();
            // 
            // shaderLIBO
            // 
            this.shaderLIBO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shaderLIBO.ContextMenuStrip = this.listCOMEST;
            this.shaderLIBO.FormattingEnabled = true;
            this.shaderLIBO.Location = new System.Drawing.Point(3, 16);
            this.shaderLIBO.Name = "shaderLIBO";
            this.shaderLIBO.Size = new System.Drawing.Size(157, 134);
            this.shaderLIBO.TabIndex = 0;
            // 
            // listCOMEST
            // 
            this.listCOMEST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lombertianToolStripMenuItem,
            this.lombertianFacesToolStripMenuItem,
            this.lombertianWithTextureToolStripMenuItem,
            this.normalMapToolStripMenuItem,
            this.normalMapFacesToolStripMenuItem,
            this.distancemapToolStripMenuItem,
            this.outlineToolStripMenuItem,
            this.solidColorToolStripMenuItem});
            this.listCOMEST.Name = "listCOMEST";
            this.listCOMEST.Size = new System.Drawing.Size(203, 180);
            // 
            // lombertianToolStripMenuItem
            // 
            this.lombertianToolStripMenuItem.Name = "lombertianToolStripMenuItem";
            this.lombertianToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.lombertianToolStripMenuItem.Text = "Lombertian";
            this.lombertianToolStripMenuItem.Click += new System.EventHandler(this.lombertianToolStripMenuItem_Click);
            // 
            // lombertianFacesToolStripMenuItem
            // 
            this.lombertianFacesToolStripMenuItem.Name = "lombertianFacesToolStripMenuItem";
            this.lombertianFacesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.lombertianFacesToolStripMenuItem.Text = "Lombertian Faces";
            this.lombertianFacesToolStripMenuItem.Click += new System.EventHandler(this.lombertianFacesToolStripMenuItem_Click);
            // 
            // lombertianWithTextureToolStripMenuItem
            // 
            this.lombertianWithTextureToolStripMenuItem.Name = "lombertianWithTextureToolStripMenuItem";
            this.lombertianWithTextureToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.lombertianWithTextureToolStripMenuItem.Text = "Lombertian With texture";
            this.lombertianWithTextureToolStripMenuItem.Click += new System.EventHandler(this.lombertianWithTextureToolStripMenuItem_Click);
            // 
            // normalMapToolStripMenuItem
            // 
            this.normalMapToolStripMenuItem.Name = "normalMapToolStripMenuItem";
            this.normalMapToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.normalMapToolStripMenuItem.Text = "NormalMap";
            this.normalMapToolStripMenuItem.Click += new System.EventHandler(this.normalMapToolStripMenuItem_Click);
            // 
            // normalMapFacesToolStripMenuItem
            // 
            this.normalMapFacesToolStripMenuItem.Name = "normalMapFacesToolStripMenuItem";
            this.normalMapFacesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.normalMapFacesToolStripMenuItem.Text = "NormalMap Faces";
            this.normalMapFacesToolStripMenuItem.Click += new System.EventHandler(this.normalMapFacesToolStripMenuItem_Click);
            // 
            // distancemapToolStripMenuItem
            // 
            this.distancemapToolStripMenuItem.Name = "distancemapToolStripMenuItem";
            this.distancemapToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.distancemapToolStripMenuItem.Text = "Distancemap";
            this.distancemapToolStripMenuItem.Click += new System.EventHandler(this.distancemapToolStripMenuItem_Click);
            // 
            // outlineToolStripMenuItem
            // 
            this.outlineToolStripMenuItem.Name = "outlineToolStripMenuItem";
            this.outlineToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.outlineToolStripMenuItem.Text = "Outline";
            this.outlineToolStripMenuItem.Click += new System.EventHandler(this.outlineToolStripMenuItem_Click);
            // 
            // solidColorToolStripMenuItem
            // 
            this.solidColorToolStripMenuItem.Name = "solidColorToolStripMenuItem";
            this.solidColorToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.solidColorToolStripMenuItem.Text = "Solid Color";
            this.solidColorToolStripMenuItem.Click += new System.EventHandler(this.solidColorToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shaders";
            // 
            // removeBU
            // 
            this.removeBU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeBU.Location = new System.Drawing.Point(3, 156);
            this.removeBU.Name = "removeBU";
            this.removeBU.Size = new System.Drawing.Size(75, 24);
            this.removeBU.TabIndex = 3;
            this.removeBU.Text = "Remove";
            this.removeBU.UseVisualStyleBackColor = true;
            this.removeBU.Click += new System.EventHandler(this.removeBU_Click);
            // 
            // Control_ShaderList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.removeBU);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shaderLIBO);
            this.Name = "Control_ShaderList";
            this.Size = new System.Drawing.Size(163, 183);
            this.listCOMEST.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox shaderLIBO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button removeBU;
        private System.Windows.Forms.ContextMenuStrip listCOMEST;
        private System.Windows.Forms.ToolStripMenuItem lombertianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lombertianWithTextureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solidColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lombertianFacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalMapFacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distancemapToolStripMenuItem;
    }
}
