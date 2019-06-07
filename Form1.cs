using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace REngine
{
    public partial class Form1 : Form
    {
        List<Scene> scenes;
        Scene scene_Selected;
        Camera camera_Selected;
        Mesh mesh_Selected;
        Light light_Selected;

        int offset_w = 0,
            offset_h = 0;


        public Form1()
        {
            InitializeComponent();
            RE.Initialize();

            displayPB.BackgroundImage = new Bitmap(displayPB.Width, displayPB.Height);

            propPRLI.Value_Changed += PropPRLI_Value_Changed;


            //RE.World_Light_Intensity = 100;

            scenes = new List<Scene>();
            scenes.Add(new Scene("Main"));
            scene_Selected = scenes[0];

            int tempMin = Math.Min(displayPB.Size.Width, displayPB.Size.Height);
            scene_Selected.Cameras.Add(new Camera(new Vector3(0, 0, 5), new Vector3(0, 90, 0), new Size(tempMin, tempMin), 45, 45)); //new Size(displayPB.Size.Width * 2, displayPB.Size.Height * 2), 45, 45));
            camera_Selected = scene_Selected.Cameras[0];
            RE.Initialize_Shaders(camera_Selected.fdBuffer);
            camera_Selected.LookAt(new Vector3(0, 0, 0));

            light_Selected = new Light(new Size(4000, 4000), new Vector3(-10, 0, 0), new Vector3(0, 0, 0), 15, 70, true);
            scene_Selected.Lights.Add(light_Selected);
            light_Selected.LookAt(new Vector3(0, 0, 0));


            //light_Selected = new Light(new Size(2000, 2000), new Vector3(-10, 5, 5), new Vector3(0, 0, 0), 1, 80, true, 200);
            //scene_Selected.Lights.Add(light_Selected);
            //light_Selected.LookAt(new Vector3(0, 0, 0));


            //scene_Selected.Lights[1].LookAt(new Vector3(0, 0, 0));

            //camera_Selected.Render(scene_Selected);


            displayPB.MouseWheel += DisplayPB_MouseWheel;

        }



        private void DisplayPB_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                camera_Selected.Zoom(1);
            else if (e.Delta < 0)
                camera_Selected.Zoom(-1);

            Render();
        }

        private void PropPRLI_Value_Changed(object sender, EventArgs e)
        {
            Render();
        }

        private void Render()
        {
            RE.Render(camera_Selected, scene_Selected, mesh_Selected);

            Bitmap tempBitmap = RE.ScaleToFit(RE.Frame, displayPB.Size);

            displayPB.BackgroundImage = tempBitmap; // RE.ScaleToFit(RE.Frame, displayPB.Size);
            offset_w = (displayPB.Width - tempBitmap.Width) / 2;
            offset_h = (displayPB.Height - tempBitmap.Height) / 2;

            displayPB.Refresh();

            //MessageBox.Show("Rendering has completed");
        }


        private void renderBU_Click(object sender, EventArgs e)
        {
            Render();
        }

        private void importBU_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = @"D:\C#\REngine\Models";
            fd.ShowDialog();

            if (File.Exists(fd.FileName))
            {
                mesh_Selected = RE.Mesh_Import(fd.FileName);
                scene_Selected.Meshes.Add(mesh_Selected);
                propPRLI.FromMesh(mesh_Selected);
                //MessageBox.Show(mesh_Selected.Name + " has been imported.");
            }

        }
        private void fromFuncBU_Click(object sender, EventArgs e)
        {
            FunctionInputWindow fiw = new FunctionInputWindow();
            fiw.ShowDialog();

            if (fiw.func != "")
            {
                //mesh_Selected = new Mesh(fiw.Mesh);
                scene_Selected.Meshes.Add(fiw.GetMesh());
                mesh_Selected = scene_Selected.Meshes[scene_Selected.Meshes.Count - 1];
                propPRLI.FromMesh(mesh_Selected);
            }

        }
        private void fromNoiseBU_Click(object sender, EventArgs e)
        {
            NoiseGenerationWindow ngw = new NoiseGenerationWindow();
            ngw.ShowDialog();

            if (ngw.HasNoise)
            {
                mesh_Selected = RE.Mesh_FromArray(ngw.NoiseMap, new Vector3(0.1f, 2f, 0.1f));
                scene_Selected.Meshes.Add(mesh_Selected);
                propPRLI.FromMesh(mesh_Selected);
            }
        }

        private void removeBU_Click(object sender, EventArgs e)
        {
            scene_Selected.Meshes.Remove(mesh_Selected);
            if (scene_Selected.Meshes.Count > 0)
            {
                mesh_Selected = scene_Selected.Meshes[scene_Selected.Meshes.Count - 1];
                propPRLI.FromMesh(mesh_Selected);
            }
            else
            {
                mesh_Selected = null;
                propPRLI.Clear();
            }

            Render();
        }

        Point prevMouseLocation = new Point(0, 0);
        private void displayPB_MouseMove(object sender, MouseEventArgs e)
        {
            int changeX,
                changeY;
            if (e.Button == MouseButtons.Middle)
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    if (e.X > prevMouseLocation.X)
                        changeX = 1;
                    else if (e.X < prevMouseLocation.X)
                        changeX = -1;
                    else
                        changeX = 0;
                    if (e.Y > prevMouseLocation.Y)
                        changeY = 1;
                    else if (e.Y < prevMouseLocation.Y)
                        changeY = -1;
                    else
                        changeY = 0;

                    camera_Selected.Move(changeX, changeY);
                    Render();
                }

                //camera_Selected.Rotate_X(e.Y - prevMouseLocation.Y);
                //camera_Selected.Rotation_Vector.Rotate_Y(prevMouseLocation.X - e.X);

                //Render();
            }

            prevMouseLocation = new Point(e.X, e.Y);
        }


        private void displayPB_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int tempX = e.X - offset_w,
                    tempY = RE.fdBuffer.Size.Height - e.Y - 1 + offset_h;

                if (tempX > 0 && tempY > 0)
                {
                    if (RE.fdBuffer.Faces[tempX, tempY] != null)
                    {
                        if (RE.fdBuffer.Faces[tempX, tempY].Parent != mesh_Selected)
                        {
                            if (RE.fdBuffer.Faces[tempX, tempY].Parent_Light != null)
                            {
                                mesh_Selected = RE.fdBuffer.Faces[tempX, tempY].Parent;
                                light_Selected = RE.fdBuffer.Faces[tempX, tempY].Parent_Light.Parent;
                                propPRLI.FromLight(light_Selected);
                            }
                            else
                            {
                                mesh_Selected = RE.fdBuffer.Faces[tempX, tempY].Parent;
                                propPRLI.FromMesh(mesh_Selected);
                            }


                            //Render();
                        }

                    }
                }

            }



        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            int tempMin = Math.Min(displayPB.Size.Width, displayPB.Size.Height);
            camera_Selected.Set_Resolution(new Size(tempMin, tempMin));

            RE.Initialize_Shaders(camera_Selected.fdBuffer);

            Render();
        }


    }


}
