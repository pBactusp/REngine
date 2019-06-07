using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace REngine
{
    /////////////////////// R-Engine
    public static class RE
    {
        public static Color Empty_Color = Color.FromArgb(255, 200, 200, 200);
        public static Material Default_Material;
        public static float World_Light_Intensity = 0;
        public static Color World_Light_Color
        {
            get { return Color.FromArgb(255, (int)World_Light_Intensity, (int)World_Light_Intensity, (int)World_Light_Intensity); }
        }



        public static Bitmap Tiles = new Bitmap(@"D:\C#\REngine\Textures\Tiles 50X50.png");

        public static Shader_Lombertian Default_Lombertian = new Shader_Lombertian();
        public static Shader_Normalmap Default_Normalmap = new Shader_Normalmap();
        public static Shader_Outline Default_Outline = new Shader_Outline();
        public static Shader_Color Default_Color = new Shader_Color();


        public static Mesh LightMesh;


        public static void Initialize()
        {
            Default_Material = new Material(Color.White);

            //LightMesh = Mesh_Import(@"D:\C#\REngine\Models\LightArrow.obj");
            LightMesh = Mesh_Import(@"LightArrow.obj");

            LightMesh.Material = new Material(Color.Yellow);
            LightMesh.Add_Shaders(new Shader_Normalmap());
            LightMesh.IsLightMesh = true;
        }



        public static Bitmap ScaleToFit(Bitmap bitmap, Size targetSize)
        {
            float scaleFactor = Math.Min((float)targetSize.Width / (float)bitmap.Width, (float)targetSize.Height / (float)bitmap.Height);

            return new Bitmap(bitmap, new Size((int)(bitmap.Width * scaleFactor), (int)(bitmap.Height * scaleFactor)));
        }


        public static void Render(Camera camera, Scene scene, Mesh mesh)
        {
            camera.Render(scene, mesh);
        }


        public static float GetDistance2(float x1, float y1, float x2, float y2)
        {
            return Convert.ToSingle(Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        }
        public static float GetDistance2(Vector3 a, Vector3 b)
        {
            return Convert.ToSingle(Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2)));
        }

        public static float Lerp(float f1, float f2, float weight)
        {
            return f1 * weight + f2 * (1 - weight);
            //return f1 * factor + f2 * (1 - factor);
        }
        public static float Interpolate_Linear(float f1, float f2, float factor)
        {
            return f1 + (f2 - f1) * factor;
            //return f1 * factor + f2 * (1 - factor);
        }
        public static float Interpolate_Sin(float f1, float f2, float factor)
        {
            return (float)(f1 * Math.Sin(factor * Math.PI / 2 + Math.PI / 2) + f2 * Math.Sin((1 - factor) * Math.PI / 2 + Math.PI / 2));
            //return (float)(f1 + (f2 - f1) * Math.Sin(factor * Math.PI / 2));
        }
        public static float Interpolate_Cos(float f1, float f2, float factor)
        {
            return (float)(f1 * Math.Sin(factor * Math.PI / 2) + f2 * Math.Sin((1 - factor) * Math.PI / 2));
        }

        public static float EaseCurve_Perlin(float t)
        {
            //return 3 * t * t - 2 * t * t * t;
            return t * t * t * (t * (t * 6 - 15) + 10);
        }
        public static float EaseCurve_Sin(float t)
        {
            return (float)Math.Sin(t * Math.PI / 2);
        }


        public static bool IsContained(float x, float y, Size size)
        {
            if (x >= 0 && x < size.Width
                && y >= 0 && y < size.Height)
                return true;

            return false;
        }


        public static Bitmap Array_To_Bitmap(float[,] arr)
        {
            Bitmap ret = new Bitmap(arr.GetLength(0), arr.GetLength(1));
            int tempGSValue;
            for (int y = 0; y < ret.Height; y++)
                for (int x = 0; x < ret.Width; x++)
                {
                    tempGSValue = (int)(255 * arr[x, y]);
                    tempGSValue = tempGSValue < 0 ? 0 : tempGSValue;
                    ret.SetPixel(x, y, Color.FromArgb(255, tempGSValue, tempGSValue, tempGSValue));
                }

            return ret;
        }


        public static Mesh Mesh_Import(string objPath)
        {
            Mesh ret = new Mesh(Path.GetFileNameWithoutExtension(objPath));

            string tempString = "  ";
            string[] tempPoints = new string[3];
            int[] tempPoints_int = new int[3];
            Face tempFace;

            using (StreamReader sr = new StreamReader(objPath))
            {
                while (tempString[0] != 'v')
                    tempString = sr.ReadLine();

                while (tempString[0] == 'v' && tempString[1] == ' ')
                {
                    tempPoints = tempString.Substring(2).Split(' ');

                    ret.Vertices.Add(new Vertex(float.Parse(tempPoints[0]), float.Parse(tempPoints[1]), float.Parse(tempPoints[2])));

                    tempString = sr.ReadLine();
                }


                while (tempString[0] != 'f')
                    tempString = sr.ReadLine();


                while (tempString != null && tempString[0] == 'f' && tempString[1] == ' ')
                {
                    tempPoints = tempString.Substring(2).Split(' ');
                    for (int i = 0; i < tempPoints.Length; i++)
                        tempPoints_int[i] = int.Parse(tempPoints[i]) - 1;

                    tempFace = new Face(ret.Vertices[tempPoints_int[0]], ret.Vertices[tempPoints_int[1]], ret.Vertices[tempPoints_int[2]]);
                    tempFace.Set_Parent(ret);

                    ret.Faces.Add(tempFace);
                    tempString = sr.ReadLine();
                }

                sr.Close();
            }


            foreach (Vertex vertex in ret.Vertices)
                vertex.Normal_Calculate();


            ret.Material = new Material(Color.White);
            //ret.Add_Shaders(new Shader_Lombertian());

            return ret;
        }
        public static Mesh Mesh_FromArray(float[,] arr, Vector3 scale)
        {
            Mesh ret = new Mesh("From array");
            int[,] vert_index = new int[arr.GetLength(0), arr.GetLength(1)];

            float xx, zz;
            for (int y = 0; y < arr.GetLength(1); y++)
                for (int x = 0; x < arr.GetLength(0); x++)
                {
                    xx = (x - arr.GetLength(0) / 2) * scale.X;
                    zz = (y - arr.GetLength(1) / 2) * scale.Z;

                    ret.Vertices.Add(new Vertex(xx, arr[x, y] * scale.Y, zz));
                    ret.Vertices[ret.Vertices.Count - 1].Texel = new Vector3(x, y, 0);
                    vert_index[x, y] = ret.Vertices.Count - 1;
                }

            for (int y = 0; y < arr.GetLength(1) - 1; y++)
                for (int x = 0; x < arr.GetLength(0) - 1; x++)
                {
                    ret.Faces.Add(new Face(ret.Vertices[vert_index[x, y]], ret.Vertices[vert_index[x, y + 1]], ret.Vertices[vert_index[x + 1, y]]));
                    ret.Faces[ret.Faces.Count - 1].Set_Parent(ret);
                    ret.Faces.Add(new Face(ret.Vertices[vert_index[x + 1, y + 1]], ret.Vertices[vert_index[x + 1, y]], ret.Vertices[vert_index[x, y + 1]]));
                    ret.Faces[ret.Faces.Count - 1].Set_Parent(ret);
                }


            foreach (Vertex vertex in ret.Vertices)
                vertex.Normal_Calculate();

            return ret;
        }

        // Shaders:
        private static FrameDataBuffer _fdBuffer;
        public static FrameDataBuffer fdBuffer { get { return _fdBuffer; } }
        public static Bitmap Frame { get { return fdBuffer.Frame; } }

        public static void Initialize_Shaders(FrameDataBuffer data)
        {
            _fdBuffer = new FrameDataBuffer(data.Size);
            _fdBuffer = data;
        }





        public static Color Shader_Lombertian(int x, int y)
        {
            Color ret = Color.Black;
            Vector3 tempV = new Vector3(0);

            for (int i = 0; i < fdBuffer.Faces[x, y].Lights.Count; i++)
            {
                tempV.Set(1);

                if (fdBuffer.Faces[x, y].Lights[i].Properties.Ambient)
                    tempV *= fdBuffer.Faces[x, y].Lights[i].Properties.Intensity;
                else
                    tempV *= - Vector3.Dot(fdBuffer.Faces[x, y].Lights[i].Rotation_Vector, fdBuffer.Normals[x, y]) * fdBuffer.Faces[x, y].Lights[i].Properties.Intensity / fdBuffer.Faces[x, y].LightsDistance[i];

                ret += fdBuffer.Faces[x, y].Parent.Material.Color * tempV;
            }

            ret += new Vector3(World_Light_Intensity);

            return ret;
        }
        public static Color Shader_NormalMap(int x, int y)
        {
            return new Vector3(255 * (fdBuffer.Normals[x, y] + 1) / 2).Get_Color();
        }
        public static void Shader_OutLine(int x, int y, Color color)
        {
            bool hasEdge = false;
            if (x > 0 && (RE.fdBuffer.Faces[x - 1, y] == null || RE.fdBuffer.Faces[x, y].Parent != RE.fdBuffer.Faces[x - 1, y].Parent))
            {
                RE.Frame.SetPixel(x - 1, RE.Frame.Height - 1 - y, color);
                hasEdge = true;
            }

            else if (x < RE.Frame.Width - 1 && (RE.fdBuffer.Faces[x + 1, y] == null || RE.fdBuffer.Faces[x, y].Parent != RE.fdBuffer.Faces[x + 1, y].Parent))
            {
                RE.Frame.SetPixel(x + 1, RE.Frame.Height - 1 - y, color);
                hasEdge = true;
            }

            else if (y > 0 && (RE.fdBuffer.Faces[x, y - 1] == null || RE.fdBuffer.Faces[x, y].Parent != RE.fdBuffer.Faces[x, y - 1].Parent))
            {
                RE.Frame.SetPixel(x, RE.Frame.Height - 1 - y, color);
                hasEdge = true;
            }

            else if (y < RE.Frame.Height - 1 && (RE.fdBuffer.Faces[x, y + 1] == null || RE.fdBuffer.Faces[x, y].Parent != RE.fdBuffer.Faces[x, y + 1].Parent))
            {
                RE.Frame.SetPixel(x, RE.Frame.Height - 1 - y, color);
                hasEdge = true;
            }

            if (hasEdge)
                RE.Frame.SetPixel(x, RE.Frame.Height - 1 - y, color);
        }



    }


}
