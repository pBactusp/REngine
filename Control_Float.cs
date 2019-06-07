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
    public partial class Control_Float : UserControl
    {
        public float Value;

        public event EventHandler Text_Changed = delegate { };


        public Control_Float()
        {
            InitializeComponent();
        }
        public Control_Float(string Name, float value)
        {
            InitializeComponent();

            Value = value;
            nameLA.Text = Name;
            valueTEBO.Text = (Value).ToString();
            valueTEBO.TextChanged += ValueTEBO_TextChanged;
            Update();
        }


        public void Set_Value(string Name, float value)
        {
            Value = value;
            nameLA.Text = Name;
            valueTEBO.Text = (Value).ToString();
            valueTEBO.TextChanged += ValueTEBO_TextChanged;
            Update();
        }


        public void Reshape(int width, int height)
        {
            Size = new Size(width, height);
            int xSize = (width - 4) / 3;

            nameLA.Location = new Point(0, 0);
            valueTEBO.Location = new Point(nameLA.PreferredWidth, 0);

            //xFLCO.Reshape((width - 4) / 3, xSize);
            //yFLCO.Reshape((width - 4) / 3, xSize);
            //zFLCO.Reshape((width - 4) / 3, xSize);
        }

        private void ValueTEBO_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(((TextBox)sender).Text, out float parsed))
            {
                Value = parsed;
                if (Text_Changed != null) Text_Changed(sender, e);
            }
            else if (((TextBox)sender).Text != "" && ((TextBox)sender).Text != "-")
                ((TextBox)sender).Text = (Value).ToString();

        }




    }


}
