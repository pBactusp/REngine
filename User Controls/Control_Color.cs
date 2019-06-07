using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace REngine
{
    public partial class Control_Color : UserControl
    {
        public Color Color;


        public event EventHandler Color_Changed = delegate { };


        public Control_Color()
        {
            InitializeComponent();
        }

        public void Set_Value(Color value)
        {
            Color = value;
            colorPIBO.BackColor = Color;
        }


        private void colorPIBO_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            Color = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
            colorPIBO.BackColor = Color;

            Color_Changed(Color, EventArgs.Empty);
        }


        public void Reshape(int width, int height)
        {
            ///////
        }

    }
}
