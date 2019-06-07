namespace REngine
{
    partial class Control_Transform
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
            this.posLA = new System.Windows.Forms.Label();
            this.rotLA = new System.Windows.Forms.Label();
            this.scaLA = new System.Windows.Forms.Label();
            this.mainGROBU = new System.Windows.Forms.GroupBox();
            this.posCOVE = new REngine.Control_Vector3();
            this.scaCOVE = new REngine.Control_Vector3();
            this.rotCOVE = new REngine.Control_Vector3();
            this.mainGROBU.SuspendLayout();
            this.SuspendLayout();
            // 
            // posLA
            // 
            this.posLA.AutoSize = true;
            this.posLA.Location = new System.Drawing.Point(6, 16);
            this.posLA.Name = "posLA";
            this.posLA.Size = new System.Drawing.Size(44, 13);
            this.posLA.TabIndex = 1;
            this.posLA.Text = "Position";
            // 
            // rotLA
            // 
            this.rotLA.AutoSize = true;
            this.rotLA.Location = new System.Drawing.Point(6, 66);
            this.rotLA.Name = "rotLA";
            this.rotLA.Size = new System.Drawing.Size(47, 13);
            this.rotLA.TabIndex = 3;
            this.rotLA.Text = "Rotation";
            // 
            // scaLA
            // 
            this.scaLA.AutoSize = true;
            this.scaLA.Location = new System.Drawing.Point(6, 116);
            this.scaLA.Name = "scaLA";
            this.scaLA.Size = new System.Drawing.Size(34, 13);
            this.scaLA.TabIndex = 5;
            this.scaLA.Text = "Scale";
            // 
            // mainGROBU
            // 
            this.mainGROBU.Controls.Add(this.posLA);
            this.mainGROBU.Controls.Add(this.scaLA);
            this.mainGROBU.Controls.Add(this.posCOVE);
            this.mainGROBU.Controls.Add(this.scaCOVE);
            this.mainGROBU.Controls.Add(this.rotCOVE);
            this.mainGROBU.Controls.Add(this.rotLA);
            this.mainGROBU.Location = new System.Drawing.Point(5, 4);
            this.mainGROBU.Name = "mainGROBU";
            this.mainGROBU.Size = new System.Drawing.Size(306, 167);
            this.mainGROBU.TabIndex = 6;
            this.mainGROBU.TabStop = false;
            this.mainGROBU.Text = "Transform";
            // 
            // posCOVE
            // 
            this.posCOVE.Location = new System.Drawing.Point(9, 32);
            this.posCOVE.Name = "posCOVE";
            this.posCOVE.Size = new System.Drawing.Size(291, 31);
            this.posCOVE.TabIndex = 0;
            // 
            // scaCOVE
            // 
            this.scaCOVE.Location = new System.Drawing.Point(9, 132);
            this.scaCOVE.Name = "scaCOVE";
            this.scaCOVE.Size = new System.Drawing.Size(291, 31);
            this.scaCOVE.TabIndex = 4;
            // 
            // rotCOVE
            // 
            this.rotCOVE.Location = new System.Drawing.Point(9, 82);
            this.rotCOVE.Name = "rotCOVE";
            this.rotCOVE.Size = new System.Drawing.Size(291, 31);
            this.rotCOVE.TabIndex = 2;
            // 
            // Control_Transform
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.mainGROBU);
            this.Name = "Control_Transform";
            this.Size = new System.Drawing.Size(317, 174);
            this.mainGROBU.ResumeLayout(false);
            this.mainGROBU.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Control_Vector3 posCOVE;
        private System.Windows.Forms.Label posLA;
        private System.Windows.Forms.Label rotLA;
        private Control_Vector3 rotCOVE;
        private System.Windows.Forms.Label scaLA;
        private Control_Vector3 scaCOVE;
        private System.Windows.Forms.GroupBox mainGROBU;
    }
}
