namespace REngine
{
    partial class FunctionInputWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.inputCOBO = new System.Windows.Forms.ComboBox();
            this.selectBU = new System.Windows.Forms.Button();
            this.cancelBU = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Z =";
            // 
            // inputCOBO
            // 
            this.inputCOBO.FormattingEnabled = true;
            this.inputCOBO.Items.AddRange(new object[] {
            "sin(x) + cos(y)",
            "sin(x) * cos(y)",
            "sin(x^2 + y^2)",
            "1-abs(x+y)-abs(y-x)"});
            this.inputCOBO.Location = new System.Drawing.Point(41, 6);
            this.inputCOBO.Name = "inputCOBO";
            this.inputCOBO.Size = new System.Drawing.Size(218, 21);
            this.inputCOBO.TabIndex = 1;
            // 
            // selectBU
            // 
            this.selectBU.Location = new System.Drawing.Point(12, 44);
            this.selectBU.Name = "selectBU";
            this.selectBU.Size = new System.Drawing.Size(75, 23);
            this.selectBU.TabIndex = 2;
            this.selectBU.Text = "Select";
            this.selectBU.UseVisualStyleBackColor = true;
            this.selectBU.Click += new System.EventHandler(this.selectBU_Click);
            // 
            // cancelBU
            // 
            this.cancelBU.Location = new System.Drawing.Point(184, 44);
            this.cancelBU.Name = "cancelBU";
            this.cancelBU.Size = new System.Drawing.Size(75, 23);
            this.cancelBU.TabIndex = 3;
            this.cancelBU.Text = "Cancel";
            this.cancelBU.UseVisualStyleBackColor = true;
            this.cancelBU.Click += new System.EventHandler(this.cancelBU_Click);
            // 
            // FunctionInputWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(271, 79);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBU);
            this.Controls.Add(this.selectBU);
            this.Controls.Add(this.inputCOBO);
            this.Controls.Add(this.label1);
            this.Name = "FunctionInputWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter a function";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox inputCOBO;
        private System.Windows.Forms.Button selectBU;
        private System.Windows.Forms.Button cancelBU;
    }
}