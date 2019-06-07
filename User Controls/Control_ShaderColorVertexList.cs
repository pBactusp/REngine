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
    public partial class Control_ShaderColorVertexList : UserControl
    {
        List<Shader_Color_Vertex> ShaderCVs = new List<Shader_Color_Vertex>();

        public event EventHandler ShaderCVs_Changed = delegate { };


        public Control_ShaderColorVertexList()
        {
            InitializeComponent();
        }


        public void Set_Value(List<Shader_Color_Vertex> value)
        {
            ShaderCVs = value;
            foreach (Shader_Color_Vertex shader in ShaderCVs)
                shadercvLIBO.Items.Add(shader.Name);
        }

        private void removeBU_Click(object sender, EventArgs e)
        {
            if (shadercvLIBO.SelectedIndex >= 0)
            {
                ShaderCVs.RemoveAt(shadercvLIBO.SelectedIndex);
                shadercvLIBO.Items.RemoveAt(shadercvLIBO.SelectedIndex);

                ShaderCVs_Changed(ShaderCVs, EventArgs.Empty);
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShaderCVs.Add(new Shader_vColor());
            shadercvLIBO.Items.Add(ShaderCVs[ShaderCVs.Count - 1]);
            ShaderCVs_Changed(ShaderCVs, EventArgs.Empty);
        }
    }
}
