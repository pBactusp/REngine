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
    public partial class TransformControl : UserControl
    {
        // Propetries
        public int Padding_X = 2;
        public int Padding_Y = 2;

        // 
        Transform Transform;

        xyzLayer[] propertyLayers;


        public TransformControl(Transform transform)
        {
            InitializeComponent();

            Transform = transform;
            propertyLayers = new xyzLayer[3];

            Create_Controls();
        }


        public void Create_Controls(int width = 0)
        {
            Width = width > 0 ? width : Width;

            mainGRBO.Controls.Clear();

            int yGap = 2;
            int width_padded = mainGRBO.Width - 2 * Padding_X;
            int ySize = (mainGRBO.Height - 2 * Padding_Y - 2 * yGap) / 3;
            int y = Padding_Y;

            propertyLayers[0] = new xyzLayer("Position", Transform.Position);
            propertyLayers[0].Draw(mainGRBO, Padding_X, y, width_padded, ySize);
            propertyLayers[0].Value_Changed += _position_Value_Changed;

            y += ySize + yGap;

            propertyLayers[1] = new xyzLayer("Rotation", Transform.Rotation);
            propertyLayers[1].Draw(mainGRBO, Padding_X, y, width_padded, ySize);
            propertyLayers[1].Value_Changed += _rotation_Value_Changed;

            y += ySize + yGap;

            propertyLayers[2] = new xyzLayer("Scale", Transform.Scale);
            propertyLayers[2].Draw(mainGRBO, Padding_X, y, width_padded, ySize);
            propertyLayers[2].Value_Changed += _scale_Value_Changed;

        }


        private void _position_Value_Changed(object sender, EventArgs e)
        {
            xyzLayer _sender = (xyzLayer)sender;
            for (int i = 0; i < _sender.xyzTEBO.Length; i++)
            {
                if (float.TryParse(_sender.xyzTEBO[i].Text, out float parsed))
                    Transform.Position.Values[i] = float.Parse(_sender.xyzTEBO[i].Text);
                else if (_sender.xyzTEBO[i].Text != "")
                    _sender.xyzTEBO[i].Text = Transform.Position.Values[i].ToString();
            }

        }
        private void _rotation_Value_Changed(object sender, EventArgs e)
        {
            xyzLayer _sender = (xyzLayer)sender;
            for (int i = 0; i < _sender.xyzTEBO.Length; i++)
            {
                if (float.TryParse(_sender.xyzTEBO[i].Text, out float parsed))
                    Transform.Rotation.Values[i] = float.Parse(_sender.xyzTEBO[i].Text);
                else if (_sender.xyzTEBO[i].Text != "")
                    _sender.xyzTEBO[i].Text = Transform.Position.Values[i].ToString();
            }
        }
        private void _scale_Value_Changed(object sender, EventArgs e)
        {
            xyzLayer _sender = (xyzLayer)sender;
            for (int i = 0; i < _sender.xyzTEBO.Length; i++)
            {
                if (float.TryParse(_sender.xyzTEBO[i].Text, out float parsed))
                    Transform.Scale.Values[i] = float.Parse(_sender.xyzTEBO[i].Text);
                else if (_sender.xyzTEBO[i].Text != "")
                    _sender.xyzTEBO[i].Text = Transform.Position.Values[i].ToString();
            }
        }


        public class xyzLayer
        {
            public Label Title;
            public Label[] xyzLA;
            public TextBox[] xyzTEBO;

            public event EventHandler Value_Changed;


            public xyzLayer(string title, Vector3 values)
            {
                Title = new Label();
                Title.Text = title;

                xyzLA = new Label[3];
                xyzLA[0] = new Label() { Text = "X" };
                xyzLA[1] = new Label() { Text = "Y" };
                xyzLA[2] = new Label() { Text = "Z" };

                xyzTEBO = new TextBox[3];
                xyzTEBO[0] = new TextBox() { Text = values.X.ToString() };
                xyzTEBO[1] = new TextBox() { Text = values.Y.ToString() };
                xyzTEBO[2] = new TextBox() { Text = values.Z.ToString() };
            }


            public void Draw(Control target_control, int x, int y, int width, int height)
            {
                Title.Location = new Point(x, y);
                target_control.Controls.Add(Title);

                y += height / 2;

                int xGap = width / 3;

                for (int i = 0; i < xyzTEBO.Length; i++)
                {
                    xyzLA[i].Location = new Point(x, y);
                    xyzTEBO[i].Location = new Point(xyzLA[i].Location.X + xyzLA[i].PreferredWidth + 1, y);
                    xyzTEBO[i].TextChanged += XyzLayer_TextChanged;

                    x += xGap;

                    target_control.Update();
                    System.Threading.Thread.Sleep(500);
                }

                target_control.Controls.AddRange(xyzLA);
                target_control.Controls.AddRange(xyzTEBO);

            }

            private void XyzLayer_TextChanged(object sender, EventArgs e)
            {
                Value_Changed(this, e);
            }
        }



    }


    public class iREControl
    {
        public object Value;

    }

}
