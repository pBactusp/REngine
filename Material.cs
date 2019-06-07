using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace REngine
{
    public class Material : REProperty
    {
        public Color Color;
        public List<Shader> Shaders;
        public List<Shader_Color_Vertex> Shaders_Color_Vertex;
        public Bitmap Texture;
        public float Texture_Scale = (float)1 / (float)50;

        public event EventHandler Color_Changed = delegate { };
        public event EventHandler Shaders_Changed = delegate { };


        public Material(Color color)
        {
            Color = color;
            Texture = new Bitmap(RE.Tiles);
            Shaders = new List<Shader>();
            Shaders_Color_Vertex = new List<Shader_Color_Vertex>();

            Control = new Control_Material(this);

            ((Control_Material)Control).Color_Changed += Color_Changed;
            ((Control_Material)Control).Shaders_Changed += Shaders_Changed;
        }
        public Material(Material material)
        {
            Color = material.Color;
            Texture = new Bitmap(material.Texture);
            Shaders = new List<Shader>(material.Shaders);
            Shaders_Color_Vertex = new List<Shader_Color_Vertex>(material.Shaders_Color_Vertex);

            Control = new Control_Material(this);

            ((Control_Material)Control).Color_Changed += Color_Changed;
            ((Control_Material)Control).Shaders_Changed += Shaders_Changed;
        }


        public override void Reshape(int width, int height)
        {
            ((Control_Material)Control).Reshape(width, height);
        }

    }


    public class Shader
    {
        public string Name;
        public virtual void Calculate(int x, int y) { }
    }


    public class Shader_Lombertian : Shader
    {
        public Shader_Lombertian()
        {
            Name = "Lombertian";
        }

        public override void Calculate(int x, int y)
        {
            Color ret = Color.Black;
            Vector3 tempV = new Vector3(0);

            for (int i = 0; i < RE.fdBuffer.Faces[x, y].Lights.Count; i++)
            {
                tempV.Set(1);

                //if (RE.fdBuffer.Faces[x, y].Lights[i].Ambient)
                //    tempV *= RE.fdBuffer.Faces[x, y].Lights[i].Intensity / RE.fdBuffer.Faces[x, y].LightsDistance[i];
                //else
                //    tempV *= -Vector3.Dot(RE.fdBuffer.Faces[x, y].Lights[i].Rotation_Vector, RE.fdBuffer.Normals[x, y]) * RE.fdBuffer.Faces[x, y].Lights[i].Intensity / RE.fdBuffer.Faces[x, y].LightsDistance[i];
                tempV *= -Vector3.Dot(RE.fdBuffer.Faces[x, y].Lights[i].Rotation_Vector, RE.fdBuffer.Normals[x, y]) * RE.fdBuffer.Faces[x, y].Lights[i].Properties.Intensity / RE.fdBuffer.Faces[x, y].LightsDistance[i];


                ret += RE.fdBuffer.Faces[x, y].Parent.Material.Color * tempV;
            }

            ret += new Vector3(RE.World_Light_Intensity);

            RE.Frame.SetPixel(x, RE.Frame.Height - 1 - y, ret);
        }
    }
    public class Shader_Lombertian_Faces : Shader
    {
        public Shader_Lombertian_Faces()
        {
            Name = "Lombertian";
        }

        public override void Calculate(int x, int y)
        {
            Color ret = Color.Black;
            Vector3 tempV = new Vector3(0);

            for (int i = 0; i < RE.fdBuffer.Faces[x, y].Lights.Count; i++)
            {
                tempV.Set(1);

                //if (RE.fdBuffer.Faces[x, y].Lights[i].Ambient)
                //    tempV *= RE.fdBuffer.Faces[x, y].Lights[i].Intensity;
                //else
                //    tempV *= -Vector3.Dot(RE.fdBuffer.Faces[x, y].Lights[i].Rotation_Vector, RE.fdBuffer.Faces[x, y].Normal) * RE.fdBuffer.Faces[x, y].Lights[i].Intensity / RE.fdBuffer.Faces[x, y].LightsDistance[i];
                tempV *= -Vector3.Dot(RE.fdBuffer.Faces[x, y].Lights[i].Rotation_Vector, RE.fdBuffer.Faces[x, y].Normal) * RE.fdBuffer.Faces[x, y].Lights[i].Properties.Intensity / RE.fdBuffer.Faces[x, y].LightsDistance[i];

                ret += RE.fdBuffer.Faces[x, y].Parent.Material.Color * tempV;
            }

            ret += new Vector3(RE.World_Light_Intensity);

            RE.Frame.SetPixel(x, RE.Frame.Height - 1 - y, ret);
        }
    }

    public class Shader_Lombertian_ProjectTexture : Shader
    {
        public Shader_Lombertian_ProjectTexture()
        {
            Name = "Lombertian";
        }

        public override void Calculate(int x, int y)
        {
            Material material = RE.fdBuffer.Faces[x, y].Parent.Material;

            Color ret = Color.Black;
            Vector3 tempV = new Vector3(0);
            for (int i = 0; i < RE.fdBuffer.Faces[x, y].Lights.Count; i++)
            {
                tempV.Set(1);

                if (RE.fdBuffer.Faces[x, y].Lights[i].Properties.Ambient)
                    tempV *= RE.fdBuffer.Faces[x, y].Lights[i].Properties.Intensity;
                else
                    tempV *= -Vector3.Dot(RE.fdBuffer.Faces[x, y].Lights[i].Rotation_Vector, RE.fdBuffer.Normals[x, y]) * RE.fdBuffer.Faces[x, y].Lights[i].Properties.Intensity / RE.fdBuffer.Faces[x, y].LightsDistance[i];

                ret += material.Texture.GetPixel((int)(((float)material.Texture_Scale * RE.fdBuffer.Texels[x, y].X) % (material.Texture.Width - 1)), (int)((float)(material.Texture_Scale * RE.fdBuffer.Texels[x, y].Y) % (material.Texture.Height - 1))) * tempV;
            }

            ret += new Vector3(RE.World_Light_Intensity);

            RE.Frame.SetPixel(x, RE.Frame.Height - y, ret);
        }
    }

    public class Shader_Normalmap : Shader
    {
        public Shader_Normalmap()
        {
            Name = "Normalmap";
        }

        public override void Calculate(int x, int y)
        {
            RE.Frame.SetPixel(x, RE.Frame.Height - 1 - y, new Vector3(255 * (RE.fdBuffer.Normals[x, y] + 1) / 2).Get_Color());
        }

    }
    public class Shader_Normalmap_Faces : Shader
    {
        public Shader_Normalmap_Faces()
        {
            Name = "Normalmap";
        }

        public override void Calculate(int x, int y)
        {
            RE.Frame.SetPixel(x, RE.Frame.Height - 1 - y, new Vector3(255 * (RE.fdBuffer.Faces[x, y].Normal + 1) / 2).Get_Color());
        }

    }
    public class Shader_Distancemap : Shader
    {
        public Shader_Distancemap()
        {
            Name = "Normalmap";
        }

        public override void Calculate(int x, int y)
        {
            RE.Frame.SetPixel(x, RE.Frame.Height - 1 - y, new Vector3(RE.fdBuffer.Distances[x, y] * 20).Get_Color());
        }

    }

    public class Shader_Outline : Shader
    {
        public Color BorderColor = Color.Red;

        public Shader_Outline()
        {
            Name = "Outline";
        }

        public override void Calculate(int x, int y)
        {
            bool hasEdge = false;
            if (x > 0 && (RE.fdBuffer.Faces[x - 1, y] == null || RE.fdBuffer.Faces[x, y].Parent != RE.fdBuffer.Faces[x - 1, y].Parent))
            {
                RE.Frame.SetPixel(x - 1, RE.Frame.Height - y, BorderColor);
                hasEdge = true;
            }

            else if (x < RE.Frame.Width - 1 && (RE.fdBuffer.Faces[x + 1, y] == null || RE.fdBuffer.Faces[x, y].Parent != RE.fdBuffer.Faces[x + 1, y].Parent))
            {
                RE.Frame.SetPixel(x + 1, RE.Frame.Height - y, BorderColor);
                hasEdge = true;
            }

            else if (y > 0 && (RE.fdBuffer.Faces[x, y - 1] == null || RE.fdBuffer.Faces[x, y].Parent != RE.fdBuffer.Faces[x, y - 1].Parent))
            {
                RE.Frame.SetPixel(x, RE.Frame.Height - y + 1, BorderColor);
                hasEdge = true;
            }

            else if (y < RE.Frame.Height - 1 && (RE.fdBuffer.Faces[x, y + 1] == null || RE.fdBuffer.Faces[x, y].Parent != RE.fdBuffer.Faces[x, y + 1].Parent))
            {
                RE.Frame.SetPixel(x, RE.Frame.Height - y - 1, BorderColor);
                hasEdge = true;
            }

            if (hasEdge)
                RE.Frame.SetPixel(x, RE.Frame.Height - y, BorderColor);

        }
    }
    public class Shader_Color : Shader
    {
        public Shader_Color()
        {
            Name = "Color";
        }

        public override void Calculate(int x, int y)
        {
            RE.Frame.SetPixel(x, RE.Frame.Height - 1 - y, RE.fdBuffer.Faces[x, y].Parent.Material.Color);
        }

    }



    public class Shader_Color_Vertex
    {
        public string Name;
        public virtual void Calculate(int x, int y) { }
    }

    public class Shader_vColor : Shader_Color_Vertex
    {
        public Color Vertex_Color = Color.Pink;
        public Size Square_Size = new Size(5, 5);
        public Shader_vColor()
        {
            Name = "Color";
        }

        public override void Calculate(int x, int y)
        {
            for (int i = y - Square_Size.Height / 2; i < y + Square_Size.Height / 2; i++)
                if (i >= 0 && i <= RE.fdBuffer.Size.Height - 1)
                    for (int g = x - Square_Size.Height / 2; g < x + Square_Size.Height / 2; g++)
                        if (g >= 0 && g <= RE.fdBuffer.Size.Width - 1)
                            RE.Frame.SetPixel(g, RE.Frame.Height - 1 - i, Vertex_Color);
        }


    }


}
