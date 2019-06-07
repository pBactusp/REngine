namespace REngine
{
    partial class Control_ShaderColorVertexList
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
            this.label1 = new System.Windows.Forms.Label();
            this.shadercvLIBO = new System.Windows.Forms.ListBox();
            this.removeBU = new System.Windows.Forms.Button();
            this.listCOMEST = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listCOMEST.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shaders _Color_Vertex";
            // 
            // shadercvLIBO
            // 
            this.shadercvLIBO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shadercvLIBO.ContextMenuStrip = this.listCOMEST;
            this.shadercvLIBO.FormattingEnabled = true;
            this.shadercvLIBO.Location = new System.Drawing.Point(3, 16);
            this.shadercvLIBO.Name = "shadercvLIBO";
            this.shadercvLIBO.Size = new System.Drawing.Size(173, 108);
            this.shadercvLIBO.TabIndex = 1;
            // 
            // removeBU
            // 
            this.removeBU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeBU.Location = new System.Drawing.Point(3, 133);
            this.removeBU.Name = "removeBU";
            this.removeBU.Size = new System.Drawing.Size(68, 26);
            this.removeBU.TabIndex = 2;
            this.removeBU.Text = "Remove";
            this.removeBU.UseVisualStyleBackColor = true;
            this.removeBU.Click += new System.EventHandler(this.removeBU_Click);
            // 
            // listCOMEST
            // 
            this.listCOMEST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem});
            this.listCOMEST.Name = "listCOMEST";
            this.listCOMEST.Size = new System.Drawing.Size(104, 26);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // Control_ShaderColorVertexList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.removeBU);
            this.Controls.Add(this.shadercvLIBO);
            this.Controls.Add(this.label1);
            this.Name = "Control_ShaderColorVertexList";
            this.Size = new System.Drawing.Size(179, 162);
            this.listCOMEST.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox shadercvLIBO;
        private System.Windows.Forms.Button removeBU;
        private System.Windows.Forms.ContextMenuStrip listCOMEST;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
    }
}
