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
    public partial class Control_Vector3 : UserControl
    {
        public Vector3 Value;

        public EventHandler Value_Changed = delegate { };


        public Control_Vector3()
        {
            InitializeComponent();
        }


        public void Set_Value(Vector3 value)
        {
            Value = value;

            xFLCO.Set_Value("X", Value.X);
            yFLCO.Set_Value("Y", Value.Y);
            zFLCO.Set_Value("Z", Value.Z);

            xFLCO.Text_Changed += Chiled_Changed;
            yFLCO.Text_Changed += Chiled_Changed;
            zFLCO.Text_Changed += Chiled_Changed;
        }


        private void Chiled_Changed(object sender, EventArgs e)
        {
            Value = new Vector3(xFLCO.Value, yFLCO.Value, zFLCO.Value);

            if (Value_Changed != null) Value_Changed(Value, e);
        }
        





        public void Reshape(int width, int height)
        {
            Size = new Size(width, height);
            int xSize = (width - 4) / 3;

            xFLCO.Location = new Point(0, 0);
            yFLCO.Location = new Point(xSize, 0);
            zFLCO.Location = new Point(xSize * 2, 0);

            xFLCO.Reshape((width - 4) / 3, xSize);
            yFLCO.Reshape((width - 4) / 3, xSize);
            zFLCO.Reshape((width - 4) / 3, xSize);
            Update();
        }
    }
}
