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
    public partial class Control_Transform : UserControl
    {
        Transform Value;

        public Control_Transform()
        {
            InitializeComponent();
        }
        public Control_Transform(Transform value)
        {
            InitializeComponent();


            Value = value;
            

            posCOVE.Set_Value(Value.Position);
            rotCOVE.Set_Value(Value.Rotation);
            scaCOVE.Set_Value(Value.Scale);

            posCOVE.Value_Changed += Position_Changed;
            rotCOVE.Value_Changed += Rotation_Changed;
            scaCOVE.Value_Changed += Scale_Changed;
        }

        private void Position_Changed(object sender, EventArgs e)
        {
            Value.Position = posCOVE.Value;
        }
        private void Rotation_Changed(object sender, EventArgs e)
        {
            Value.Rotation = rotCOVE.Value;
        }
        private void Scale_Changed(object sender, EventArgs e)
        {
            Value.Scale = scaCOVE.Value;
        }


        public void Reshape(int width, int height)
        {
            Size = new Size(width, height);
            mainGROBU.Size = new Size(width, height);

            int yOffset = 15;
            int ySize = (mainGROBU.Height - yOffset) / 3,
                xSize = (mainGROBU.Width - 4) / 3;


            posLA.Location = new Point(2, yOffset);
            posCOVE.Location = new Point(2, yOffset + (int)(ySize * 0.5));
            rotLA.Location = new Point(2, yOffset + ySize);
            rotCOVE.Location = new Point(2, yOffset + (int)(ySize * 1.5));
            scaLA.Location = new Point(2, yOffset + ySize * 2);
            scaCOVE.Location = new Point(2, yOffset + (int)(ySize * 2.5));

            posCOVE.Reshape(mainGROBU.Width, ySize / 2);//(width - 4) / 3, xSize);
            rotCOVE.Reshape(mainGROBU.Width, ySize / 2);//(width - 4) / 3, xSize);
            scaCOVE.Reshape(mainGROBU.Width, ySize / 2);//(width - 4) / 3, xSize);
            Refresh();
        }
    }
}
