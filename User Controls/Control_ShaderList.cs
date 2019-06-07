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
    public partial class Control_ShaderList : UserControl
    {
        List<Shader> Shaders = new List<Shader>();

        public event EventHandler Shaders_Changed = delegate { };


        public Control_ShaderList()
        {
            InitializeComponent();
        }


        public void Set_Value(List<Shader> value)
        {
            Shaders = value;
            foreach (Shader shader in Shaders)
                shaderLIBO.Items.Add(shader.Name);



        }


        private void removeBU_Click(object sender, EventArgs e)
        {
            if (shaderLIBO.SelectedIndex >= 0)
            {
                Shaders.RemoveAt(shaderLIBO.SelectedIndex);
                shaderLIBO.Items.RemoveAt(shaderLIBO.SelectedIndex);

                Shaders_Changed(Shaders, EventArgs.Empty);
            }
        }

        private void lombertianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shaders.Add(new Shader_Lombertian());
            shaderLIBO.Items.Add(Shaders[Shaders.Count - 1]);
            Shaders_Changed(Shaders, EventArgs.Empty);
        }
        private void normalMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shaders.Add(new Shader_Normalmap());
            shaderLIBO.Items.Add(Shaders[Shaders.Count - 1]);
            Shaders_Changed(Shaders, EventArgs.Empty);
        }
        private void outlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shaders.Add(new Shader_Outline());
            shaderLIBO.Items.Add(Shaders[Shaders.Count - 1]);
            Shaders_Changed(Shaders, EventArgs.Empty);
        }
        private void lombertianWithTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shaders.Add(new Shader_Lombertian_ProjectTexture());
            shaderLIBO.Items.Add(Shaders[Shaders.Count - 1]);
            Shaders_Changed(Shaders, EventArgs.Empty);
        }
        private void solidColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shaders.Add(new Shader_Color());
            shaderLIBO.Items.Add(Shaders[Shaders.Count - 1]);
            Shaders_Changed(Shaders, EventArgs.Empty);
        }
        private void lombertianFacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shaders.Add(new Shader_Lombertian_Faces());
            shaderLIBO.Items.Add(Shaders[Shaders.Count - 1]);
            Shaders_Changed(Shaders, EventArgs.Empty);
        }
        private void normalMapFacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shaders.Add(new Shader_Normalmap_Faces());
            shaderLIBO.Items.Add(Shaders[Shaders.Count - 1]);
            Shaders_Changed(Shaders, EventArgs.Empty);
        }
        private void distancemapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shaders.Add(new Shader_Distancemap());
            shaderLIBO.Items.Add(Shaders[Shaders.Count - 1]);
            Shaders_Changed(Shaders, EventArgs.Empty);
        }
    }
}
