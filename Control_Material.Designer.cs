namespace REngine
{
    partial class Control_Material
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
            this.mainGRUBO = new System.Windows.Forms.GroupBox();
            this.shadercvSHACVLI = new REngine.Control_ShaderColorVertexList();
            this.shadersSHALI = new REngine.Control_ShaderList();
            this.colorCOCO = new REngine.Control_Color();
            this.mainGRUBO.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainGRUBO
            // 
            this.mainGRUBO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGRUBO.Controls.Add(this.shadercvSHACVLI);
            this.mainGRUBO.Controls.Add(this.shadersSHALI);
            this.mainGRUBO.Controls.Add(this.colorCOCO);
            this.mainGRUBO.Location = new System.Drawing.Point(3, 3);
            this.mainGRUBO.Name = "mainGRUBO";
            this.mainGRUBO.Size = new System.Drawing.Size(175, 317);
            this.mainGRUBO.TabIndex = 0;
            this.mainGRUBO.TabStop = false;
            this.mainGRUBO.Text = "Material";
            // 
            // shadercvSHACVLI
            // 
            this.shadercvSHACVLI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shadercvSHACVLI.Location = new System.Drawing.Point(6, 183);
            this.shadercvSHACVLI.Name = "shadercvSHACVLI";
            this.shadercvSHACVLI.Size = new System.Drawing.Size(163, 128);
            this.shadercvSHACVLI.TabIndex = 2;
            this.shadercvSHACVLI.ShaderCVs_Changed += new System.EventHandler(this.shadercvSHACVLI_ShaderCVs_Changed);
            // 
            // shadersSHALI
            // 
            this.shadersSHALI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shadersSHALI.Location = new System.Drawing.Point(6, 46);
            this.shadersSHALI.Name = "shadersSHALI";
            this.shadersSHALI.Size = new System.Drawing.Size(163, 131);
            this.shadersSHALI.TabIndex = 1;
            this.shadersSHALI.Shaders_Changed += new System.EventHandler(this.shadersSHALI_Shaders_Changed);
            // 
            // colorCOCO
            // 
            this.colorCOCO.Location = new System.Drawing.Point(6, 19);
            this.colorCOCO.Name = "colorCOCO";
            this.colorCOCO.Size = new System.Drawing.Size(58, 21);
            this.colorCOCO.TabIndex = 0;
            this.colorCOCO.Color_Changed += new System.EventHandler(this.colorCOCO_Color_Changed);
            // 
            // Control_Material
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainGRUBO);
            this.Name = "Control_Material";
            this.Size = new System.Drawing.Size(184, 323);
            this.mainGRUBO.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox mainGRUBO;
        private Control_Color colorCOCO;
        private Control_ShaderList shadersSHALI;
        private Control_ShaderColorVertexList shadercvSHACVLI;
    }
}
