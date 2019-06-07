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
    public partial class PropertiesList : UserControl
    {
        public event EventHandler Value_Changed = delegate { };


        public PropertiesList()
        {
            InitializeComponent();
        }


        private void Add_Property(REProperty property)
        {
            int y = mainPA.Controls.Count > 0 ? mainPA.Controls[mainPA.Controls.Count - 1].Location.Y + mainPA.Controls[mainPA.Controls.Count - 1].Height : 0;
            property.Control.Location = new Point(0, y + 4);
            //property.Control.Size = new Size(Width, 171);

            property.Reshape(mainPA.Width - 19, property.Control.Height);

            mainPA.Controls.Add(property.Control);
        }


        public void FromMesh(Mesh mesh)
        {
            Clear();

            Add_Property(mesh.Transform);
            Add_Property(mesh.Material);

            Value_Changed(null, EventArgs.Empty);
        }
        public void FromLight(Light light)
        {
            Clear();

            Add_Property(light.Transform);
            Add_Property(light.Properties);

            Value_Changed(null, EventArgs.Empty);
        }



        public void Clear()
        {
            mainPA.Controls.Clear();
        }
    }
}
