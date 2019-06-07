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
    public partial class Control_Material : UserControl
    {
        Material Material;

        public event EventHandler Color_Changed = delegate { };
        public event EventHandler Shaders_Changed = delegate { };
        public event EventHandler ShaderCVs_Changed = delegate { };


        public Control_Material()
        {
            InitializeComponent();
        }
        public Control_Material(Material value)
        {
            InitializeComponent();


            Material = value;
            colorCOCO.Set_Value(Material.Color);

            shadersSHALI.Set_Value(Material.Shaders);
            shadercvSHACVLI.Set_Value(Material.Shaders_Color_Vertex);
        }


        public void Reshape(int width, int height)
        {
            Size = new Size(width, height);
            mainGRUBO.Size = new Size(width, height);
        }

        private void colorCOCO_Color_Changed(object sender, EventArgs e)
        {
            Material.Color = (Color)sender;
            Color_Changed(sender, e);
        }

        private void shadersSHALI_Shaders_Changed(object sender, EventArgs e)
        {
            Shaders_Changed(sender, e);
        }

        private void shadercvSHACVLI_ShaderCVs_Changed(object sender, EventArgs e)
        {
            ShaderCVs_Changed(sender, e);
        }
    }
}
