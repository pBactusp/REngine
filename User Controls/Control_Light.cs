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
    public partial class Control_Light : UserControl
    {
        Light_Properties Light_Properties;

        public event EventHandler Visibility_Changed = delegate { };
        public event EventHandler Intensity_Changed = delegate { };
        public event EventHandler Color_Changed = delegate { };
        public event EventHandler Ambience_Changed = delegate { };


        public Control_Light()
        {
            InitializeComponent();
        }


        public void Set_Value(Light_Properties value)
        {
            Light_Properties = value;

            visibleCHEBO.Checked = Light_Properties.Visible;
            intensityNUPDO.Value = (decimal)Light_Properties.Intensity;
            colorCOCO.Color = Light_Properties.Color;
            ambientCHEBO.Checked = Light_Properties.Ambient;
        }

        private void visibleCHEBO_CheckedChanged(object sender, EventArgs e)
        {
            Light_Properties.Visible = visibleCHEBO.Checked;
            Visibility_Changed(Light_Properties.Visible, EventArgs.Empty);
        }
        private void intensityNUPDO_ValueChanged(object sender, EventArgs e)
        {
            Light_Properties.Intensity = (float)intensityNUPDO.Value;
            Intensity_Changed(Light_Properties.Intensity, EventArgs.Empty);
        }
        private void colorCOCO_Color_Changed(object sender, EventArgs e)
        {
            Light_Properties.Color = colorCOCO.Color;
            Color_Changed(Light_Properties.Color, EventArgs.Empty);
        }
        private void ambientCHEBO_CheckedChanged(object sender, EventArgs e)
        {
            Light_Properties.Ambient = ambientCHEBO.Checked;
            Ambience_Changed(Light_Properties.Ambient, EventArgs.Empty);
        }
    }
}
