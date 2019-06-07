using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace REngine
{
    public class Vertex : Vector3
    {
        public List<Edge> Edges;
        public List<Face> Faces;

        public Vertex ProjectedValue;

        public Vector3 Normal;
        public Vector3 Texel;

        public Vertex(Vector3 position, Vector3 normal)
        {
            this.X = position.X;
            this.Y = position.Y;
            this.Z = position.Z;

            Normal = new Vector3(normal);
            Texel = new Vector3(0);
            Edges = new List<Edge>();
            Faces = new List<Face>();
        }
        public Vertex(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;

            Normal = new Vector3();
            Texel = new Vector3(0);
            Edges = new List<Edge>();
            Faces = new List<Face>();
        }
        public Vertex(float x, float y, float z, Vector3 normal)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;

            Normal = new Vector3(normal);
            Texel = new Vector3(0);
            Edges = new List<Edge>();
            Faces = new List<Face>();
        }
        public Vertex(Vertex vertex)
        {
            this.X = vertex.X;
            this.Y = vertex.Y;
            this.Z = vertex.Z;

            Normal = new Vector3(vertex.Normal);
            Texel = new Vector3(vertex.Texel);
            Edges = new List<Edge>(vertex.Edges);
            Faces = new List<Face>(vertex.Faces);
        }


        public void Normal_Calculate()
        {
            Normal.Set(0);
            foreach (Face face in Faces)
                Normal += face.Normal;

            Normal /= Faces.Count;

            //for (int i = 0; i < Normal.Values.Length; i++)
            //    if (Normal.Values[i] < 0.000001)
            //        Normal.Values[i] = 0;
        }


        public void Rotate(Vector3 rotation, Vector3 pivotPoint)
        {
            this.X -= pivotPoint.X;
            this.Y -= pivotPoint.Y;
            this.Z -= pivotPoint.Z;

            Rotate_X(rotation.X);
            Rotate_Y(rotation.Y);
            Rotate_Z(rotation.Z);

            this.X += pivotPoint.X;
            this.Y += pivotPoint.Y;
            this.Z += pivotPoint.Z;

            //for (int i = 0; i < Values.Length; i++)
            //    if (Values[i] < 0.000001)
            //        Values[i] = 0;
        }

    }


    public class Edge
    {
        public Vertex[] Vertices;
        public Vertex v1
        {
            get { return Vertices[0]; }
            set { Vertices[0] = value; }
        }
        public Vertex v2
        {
            get { return Vertices[1]; }
            set { Vertices[1] = value; }
        }


        public List<Face> Faces;
        public Face F1
        {
            get { return Faces[0]; }
            set { Faces[0] = value; }
        }
        public Face F2
        {
            get { return Faces[1]; }
            set { Faces[1] = value; }
        }

        public Color Color;


        public Edge(params Vertex[] vertices)
        {
            Vertices = new Vertex[2];
            Faces = new List<Face>();
            for (int i = 0; i < 2; i++)
            {
                Vertices[i] = vertices[i];
                Vertices[i].Edges.Add(this);
            }

            Color = Color.Black;
        }
        public Edge(Vertex[] vertices, Face[] faces)
        {
            Vertices = new Vertex[2];
            Faces = new List<Face>(faces);

            for (int i = 0; i < 2; i++)
            {
                Vertices[i] = vertices[i];
                Vertices[i].Edges.Add(this);
            }

            Color = Color.Black;
        }
        public Edge(Edge edge)
        {
            Vertices = new Vertex[2];
            Faces = new List<Face>(edge.Faces);

            for (int i = 0; i < 2; i++)
            {
                Vertices[i] = edge.Vertices[i];
                Vertices[i].Edges.Add(this);
            }

            Color = edge.Color;
        }


    }


    public class Face
    {
        public Mesh Parent = null;
        public LightMesh Parent_Light = null;

        public Vertex[] Vertices = new Vertex[3];
        public Vertex v1
        {
            get { return Vertices[0]; }
            set { Vertices[0] = value; }
        }
        public Vertex v2
        {
            get { return Vertices[1]; }
            set { Vertices[1] = value; }
        }
        public Vertex v3
        {
            get { return Vertices[2]; }
            set { Vertices[2] = value; }
        }

        public Edge[] Edges = new Edge[3];
        public Edge E1
        {
            get { return Edges[0]; }
            set { Edges[0] = value; }
        }
        public Edge E2
        {
            get { return Edges[1]; }
            set { Edges[1] = value; }
        }
        public Edge E3
        {
            get { return Edges[2]; }
            set { Edges[2] = value; }
        }

        public Vector3 Normal;

        public List<Light> Lights;
        public List<float> LightsDistance;

        public Face(params Vertex[] vertices)
        {
            Lights = new List<Light>();
            LightsDistance = new List<float>();

            for (int i = 0; i < 3; i++)
            {
                Vertices[i] = vertices[i];
                Vertices[i].Faces.Add(this);
            }
            Set_Edges();

            Normal_Calculate();
        }

        public Face(Vertex[] vertices, Edge[] edges)
        {
            Lights = new List<Light>();
            LightsDistance = new List<float>();

            for (int i = 0; i < 3; i++)
            {
                Vertices[i] = vertices[i];
                Vertices[i].Faces.Add(this);

                Edges[i] = edges[i];
                Edges[i].Faces.Add(this);
            }


            Normal_Calculate();
        }
        public Face(Face face)
        {
            Lights = new List<Light>();
            LightsDistance = new List<float>();

            for (int i = 0; i < 3; i++)
            {
                Vertices[i] = face.Vertices[i];
                Vertices[i].Faces.Add(this);

                Edges[i] = face.Edges[i];
                Edges[i].Faces.Add(this);
            }


            Normal = new Vector3(face.Normal);
        }


        public void Set_Parent(Mesh parent)
        {
            Parent = parent;
        }
        private void Set_Edges()
        {
            bool add1 = true, add2 = true;
            foreach (Edge edge in v1.Edges)
            {
                if (edge.Vertices.Contains(v2)) add1 = false;
                if (edge.Vertices.Contains(v3)) add2 = false;
            }

            if (add1)
            {
                E1 = new Edge(v1, v2);
                E1.Faces.Add(this);
            }

            if (add2)
            {
                E2 = new Edge(v1, v3);
                E2.Faces.Add(this);
            }



            add1 = true;
            foreach (Edge edge in v2.Edges)
                if (edge.Vertices.Contains(v3)) add1 = false;

            if (add1)
            {
                E3 = new Edge(v2, v3);
                E3.Faces.Add(this);
            }

        }


        public void Add_Light(Light light, float distance)
        {
            Lights.Add(light);
            LightsDistance.Add(distance);
        }
        public void Clear_Lights()
        {
            Lights.Clear();
            LightsDistance.Clear();
        }


        public void Normal_Calculate()
        {
            Normal = new Vector3();

            Vector3 v = v2 - v1;
            Vector3 w = v3 - v1;

            Normal.X = (v.Y * w.Z) - (v.Z * w.Y);
            Normal.Y = (v.Z * w.X) - (v.X * w.Z);
            Normal.Z = (v.X * w.Y) - (v.Y * w.X);

            Normal = Vector3.Normalized(Normal);

        }


        public void Rotate(Vector3 rotation, Vector3 pivotPoint)
        {
            for (int i = 0; i < 3; i++)
                Vertices[i].Rotate(rotation, pivotPoint);
        }
        public Vector3 Get_Center()
        {
            return (v1 + v2 + v3) / 3;
        }

    }


    public class Mesh
    {
        public string Name;
        public bool Visible;
        public bool IsLightMesh;


        public List<Vertex> Vertices;
        public List<Edge> Edges;
        public List<Face> Faces;

        public Vector3 Origin;
        public Transform Transform;
        public Material Material;   ////////////////////////////////////////////////////////////////////


        public Mesh(string name = "Empty")
        {
            IsLightMesh = false;
            Name = name;
            Visible = true;

            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
            Faces = new List<Face>();

            Origin = new Vector3();

            Transform = new Transform();
            Transform.Position_Changed += Transform_Position_Changed;
            Transform.Rotation_Changed += Transform_Rotation_Changed;
            Transform.Scale_Changed += Transform_Scale_Changed;
            Material = RE.Default_Material;
        }
        public Mesh(Mesh mesh)
        {
            IsLightMesh = false;
            Name = mesh.Name;
            Visible = mesh.Visible;

            Vertices = new List<Vertex>(mesh.Vertices);
            Edges = new List<Edge>(mesh.Edges);
            Faces = new List<Face>(mesh.Faces);

            Origin = new Vector3(mesh.Origin);

            Material = new Material(mesh.Material);

            Transform = new Transform();
            Transform.Position_Changed += Transform_Position_Changed;
            Transform.Rotation_Changed += Transform_Rotation_Changed;
            Transform.Scale_Changed += Transform_Scale_Changed;

            Material = mesh.Material;
        }


        private void Transform_Position_Changed(object sender, EventArgs e)
        {
            Vector3 delta = (Vector3)sender;
            Transluce(delta);
        }
        private void Transform_Rotation_Changed(object sender, EventArgs e)
        {
            Vector3 delta = (Vector3)sender;
            Rotate(delta, Origin);
        }
        private void Transform_Scale_Changed(object sender, EventArgs e)
        {
            Vector3 delta = (Vector3)sender;
            Scale(delta, Origin);
        }





        public void Rotate(Vector3 rotation, Vector3 pivotPoint)
        {
            foreach (Vertex vertex in Vertices)
                vertex.Rotate(rotation, pivotPoint);
            foreach (Face face in Faces)
                face.Normal_Calculate();
            foreach (Vertex vertex in Vertices)
                vertex.Normal_Calculate();
        }
        public void Transluce(Vector3 translution)
        {
            Origin += translution;
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i].X += translution.X;
                Vertices[i].Y += translution.Y;
                Vertices[i].Z += translution.Z;
            }
        }
        public void Scale(Vector3 scale, Vector3 targetPoint)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i].X -= targetPoint.X;
                Vertices[i].Y -= targetPoint.Y;
                Vertices[i].Z -= targetPoint.Z;

                Vertices[i].X *= scale.X;
                Vertices[i].Y *= scale.Y;
                Vertices[i].Z *= scale.Z;

                Vertices[i].X += targetPoint.X;
                Vertices[i].Y += targetPoint.Y;
                Vertices[i].Z += targetPoint.Z;
            }
        }



        public void Add_Shaders(params Shader[] shaders)
        {
            Material.Shaders.AddRange(shaders);
        }
        public void Add_Shaders(params Shader_Color_Vertex[] shaders)
        {
            Material.Shaders_Color_Vertex.AddRange(shaders);
        }

    }



    public class LightMesh : Mesh
    {
        public Light Parent;

        public LightMesh(Mesh mesh, Light parent)
        {
            IsLightMesh = true;
            Parent = parent;
            Transform = new Transform();

            Name = mesh.Name;
            Visible = mesh.Visible;

            Vertices = new List<Vertex>(mesh.Vertices);
            Edges = new List<Edge>(mesh.Edges);
            Faces = new List<Face>(mesh.Faces);

            Origin = new Vector3(mesh.Origin);

            Material = new Material(mesh.Material);

            foreach (Face face in Faces)
            {
                face.Parent_Light = this;
            }
        }

    }

    public class Light
    {
        public Light_Properties Properties;

        public LightMesh lMesh;

        public Transform Transform;

        public Vector3 Position
        {
            get { return Transform.Position; }
            set
            {
                Transform.Position = value;
                lMesh.Transform.Position = Transform.Position;
            }
        }
        public Vector3 Rotation
        {
            get { return Transform.Rotation; }
            set
            {
                Transform.Rotation = value;

                _Rotation_Vector = new Vector3(1, 0, 0);
                _Rotation_VectorX = new Vector3(0, 0, 1);
                _Rotation_VectorY = new Vector3(0, 1, 0);
                _Rotation_Vector.Rotate(Transform.Rotation);
                _Rotation_VectorX.Rotate(Transform.Rotation);
                _Rotation_VectorY.Rotate(Transform.Rotation);



                for (int i = 0; i < _Rotation_VectorX.Values.Length; i++)
                {
                    if (Math.Abs(_Rotation_Vector.Values[i]) < 0.00001)
                        _Rotation_Vector.Values[i] = 0;
                    if (Math.Abs(_Rotation_VectorX.Values[i]) < 0.00001)
                        _Rotation_VectorX.Values[i] = 0;
                    if (Math.Abs(_Rotation_VectorY.Values[i]) < 0.00001)
                        _Rotation_VectorY.Values[i] = 0;
                }

            }
        }
        private Vector3 _Rotation_Vector;
        public Vector3 Rotation_Vector { get { return _Rotation_Vector; } }
        private Vector3 _Rotation_VectorX;
        public Vector3 Rotation_VectorX { get { return _Rotation_VectorX; } }
        private Vector3 _Rotation_VectorY;
        public Vector3 Rotation_VectorY { get { return _Rotation_VectorY; } }



        float FOV_scale;
        public float FOV
        {
            get { return Properties._FOV; }
            set
            {
                Properties._FOV = value;
                FOV_scale = (float)(2 * Math.Tan(Properties._FOV * Math.PI / 180));
            }
        }


        ShadowMap Map;


        public Light(Size resolution, bool ambient = false, float radius = 0)
        {
            Set_lMesh();

            Properties = new Light_Properties(Color.White);

            Transform = new Transform();
            Set_Transform();

            lMesh.Transform.Position = Transform.Position;
            lMesh.Transform.Rotation = Transform.Rotation;

            Map = new ShadowMap(resolution);

        }
        public Light(Size resolution, Vector3 position, Vector3 rotation, float intensity, float fov, bool ambient = false, float radius = 0)
        {
            Set_lMesh();
            lMesh.Transluce(position);
            lMesh.Rotate(rotation, lMesh.Origin);

            Properties = new Light_Properties(Color.White, true, ambient, fov, intensity);

            Transform = new Transform(position, rotation, new Vector3(1));
            Set_Transform();

            Rotation = rotation;

            FOV = fov;

            Map = new ShadowMap(resolution);
        }

        private void Set_lMesh()
        {
            lMesh = new LightMesh(RE.LightMesh, this);
            lMesh.IsLightMesh = true;
            lMesh.Material = new Material(Color.Yellow);
            lMesh.Add_Shaders(new Shader_Color());
        }
        private void Set_Transform()
        {
            Transform.Position_Changed += Transform_Position_Changed;
            Transform.Rotation_Changed += Transform_Rotation_Changed;
        }

        private void Transform_Position_Changed(object sender, EventArgs e)
        {

            Vector3 delta = (Vector3)sender;
            lMesh.Transluce(delta);
        }
        private void Transform_Rotation_Changed(object sender, EventArgs e)
        {
            Vector3 delta = (Vector3)sender;
            lMesh.Rotate(delta, lMesh.Origin);


            _Rotation_Vector = new Vector3(1, 0, 0);
            _Rotation_VectorX = new Vector3(0, 0, 1);
            _Rotation_VectorY = new Vector3(0, 1, 0);
            _Rotation_Vector.Rotate(Transform.Rotation);
            _Rotation_VectorX.Rotate(Transform.Rotation);
            _Rotation_VectorY.Rotate(Transform.Rotation);

            for (int i = 0; i < _Rotation_VectorX.Values.Length; i++)
            {
                if (Math.Abs(_Rotation_Vector.Values[i]) < 0.00001)
                    _Rotation_Vector.Values[i] = 0;
                if (Math.Abs(_Rotation_VectorX.Values[i]) < 0.00001)
                    _Rotation_VectorX.Values[i] = 0;
                if (Math.Abs(_Rotation_VectorY.Values[i]) < 0.00001)
                    _Rotation_VectorY.Values[i] = 0;
            }
        }



        public void LookAt(Vector3 target)
        {
            Vector3 vec = Vector3.Normalized(target - Position);
            Vector3 zeroedV = new Vector3(1, 0, 0);

            Vector3 rot = new Vector3(0);




            rot.Z = -(float)(Math.Atan2(vec.Y, vec.X) * 180 / Math.PI);
            for (int i = 0; i < vec.Values.Length; i++)
                vec.Values[i] = (float)Math.Round(vec.Values[i], 6);
            vec.Rotate_Z(-(float)Math.Round(rot.Z, 6));

            rot.Y = -(float)(Math.Atan2(vec.Z, vec.X) * 180 / Math.PI);
            for (int i = 0; i < vec.Values.Length; i++)
                vec.Values[i] = (float)Math.Round(vec.Values[i], 6);
            vec.Rotate_Y(-(float)Math.Round(rot.Y, 6));

            rot.X = -(float)(Math.Atan2(vec.Y, vec.Z) * 180 / Math.PI);
            for (int i = 0; i < vec.Values.Length; i++)
                vec.Values[i] = (float)Math.Round(vec.Values[i], 6);
            vec.Rotate_X(-(float)Math.Round(rot.X, 6));

            Transform.Rotation = rot;
        }

        public void GenerateShadowMap(Scene scene)
        {
            Map.Clear();

            // Draw to distance buffer
            if (!Properties.Ambient)
            {
                foreach (Mesh mesh in scene.Meshes)
                    if (mesh.Visible)
                    {
                        Set_ProjectedValues(mesh);
                        foreach (Face face in mesh.Faces)
                            //if (Vector3.Dot(Rotation_Vector, face.Normal) < 0)
                            Draw_Face_Projected(face);
                    }

                ListVisibleFaces();
            }
            else
            {
                foreach (Mesh mesh in scene.Meshes)
                    if (mesh.Visible)
                    {
                        float distance;
                        Set_ProjectedValues(mesh);
                        foreach (Face face in mesh.Faces)
                        {
                            distance = (face.Get_Center() - Position).Get_Length();
                            face.Add_Light(this, distance);
                        }


                    }

            }



        }


        private void Set_ProjectedValues(Mesh mesh)
        {
            Vector3 tempDirectionVector;
            foreach (Vertex vertex in mesh.Vertices)
            {
                vertex.ProjectedValue = new Vertex(vertex);

                tempDirectionVector = vertex - Position;

                vertex.ProjectedValue.Z = Vector3.Dot(Rotation_Vector, tempDirectionVector);
                if (vertex.ProjectedValue.Z >= 0)
                {
                    vertex.ProjectedValue.X = Vector3.Dot(Rotation_VectorX, tempDirectionVector) * Map.Size.Width / (vertex.ProjectedValue.Z * FOV_scale);
                    vertex.ProjectedValue.X += Map.Size.Width / 2;

                    vertex.ProjectedValue.Y = Vector3.Dot(Rotation_VectorY, tempDirectionVector) * Map.Size.Height / (vertex.ProjectedValue.Z * FOV_scale);
                    vertex.ProjectedValue.Y += Map.Size.Height / 2;
                }
            }
        }

        private void ListVisibleFaces()
        {
            Face lastFace = null;

            for (int y = 0; y < Map.Size.Height; y++)
                for (int x = 0; x < Map.Size.Width; x++)
                    if (Map.Faces[x, y] != null && Map.Faces[x, y] != lastFace)
                    {
                        if (!Map.Faces[x, y].Lights.Contains(this))
                            Map.Faces[x, y].Add_Light(this, Map.Distances[x, y]);

                        lastFace = Map.Faces[x, y];
                    }

        }


        public void Draw_Line(Vector3 p1, Vector3 p2, Face face = null)
        {
            if ((p1.X < 0 || p1.X > Map.Size.Width
                || p1.Y < 0 || p1.Y > Map.Size.Height)
                && (p2.X < 0 || p2.X > Map.Size.Width
                || p2.Y < 0 || p2.Y > Map.Size.Height))
                return;

            // Y = mX + b
            float m = (p1.Y - p2.Y) / (p1.X - p2.X);
            float b = p1.Y - p1.X * m;

            if (p2.X >= 0 && p2.X < Map.Size.Width
                && p2.Y >= 0 && p2.Y <= Map.Size.Height)
            {
                if (p1.X < 0)
                {
                    p1.X = 0;
                    p1.Y = b;
                }
                else if (p1.X >= Map.Size.Width)
                {
                    p1.X = Map.Size.Width - 1;
                    p1.Y = p1.X * m + b;
                }

                if (p1.Y < 0)
                {
                    p1.Y = 0;
                    p1.X = -b / m;
                }
                else if (p1.Y >= Map.Size.Height)
                {
                    p1.Y = Map.Size.Height - 1;
                    p1.Y = (p1.Y - b) / m;
                }
            }
            else if (p1.X >= 0 && p1.X < Map.Size.Width
                && p1.Y >= 0 && p1.Y <= Map.Size.Height)
            {
                if (p2.X < 0)
                {
                    p2.X = 0;
                    p2.Y = b;
                }
                else if (p2.X >= Map.Size.Width)
                {
                    p2.X = Map.Size.Width - 1;
                    p2.Y = p2.X * m + b;
                }

                if (p2.Y < 0)
                {
                    p2.Y = 0;
                    p2.X = -b / m;
                }
                else if (p1.Y >= Map.Size.Height)
                {
                    p2.Y = Map.Size.Height - 1;
                    p2.Y = (p2.Y - b) / m;
                }
            }




            Vector3 _delta = p2 - p1;

            //float max_difference = (float)Math.Sqrt(_delta.X * _delta.X + _delta.Y * _delta.Y);
            float max_difference = (float)Math.Max(Math.Abs(_delta.X), Math.Abs(_delta.Y));

            int x, y;
            float z;

            for (float i = 0; i <= 1; i += 1 / max_difference)
            {
                x = (int)(p1.X + i * _delta.X);
                y = (int)(p1.Y + i * _delta.Y);
                z = p1.Z + i * _delta.Z;
                if (x > 0 && x < Map.Size.Width
                    && y > 0 && y < Map.Size.Height && z < Map.Distances[x, y])
                {
                    Map.Distances[x, y] = z;
                    Map.Faces[x, y] = face;
                }
            }

        }
        private void Draw_Line_Flat(Vertex v1, Vertex v2, Face face)
        {
            int startX = (int)v1.X,
                endX = (int)v2.X;


            if (v1.X < 0)
            {
                if (v2.X < 0)
                    return;
                else
                    startX = 0;
            }
            if (v2.X > Map.Size.Width - 1)
            {
                if (v1.X > Map.Size.Width - 1)
                    return;
                else
                    endX = Map.Size.Width - 1;
            }


            int range_X = (int)v2.X - (int)v1.X;

            float interpolationFactor;

            int y = (int)v1.Y;

            float delta_Z = v2.Z - v1.Z;
            float z;

            for (int x = startX; x < endX; x++)
            {
                interpolationFactor = (float)(x - startX) / (float)range_X;

                //z = v1.Z + interpolationFactor * delta_Z;
                z = RE.Lerp(v1.Z, v2.Z, 1 - interpolationFactor);

                if (z < Map.Distances[x, y])
                {
                    Map.Distances[x, y] = z;
                    Map.Faces[x, y] = face;
                }
            }

        }


        private void Draw_Triangle(Face face, params Vertex[] _v)
        {
            Vector3 a = _v[1] - _v[0];
            Vector3 b = _v[2] - _v[0];

            Vector3 a_n = _v[1].Normal - _v[0].Normal;
            Vector3 b_n = _v[2].Normal - _v[0].Normal;

            float max_difference = Math.Max(a.Get_Length_2(), b.Get_Length_2());

            for (float i = 0; i <= 1; i += 1 / max_difference)
                Draw_Line(_v[0] + i * a, _v[0] + i * b, face);
        }
        private void Draw_Triangle_Scanline(Face face)
        {
            foreach (Vertex v in face.Vertices)
            {
                v.ProjectedValue.X = (int)Math.Round(v.ProjectedValue.X);
                v.ProjectedValue.Y = (int)Math.Round(v.ProjectedValue.Y);
                //v.Z = (int)v.Z;
            }

            int offsetY = (int)Math.Min(face.Vertices[0].ProjectedValue.Y, Math.Min(face.Vertices[1].ProjectedValue.Y, face.Vertices[2].ProjectedValue.Y));
            int heigth = (int)Math.Max(face.Vertices[0].ProjectedValue.Y, Math.Max(face.Vertices[1].ProjectedValue.Y, face.Vertices[2].ProjectedValue.Y)) - offsetY;

            Line[] lines = new Line[3];
            lines[0] = LineFromTwoPoints(face.Vertices[0].ProjectedValue, face.Vertices[1].ProjectedValue);
            lines[1] = LineFromTwoPoints(face.Vertices[1].ProjectedValue, face.Vertices[2].ProjectedValue);
            lines[2] = LineFromTwoPoints(face.Vertices[0].ProjectedValue, face.Vertices[2].ProjectedValue);

            int validLines_counter = 0;
            foreach (Line l in lines)
            {
                if (l.startY < l.stopY)
                    validLines_counter++;
            }
            if (validLines_counter < 2)
                return;

            List<Vertex> bordersVertices = new List<Vertex>();

            for (int y = 0; y < heigth; y++)
            {
                bordersVertices.Clear();

                foreach (Line l in lines)
                {
                    if (l.active)
                    {
                        l.counterY++;
                        if (l.counterY < l.maxY)
                        {
                            l.currentVertex.X += l.delta_Location.X;
                            l.currentVertex.Y += l.delta_Location.Y;
                            l.currentVertex.Z += l.delta_Location.Z;

                            l.currentVertex.Normal += l.delta_Normal;
                            l.currentVertex.Texel += l.delta_Texel;
                        }
                        else
                        {
                            l.active = false;
                        }
                    }
                    else
                    {
                        if (y + offsetY == l.startY)
                            if (l.startY < l.stopY)
                                l.active = true;
                    }

                    if (l.active)
                    {
                        if (bordersVertices.Count > 0)
                        {
                            if (l.currentVertex.X < bordersVertices[0].X)
                                bordersVertices.Insert(0, l.currentVertex);
                            else
                                bordersVertices.Add(l.currentVertex);
                        }
                        else
                            bordersVertices.Add(l.currentVertex);

                    }
                }


                //if ((int)bordersVertices[0].Y >= 0 && (int)bordersVertices[0].Y < fdBuffer.Size.Height)
                if (bordersVertices.Count > 0)
                    Draw_Line_Flat(bordersVertices[0], bordersVertices[1], face);

            }


        }
        private Line LineFromTwoPoints(Vertex v1, Vertex v2)
        {
            Line ret = new Line();

            if (v1.Y < v2.Y)
            {
                ret.v_lower = v1;
                ret.v_heigher = v2;
            }
            else
            {
                ret.v_lower = v2;
                ret.v_heigher = v1;
            }



            ret.counterY = 0;
            ret.startY = (int)ret.v_lower.Y;
            ret.stopY = (int)ret.v_heigher.Y;
            ret.maxY = ret.stopY - ret.startY;


            ret.delta_Location = new Vector3((ret.v_heigher.X - ret.v_lower.X) / ret.maxY, 1, (ret.v_heigher.Z - ret.v_lower.Z) / (float)ret.maxY);
            ret.delta_Normal = (ret.v_heigher.Normal - ret.v_lower.Normal) / ret.maxY;
            ret.delta_Texel = (ret.v_heigher.Texel - ret.v_lower.Texel) / ret.maxY;
            ret.active = false;

            ret.currentVertex = new Vertex(ret.v_lower);

            if (ret.v_lower.Y < 0)
            {
                ret.startY = 0;
                ret.counterY -= (int)ret.v_lower.Y;

                ret.currentVertex.X += ret.delta_Location.X * ret.counterY;
                ret.currentVertex.Y += ret.delta_Location.Y * ret.counterY;
                ret.currentVertex.Z += ret.delta_Location.Z * ret.counterY;

                ret.currentVertex.Normal += ret.delta_Normal * ret.counterY;
                ret.currentVertex.Texel += ret.delta_Texel * ret.counterY;
            }
            if (ret.stopY > Map.Size.Height - 1)
            {
                ret.maxY += Map.Size.Height - 1 - ret.stopY;
                ret.stopY = Map.Size.Height - 1;
            }


            return ret;
        }



        public void Draw_Face(Face face, Vector3 direction)
        {
            Vector3[] _v = new Vector3[face.Vertices.Length];

            for (int i = 0; i < _v.Length; i++)
            {
                _v[i] = face.Vertices[i] - Position; //Vector3.Normalized(face.Vertices[i] - this);

                _v[i].Z = Vector3.Dot(direction, _v[i]);

                if (_v[i].Z < 0)
                    return;

                _v[i].X = face.Vertices[i].X * Map.Size.Width / (_v[i].Z * FOV_scale);
                _v[i].X += Map.Size.Width / 2;

                _v[i].Y = face.Vertices[i].Y * Map.Size.Height / (_v[i].Z * FOV_scale);
                _v[i].Y += Map.Size.Height / 2;
            }



            // v = p + t * u
            float t;
            // Clipping
            List<Vertex> tempVerts2 = new List<Vertex>();
            bool[] _v_contained = new bool[_v.Length];
            for (int i = 0; i < _v.Length; i++)
                _v_contained[i] = RE.IsContained(_v[i].X, _v[i].Y, Map.Size);

            Vertex tempVert;
            Vector3 slopeVec = new Vector3(0);

            int i2;
            for (int i = 0; i < _v.Length; i++)
            {
                i2 = i + 1 < _v.Length ? i + 1 : 0;

                if (_v_contained[i])
                {
                    tempVerts2.Add(new Vertex(_v[i], face.Vertices[i].Normal));
                    if (!_v_contained[i2])
                    {
                        tempVert = new Vertex(_v[i2].X, _v[i2].Y, _v[i2].Z);
                        t = 0;
                        slopeVec = new Vector3(tempVert - _v[i]);

                        if (tempVert.X < 0)
                            t = -_v[i].X / slopeVec.X;
                        else if (tempVert.X >= Map.Size.Width)
                            t = (Map.Size.Width - 1 - _v[i].X) / slopeVec.X;
                        tempVert.X += slopeVec.X * t;
                        tempVert.Y += slopeVec.Y * t;
                        tempVert.Z += slopeVec.Z * t;
                        tempVert.Normal += (tempVert.Normal - face.Vertices[i].Normal) * t;

                        t = 0;
                        slopeVec = tempVert - _v[i];

                        if (tempVert.Y < 0)
                            t = -_v[i].Y / slopeVec.Y;
                        else if (tempVert.Y >= Map.Size.Height)
                            t = (Map.Size.Height - 1 - _v[i].Y) / slopeVec.Y;
                        tempVert.X += slopeVec.X * t;
                        tempVert.Y += slopeVec.Y * t;
                        tempVert.Z += slopeVec.Z * t;
                        tempVert.Normal += (tempVert.Normal - face.Vertices[i].Normal) * t;

                        tempVerts2.Add(tempVert);
                    }
                }
                else if (_v_contained[i2])
                {
                    tempVert = new Vertex(_v[i].X, _v[i].Y, _v[i].Z);
                    t = 0;
                    slopeVec = new Vector3(_v[i2] - tempVert);

                    if (tempVert.X < 0)
                        t = -tempVert.X / slopeVec.X;
                    else if (tempVert.X >= Map.Size.Width)
                        t = (Map.Size.Width - 1 - _v[i].X) / slopeVec.X;
                    tempVert.X += slopeVec.X * t;
                    tempVert.Y += slopeVec.Y * t;
                    tempVert.Z += slopeVec.Z * t;
                    tempVert.Normal += (face.Vertices[i2].Normal - tempVert.Normal) * t;


                    t = 0;
                    slopeVec = _v[i2] - tempVert;

                    if (tempVert.Y < 0)
                        t = -tempVert.Y / slopeVec.Y;
                    else if (tempVert.Y >= Map.Size.Height)
                        t = (Map.Size.Height - 1 - tempVert.Y) / slopeVec.Y;
                    tempVert.X += slopeVec.X * t;
                    tempVert.Y += slopeVec.Y * t;
                    tempVert.Z += slopeVec.Z * t;
                    tempVert.Normal += (face.Vertices[i2].Normal - tempVert.Normal) * t;

                    tempVerts2.Add(tempVert);
                }
            }

            if (tempVerts2.Count == 0)
                return;

            while (tempVerts2.Count > 3)
            {
                Draw_Triangle(face, tempVerts2[0], tempVerts2[1], tempVerts2[2]);
                tempVerts2.RemoveAt(1);
            }
            Draw_Triangle(face, tempVerts2[0], tempVerts2[1], tempVerts2[2]);
        }
        private void Draw_Face_Projected(Face face)
        {
            foreach (Vertex vertex in face.Vertices)
                if (vertex.ProjectedValue.Z < 0) // || vertex.Z < 0)
                    return;

            Draw_Triangle_Scanline(face);
        }

    }

    public class ShadowMap
    {
        public Size Size;

        public Face[,] Faces;
        public float[,] Distances;

        public List<Face> VisibleFaces;

        public ShadowMap(Size size)
        {
            Size = size;
            Faces = new Face[Size.Width, Size.Height];
            Distances = new float[Size.Width, Size.Height];
            VisibleFaces = new List<Face>();

            Clear();
        }

        public void Clear(float distance = 500)
        {
            VisibleFaces.Clear();
            for (int y = 0; y < Size.Height; y++)
                for (int x = 0; x < Size.Width; x++)
                {
                    Faces[x, y] = null;
                    Distances[x, y] = 500;
                }
        }

        public Bitmap GetBitmap()
        {
            /////////////////////
            return new Bitmap(0, 0);
        }




    }


    public class Camera : Vector3
    {
        private Vector3 _Rotation;
        public Vector3 Rotation
        {
            get { return _Rotation; }
            set
            {
                _Rotation = value;

                _Rotation_Vector = new Vector3(1, 0, 0);
                _Rotation_VectorX = new Vector3(0, 0, 1);
                _Rotation_VectorY = new Vector3(0, 1, 0);
                _Rotation_Vector.Rotate(_Rotation);
                _Rotation_VectorX.Rotate(_Rotation);
                _Rotation_VectorY.Rotate(_Rotation);



                for (int i = 0; i < _Rotation_VectorX.Values.Length; i++)
                {
                    if (Math.Abs(_Rotation_Vector.Values[i]) < 0.00001)
                        _Rotation_Vector.Values[i] = 0;
                    if (Math.Abs(_Rotation_VectorX.Values[i]) < 0.00001)
                        _Rotation_VectorX.Values[i] = 0;
                    if (Math.Abs(_Rotation_VectorY.Values[i]) < 0.00001)
                        _Rotation_VectorY.Values[i] = 0;
                }

            }
        }

        private Vector3 _Rotation_Vector;
        public Vector3 Rotation_Vector { get { return _Rotation_Vector; } }
        private Vector3 _Rotation_VectorX;
        public Vector3 Rotation_VectorX { get { return _Rotation_VectorX; } }
        private Vector3 _Rotation_VectorY;
        public Vector3 Rotation_VectorY { get { return _Rotation_VectorY; } }


        public FrameDataBuffer fdBuffer;
        public Size Resolution
        {
            get { return fdBuffer.Size; }
            set { fdBuffer = new FrameDataBuffer(value); }
        }

        float _FOV_X;
        float FOV_X_scale;
        public float FOV_X
        {
            get { return _FOV_X; }
            set
            {
                _FOV_X = value;
                FOV_X_scale = (float)(2 * Math.Tan(_FOV_X * Math.PI / 180));
            }
        }
        float _FOV_Y;
        float FOV_Y_scale;
        public float FOV_Y
        {
            get { return _FOV_Y; }
            set
            {
                _FOV_Y = value;
                FOV_Y_scale = (float)(2 * Math.Tan(_FOV_Y * Math.PI / 180));
            }
        }


        public Bitmap Frame { get { return fdBuffer.Frame; } }


        public Camera(Vector3 position, Vector3 rotation, Size resolution, float fov_x = 70, float fov_y = 70)
        {
            this.X = position.X;
            this.Y = position.Y;
            this.Z = position.Z;

            Rotation = rotation;

            FOV_X = fov_x;
            FOV_Y = fov_y;

            fdBuffer = new FrameDataBuffer(resolution);
        }


        public void Set_Resolution(Size resolution)
        {
            if (resolution != fdBuffer.Size)
                fdBuffer = new FrameDataBuffer(resolution);
        }


        public void Render(Scene scene, Mesh selected)
        {
            fdBuffer.Clear();
            RE.fdBuffer.Clear();

            foreach (Mesh mesh in scene.Meshes)
                if (mesh.Visible)
                {
                    Set_ProjectedValues(mesh);
                    foreach (Face face in mesh.Faces)
                    //if (FaceIsVisible(face.Get_Center()))
                    //if (Vector3.Dot(Rotation_Vector, face.Normal) <= 0)
                    {
                        face.Clear_Lights();

                        Draw_Face_Projected(face);
                    }

                    if (mesh.Material.Shaders_Color_Vertex.Count > 0)
                        foreach (Vertex vert in mesh.Vertices)
                        {
                            if (vert.ProjectedValue.X >= 0 && vert.ProjectedValue.X < fdBuffer.Size.Width &&
                                vert.ProjectedValue.Y >= 0 && vert.ProjectedValue.Y < fdBuffer.Size.Height)
                                Draw_Vertex_projected(vert);
                        }
                }


            foreach (Light light in scene.Lights)
                if (light.Properties.Visible)
                {
                    light.GenerateShadowMap(scene);
                    if (light.lMesh.Visible)
                    {
                        Set_ProjectedValues(light.lMesh);
                        foreach (Face face in light.lMesh.Faces)
                        {
                            Draw_Face_Projected(face);
                        }
                    }

                }

            // Shadering

            for (int y = 0; y < fdBuffer.Size.Height; y++)
                for (int x = 0; x < fdBuffer.Size.Width; x++)
                {
                    if (fdBuffer.Vertices[x, y] != null)
                    {
                        foreach (Shader_Color_Vertex shaderCV in fdBuffer.Vertices[x, y].Faces[0].Parent.Material.Shaders_Color_Vertex)
                            shaderCV.Calculate(x, y);
                    }
                    else if (fdBuffer.Faces[x, y] != null)
                    //fdBuffer.Faces[x, y].Material.Shaders[0].Calculate(x, y);
                    {
                        if (fdBuffer.Faces[x, y].Parent.Material.Shaders.Count > 0)
                            foreach (Shader shader in fdBuffer.Faces[x, y].Parent.Material.Shaders)
                                shader.Calculate(x, y);
                        else
                            RE.Shader_OutLine(x, y, Color.Red);

                        if (fdBuffer.Faces[x, y].Parent == selected)
                            RE.Shader_OutLine(x, y, Color.Orange);
                    }


                }




        }


        private void Set_ProjectedValues(Mesh mesh)
        {
            Vector3 tempDirectionVector;
            foreach (Vertex vertex in mesh.Vertices)
            {
                vertex.ProjectedValue = new Vertex(vertex);

                tempDirectionVector = vertex - this;

                vertex.ProjectedValue.Z = Vector3.Dot(Rotation_Vector, tempDirectionVector);
                if (vertex.ProjectedValue.Z > 0)
                {
                    vertex.ProjectedValue.X = Vector3.Dot(Rotation_VectorX, tempDirectionVector) * fdBuffer.Size.Width / (vertex.ProjectedValue.Z * FOV_X_scale);
                    vertex.ProjectedValue.X += fdBuffer.Size.Width / 2;

                    vertex.ProjectedValue.Y = Vector3.Dot(Rotation_VectorY, tempDirectionVector) * fdBuffer.Size.Height / (vertex.ProjectedValue.Z * FOV_Y_scale);
                    vertex.ProjectedValue.Y += fdBuffer.Size.Height / 2;
                }
            }
        }
        private bool FaceIsVisible(Vector3 p)
        {
            Vector3 a = Vector3.Normalized(p - this);

            if (Vector3.Dot(Rotation_Vector, a) > 0)
                return true;

            return false;
        }


        private void Draw_Line(Vector3 p1, Vector3 n1, Vector3 p2, Vector3 n2, Face face = null)
        {
            Vector3 _delta = p2 - p1;
            Vector3 _normal = n2 - n1;

            //float max_difference = _delta.Get_Length_2();
            float max_difference = (float)Math.Max(Math.Abs(_delta.X), Math.Abs(_delta.Y));

            int x, y;
            float z;

            for (float i = 0; i <= 1; i += 1 / max_difference)
            {
                x = (int)(p1.X + i * _delta.X);
                y = (int)(p1.Y + i * _delta.Y);
                z = p1.Z + i * _delta.Z;
                if (x > 0 && x < fdBuffer.Size.Width
                    && y > 0 && y < fdBuffer.Size.Height
                    && z < fdBuffer.Distances[x, y])
                {
                    fdBuffer.Distances[x, y] = z;
                    fdBuffer.Faces[x, y] = face;
                    fdBuffer.Normals[x, y] = n1 + i * _normal;
                }
            }

        }
        private void Draw_Line_Flat(Vertex v1, Vertex v2, Face face)
        {
            int startX = (int)v1.X,
                endX = (int)v2.X;


            if (v1.X < 0)
            {
                if (v2.X < 0)
                    return;
                else
                    startX = 0;
            }
            if (v2.X > fdBuffer.Size.Width - 1)
            {
                if (v1.X > fdBuffer.Size.Width - 1)
                    return;
                else
                    endX = fdBuffer.Size.Width - 1;
            }


            int range_X = (int)v2.X - (int)v1.X;

            float interpolationFactor;

            int y = (int)v1.Y;

            float delta_Z = v2.Z - v1.Z;
            float z;

            Vector3 delta_Normals = v2.Normal - v1.Normal;
            Vector3 delta_Texels = v2.Texel - v1.Texel;


            for (int x = startX; x < endX; x++)
            {
                interpolationFactor = (float)(x - startX) / (float)range_X;

                //z = v1.Z + interpolationFactor * delta_Z;
                z = RE.Lerp(v1.Z, v2.Z, 1 - interpolationFactor);

                if (z < fdBuffer.Distances[x, y])
                {
                    fdBuffer.Distances[x, y] = z;
                    fdBuffer.Faces[x, y] = face;
                    fdBuffer.Normals[x, y] = v1.Normal + interpolationFactor * delta_Normals;
                    fdBuffer.Texels[x, y] = v1.Texel + interpolationFactor * delta_Texels;
                }
            }

        }

        private void Draw_Triangle(Face face, params Vertex[] _v)
        {
            Vector3 a = _v[1] - _v[0];
            Vector3 b = _v[2] - _v[0];

            Vector3 a_n = _v[1].Normal - _v[0].Normal;
            Vector3 b_n = _v[2].Normal - _v[0].Normal;

            float max_difference = Math.Max(a.Get_Length_2(), b.Get_Length_2());

            for (float i = 0; i <= 1; i += 1 / max_difference)
                Draw_Line(_v[0] + i * a, _v[0].Normal + i * a_n, _v[0] + i * b, _v[0].Normal + i * b_n, face);
        }
        private void Draw_Triangle_Scanline(Face face, params Vertex[] _v)
        {
            foreach (Vertex v in _v)
            {
                v.X = (int)v.X;
                v.Y = (int)v.Y;
                //v.Z = (int)v.Z;
            }

            int offsetX = (int)Math.Min(_v[0].X, Math.Min(_v[1].X, _v[2].X));
            int offsetY = (int)Math.Min(_v[0].Y, Math.Min(_v[1].Y, _v[2].Y));
            int width = (int)Math.Max(_v[0].X, Math.Max(_v[1].X, _v[2].X)) - offsetX;
            int heigth = (int)Math.Max(_v[0].Y, Math.Max(_v[1].Y, _v[2].Y)) - offsetY;

            Line[] lines = new Line[3];
            lines[0] = LineFromTwoPoints(_v[0], _v[1]);
            lines[1] = LineFromTwoPoints(_v[1], _v[2]);
            lines[2] = LineFromTwoPoints(_v[0], _v[2]);

            List<Vertex> bordersVertices = new List<Vertex>();

            for (int y = 0; y < heigth; y++)
            {
                bordersVertices.Clear();

                foreach (Line l in lines)
                {
                    if (l.active)
                    {
                        l.counterY++;
                        if (l.counterY < l.maxY)
                        {
                            l.currentVertex.X += l.delta_Location.X;
                            l.currentVertex.Y += l.delta_Location.Y;
                            l.currentVertex.Z += l.delta_Location.Z;

                            l.currentVertex.Normal += l.delta_Normal;
                            l.currentVertex.Texel += l.delta_Texel;
                        }
                        else
                        {
                            l.active = false;
                        }
                    }
                    else
                    {
                        if (y + offsetY == l.v_lower.Y)
                            if (l.maxY != 0)
                                l.active = true;
                    }

                    if (l.active)
                    {
                        if (bordersVertices.Count > 0)
                        {
                            if (l.currentVertex.X < bordersVertices[0].X)
                                bordersVertices.Insert(0, l.currentVertex);
                            else
                                bordersVertices.Add(l.currentVertex);
                        }
                        else
                            bordersVertices.Add(l.currentVertex);

                    }
                }


                if ((int)bordersVertices[0].Y >= 0 && (int)bordersVertices[0].Y < fdBuffer.Size.Height)
                    Draw_Line_Flat(bordersVertices[0], bordersVertices[1], face);

            }


        }
        private void Draw_Triangle_Scanline(Face face)
        {
            foreach (Vertex v in face.Vertices)
            {
                v.ProjectedValue.X = (int)Math.Round(v.ProjectedValue.X);
                v.ProjectedValue.Y = (int)Math.Round(v.ProjectedValue.Y);
                //v.Z = (int)v.Z;
            }

            int offsetY = (int)Math.Min(face.Vertices[0].ProjectedValue.Y, Math.Min(face.Vertices[1].ProjectedValue.Y, face.Vertices[2].ProjectedValue.Y));
            int heigth = (int)Math.Max(face.Vertices[0].ProjectedValue.Y, Math.Max(face.Vertices[1].ProjectedValue.Y, face.Vertices[2].ProjectedValue.Y)) - offsetY;

            Line[] lines = new Line[3];
            lines[0] = LineFromTwoPoints(face.Vertices[0].ProjectedValue, face.Vertices[1].ProjectedValue);
            lines[1] = LineFromTwoPoints(face.Vertices[1].ProjectedValue, face.Vertices[2].ProjectedValue);
            lines[2] = LineFromTwoPoints(face.Vertices[0].ProjectedValue, face.Vertices[2].ProjectedValue);

            int validLines_counter = 0;
            foreach (Line l in lines)
            {
                if (l.startY < l.stopY)
                    validLines_counter++;
            }
            if (validLines_counter < 2)
                return;

            List<Vertex> bordersVertices = new List<Vertex>();

            for (int y = 0; y < heigth; y++)
            {
                bordersVertices.Clear();

                foreach (Line l in lines)
                {
                    if (l.active)
                    {
                        l.counterY++;
                        if (l.counterY < l.maxY)
                        {
                            l.currentVertex.X += l.delta_Location.X;
                            l.currentVertex.Y += l.delta_Location.Y;
                            l.currentVertex.Z += l.delta_Location.Z;

                            l.currentVertex.Normal += l.delta_Normal;
                            l.currentVertex.Texel += l.delta_Texel;
                        }
                        else
                        {
                            l.active = false;
                        }
                    }
                    else
                    {
                        if (y + offsetY == l.startY)
                            if (l.startY < l.stopY)
                                l.active = true;
                    }

                    if (l.active)
                    {
                        if (bordersVertices.Count > 0)
                        {
                            if (l.currentVertex.X < bordersVertices[0].X)
                                bordersVertices.Insert(0, l.currentVertex);
                            else
                                bordersVertices.Add(l.currentVertex);
                        }
                        else
                            bordersVertices.Add(l.currentVertex);

                    }
                }


                //if ((int)bordersVertices[0].Y >= 0 && (int)bordersVertices[0].Y < fdBuffer.Size.Height)
                if (bordersVertices.Count > 0)
                    Draw_Line_Flat(bordersVertices[0], bordersVertices[1], face);

            }


        }

        private Line LineFromTwoPoints(Vertex v1, Vertex v2)
        {
            Line ret = new Line();

            if (v1.Y < v2.Y)
            {
                ret.v_lower = v1;
                ret.v_heigher = v2;
            }
            else
            {
                ret.v_lower = v2;
                ret.v_heigher = v1;
            }



            ret.counterY = 0;
            ret.startY = (int)ret.v_lower.Y;
            ret.stopY = (int)ret.v_heigher.Y;
            ret.maxY = ret.stopY - ret.startY;


            ret.delta_Location = new Vector3((ret.v_heigher.X - ret.v_lower.X) / ret.maxY, 1, (ret.v_heigher.Z - ret.v_lower.Z) / (float)ret.maxY);
            ret.delta_Normal = (ret.v_heigher.Normal - ret.v_lower.Normal) / ret.maxY;
            ret.delta_Texel = (ret.v_heigher.Texel - ret.v_lower.Texel) / ret.maxY;
            ret.active = false;

            ret.currentVertex = new Vertex(ret.v_lower);

            if (ret.v_lower.Y < 0)
            {
                ret.startY = 0;
                ret.counterY -= (int)ret.v_lower.Y;

                ret.currentVertex.X += ret.delta_Location.X * ret.counterY;
                ret.currentVertex.Y += ret.delta_Location.Y * ret.counterY;
                ret.currentVertex.Z += ret.delta_Location.Z * ret.counterY;

                ret.currentVertex.Normal += ret.delta_Normal * ret.counterY;
                ret.currentVertex.Texel += ret.delta_Texel * ret.counterY;
            }
            if (ret.stopY > fdBuffer.Size.Height - 1)
            {
                ret.maxY += fdBuffer.Size.Height - 1 - ret.stopY;
                ret.stopY = fdBuffer.Size.Height - 1;
            }


            return ret;
        }


        private void Draw_Face(Face face)
        {
            Vector3[] _v = new Vector3[face.Vertices.Length];

            Vector3 tempDirectionVector;
            for (int i = 0; i < _v.Length; i++)
            {
                tempDirectionVector = face.Vertices[i] - this;
                _v[i] = new Vector3(0);

                _v[i].Z = Vector3.Dot(Rotation_Vector, tempDirectionVector);

                if (_v[i].Z <= 0)
                    return;

                _v[i].X = Vector3.Dot(Rotation_VectorX, tempDirectionVector) * fdBuffer.Size.Width / (_v[i].Z * FOV_X_scale);
                _v[i].X += fdBuffer.Size.Width / 2;

                _v[i].Y = Vector3.Dot(Rotation_VectorY, tempDirectionVector) * fdBuffer.Size.Height / (_v[i].Z * FOV_Y_scale);
                _v[i].Y += fdBuffer.Size.Height / 2;
            }

            // v = p + t * u
            float t;
            // Clipping
            List<Vertex> tempVerts2 = new List<Vertex>();
            bool[] _v_contained = new bool[_v.Length];
            for (int i = 0; i < _v.Length; i++)
                _v_contained[i] = RE.IsContained(_v[i].X, _v[i].Y, fdBuffer.Size);

            Vertex tempVert;
            Vector3 slopeVec = new Vector3(0);

            int i2;
            for (int i = 0; i < _v.Length; i++)
            {
                i2 = i + 1 < _v.Length ? i + 1 : 0;

                if (_v_contained[i])
                {
                    tempVerts2.Add(new Vertex(_v[i], face.Vertices[i].Normal));
                    tempVerts2[tempVerts2.Count - 1].Texel = face.Vertices[i].Texel;

                    if (!_v_contained[i2])
                    {
                        tempVert = new Vertex(_v[i2].X, _v[i2].Y, _v[i2].Z, face.Vertices[i2].Normal);
                        tempVert.Texel = face.Vertices[i2].Texel;

                        t = 0;
                        slopeVec = new Vector3(tempVert - _v[i]);

                        if (tempVert.X < 0)
                            t = -tempVert.X / slopeVec.X;
                        else if (tempVert.X >= fdBuffer.Size.Width)
                            t = (fdBuffer.Size.Width - 1 - tempVert.X) / slopeVec.X;
                        tempVert.X += slopeVec.X * t;
                        tempVert.Y += slopeVec.Y * t;
                        tempVert.Z += slopeVec.Z * t;
                        tempVert.Normal += (tempVert.Normal - face.Vertices[i].Normal) * t;
                        tempVert.Texel += (tempVert.Texel - face.Vertices[i].Texel) * t;

                        t = 0;
                        slopeVec = tempVert - _v[i];

                        if (tempVert.Y < 0)
                            t = -tempVert.Y / slopeVec.Y;
                        else if (tempVert.Y >= fdBuffer.Size.Height)
                            t = (fdBuffer.Size.Height - 1 - tempVert.Y) / slopeVec.Y;
                        tempVert.X += slopeVec.X * t;
                        tempVert.Y += slopeVec.Y * t;
                        tempVert.Z += slopeVec.Z * t;
                        tempVert.Normal += (tempVert.Normal - face.Vertices[i].Normal) * t;
                        tempVert.Texel += (tempVert.Texel - face.Vertices[i].Texel) * t;

                        tempVerts2.Add(tempVert);
                    }
                }
                else if (_v_contained[i2])
                {
                    tempVert = new Vertex(_v[i].X, _v[i].Y, _v[i].Z, face.Vertices[i].Normal);
                    tempVert.Texel = face.Vertices[i].Texel;

                    t = 0;
                    slopeVec = new Vector3(_v[i2] - tempVert);

                    if (tempVert.X < 0)
                        t = -tempVert.X / slopeVec.X;
                    else if (tempVert.X >= fdBuffer.Size.Width)
                        t = (fdBuffer.Size.Width - 1 - tempVert.X) / slopeVec.X;
                    tempVert.X += slopeVec.X * t;
                    tempVert.Y += slopeVec.Y * t;
                    tempVert.Z += slopeVec.Z * t;
                    tempVert.Normal += (tempVert.Normal - face.Vertices[i].Normal) * t;
                    tempVert.Texel += (tempVert.Texel - face.Vertices[i].Texel) * t;


                    t = 0;
                    slopeVec = _v[i2] - tempVert;

                    if (tempVert.Y < 0)
                        t = -tempVert.Y / slopeVec.Y;
                    else if (tempVert.Y >= fdBuffer.Size.Height)
                        t = (fdBuffer.Size.Height - 1 - tempVert.Y) / slopeVec.Y;
                    tempVert.X += slopeVec.X * t;
                    tempVert.Y += slopeVec.Y * t;
                    tempVert.Z += slopeVec.Z * t;
                    tempVert.Normal += (tempVert.Normal - face.Vertices[i].Normal) * t;
                    tempVert.Texel += (tempVert.Texel - face.Vertices[i].Texel) * t;

                    tempVerts2.Add(tempVert);
                }
            }

            if (tempVerts2.Count < 3)
                return;

            while (tempVerts2.Count > 3)
            {
                //Draw_Triangle(face, tempVerts2[0], tempVerts2[1], tempVerts2[2]);
                Draw_Triangle_Scanline(face, tempVerts2[0], tempVerts2[1], tempVerts2[2]);
                tempVerts2.RemoveAt(1);
            }

            //Draw_Triangle(face, tempVerts2[0], tempVerts2[1], tempVerts2[2]);
            Draw_Triangle_Scanline(face, tempVerts2[0], tempVerts2[1], tempVerts2[2]);
        }
        private void Draw_Face_Projected(Face face)
        {
            foreach (Vertex vertex in face.Vertices)
                if (vertex.ProjectedValue.Z <= 0) // || vertex.Z < 0)
                    return;

            Draw_Triangle_Scanline(face);
            #region clipping
            /*
            // v = p + t * u
            float t;
            // Clipping
            
            
            List<Vertex> tempVerts2 = new List<Vertex>();
            bool[] _v_contained = new bool[face.Vertices.Length];
            for (int i = 0; i < face.Vertices.Length; i++)
                _v_contained[i] = RE.IsContained(face.Vertices[i].ProjectedValue.X, face.Vertices[i].ProjectedValue.Y, fdBuffer.Size);

            Vertex tempVert;
            Vector3 slopeVec = new Vector3(0);

            int i2;
            for (int i = 0; i < face.Vertices.Length; i++)
            {
                i2 = i + 1 < face.Vertices.Length ? i + 1 : 0;

                if (_v_contained[i])
                {
                    tempVerts2.Add(new Vertex(face.Vertices[i].ProjectedValue, face.Vertices[i].Normal));
                    tempVerts2[tempVerts2.Count - 1].Texel = face.Vertices[i].Texel;

                    if (!_v_contained[i2])
                    {
                        tempVert = new Vertex(face.Vertices[i2].ProjectedValue.X, face.Vertices[i2].ProjectedValue.Y, face.Vertices[i2].ProjectedValue.Z, face.Vertices[i2].Normal);
                        tempVert.Texel = face.Vertices[i2].Texel;

                        t = 0;
                        slopeVec = new Vector3(tempVert - face.Vertices[i].ProjectedValue);

                        if (tempVert.X < 0)
                            t = -tempVert.X / slopeVec.X;
                        else if (tempVert.X >= fdBuffer.Size.Width)
                            t = (fdBuffer.Size.Width - 1 - tempVert.X) / slopeVec.X;
                        tempVert.X += slopeVec.X * t;
                        tempVert.Y += slopeVec.Y * t;
                        tempVert.Z += slopeVec.Z * t;
                        tempVert.Normal += (tempVert.Normal - face.Vertices[i].Normal) * t;
                        tempVert.Texel += (tempVert.Texel - face.Vertices[i].Texel) * t;

                        t = 0;
                        slopeVec = tempVert - face.Vertices[i].ProjectedValue;

                        if (tempVert.Y < 0)
                            t = -tempVert.Y / slopeVec.Y;
                        else if (tempVert.Y >= fdBuffer.Size.Height)
                            t = (fdBuffer.Size.Height - 1 - tempVert.Y) / slopeVec.Y;
                        tempVert.X += slopeVec.X * t;
                        tempVert.Y += slopeVec.Y * t;
                        tempVert.Z += slopeVec.Z * t;
                        tempVert.Normal += (tempVert.Normal - face.Vertices[i].Normal) * t;
                        tempVert.Texel += (tempVert.Texel - face.Vertices[i].Texel) * t;

                        tempVerts2.Add(tempVert);
                    }
                }
                else if (_v_contained[i2])
                {
                    tempVert = new Vertex(face.Vertices[i].ProjectedValue.X, face.Vertices[i].ProjectedValue.Y, face.Vertices[i].ProjectedValue.Z, face.Vertices[i].Normal);
                    tempVert.Texel = face.Vertices[i].Texel;

                    t = 0;
                    slopeVec = new Vector3(face.Vertices[i2].ProjectedValue - tempVert);

                    if (tempVert.X < 0)
                        t = -tempVert.X / slopeVec.X;
                    else if (tempVert.X >= fdBuffer.Size.Width)
                        t = (fdBuffer.Size.Width - 1 - tempVert.X) / slopeVec.X;
                    tempVert.X += slopeVec.X * t;
                    tempVert.Y += slopeVec.Y * t;
                    tempVert.Z += slopeVec.Z * t;
                    tempVert.Normal += (tempVert.Normal - face.Vertices[i].Normal) * t;
                    tempVert.Texel += (tempVert.Texel - face.Vertices[i].Texel) * t;


                    t = 0;
                    slopeVec = face.Vertices[i2].ProjectedValue - tempVert;

                    if (tempVert.Y < 0)
                        t = -tempVert.Y / slopeVec.Y;
                    else if (tempVert.Y >= fdBuffer.Size.Height)
                        t = (fdBuffer.Size.Height - 1 - tempVert.Y) / slopeVec.Y;
                    tempVert.X += slopeVec.X * t;
                    tempVert.Y += slopeVec.Y * t;
                    tempVert.Z += slopeVec.Z * t;
                    tempVert.Normal += (tempVert.Normal - face.Vertices[i].Normal) * t;
                    tempVert.Texel += (tempVert.Texel - face.Vertices[i].Texel) * t;

                    tempVerts2.Add(tempVert);
                }
            }

            if (tempVerts2.Count < 3)
                return;

            while (tempVerts2.Count > 3)
            {
                //Draw_Triangle(face, tempVerts2[0], tempVerts2[1], tempVerts2[2]);
                Draw_Triangle_Scanline(face, tempVerts2[0], tempVerts2[1], tempVerts2[2]);
                tempVerts2.RemoveAt(1);
            }

            //Draw_Triangle(face, tempVerts2[0], tempVerts2[1], tempVerts2[2]);
            Draw_Triangle_Scanline(face, tempVerts2[0], tempVerts2[1], tempVerts2[2]);
            */
            #endregion
        }

        private void Draw_Vertex_projected(Vertex vert)
        {
            int x = (int)vert.ProjectedValue.X,
                y = (int)vert.ProjectedValue.Y;
            if (vert.ProjectedValue.Z <= fdBuffer.Distances[x, y])
            {
                fdBuffer.Distances[x, y] = vert.ProjectedValue.Z;
                fdBuffer.Vertices[x, y] = vert;
            }
        }


        public void LookAt(Vector3 target)
        {
            Vector3 vec = Vector3.Normalized(target - this);
            Vector3 zeroedV = new Vector3(1, 0, 0);

            Vector3 rot = new Vector3(0);

            rot.Z = -(float)(Math.Atan2(vec.Y, vec.X) * 180 / Math.PI);
            vec.Rotate_Z(-rot.Z);
            rot.Y = -(float)(Math.Atan2(vec.Z, vec.X) * 180 / Math.PI);
            vec.Rotate_Y(-rot.Y);
            rot.X = -(float)(Math.Atan2(vec.Y, vec.Z) * 180 / Math.PI);
            vec.Rotate_X(-rot.X);

            Rotation = rot;
        }
        public void Zoom(float zoom_factor)
        {
            Values += Rotation_Vector * zoom_factor;
        }
        public void Move(float x, float y)
        {
            x *= -1;
            //y *= -1;
            Values += Rotation_VectorX * x + Rotation_VectorY * y;
        }

    }

    public class FrameDataBuffer
    {
        public Size Size;

        public Face[,] Faces;
        public Vertex[,] Vertices;
        public float[,] Distances;
        public Vector3[,] Normals;
        public Vector3[,] Texels;

        public Bitmap Frame;
        Graphics Frame_Graphics;

        public FrameDataBuffer(Size size)
        {
            Size = size;
            Faces = new Face[Size.Width, Size.Height];
            Vertices = new Vertex[Size.Width, Size.Height];
            Distances = new float[Size.Width, Size.Height];
            Normals = new Vector3[Size.Width, Size.Height];
            Texels = new Vector3[size.Width, Size.Height];
            Frame = new Bitmap(Size.Width, Size.Height);
            Frame_Graphics = Graphics.FromImage(Frame);

            Clear();
        }

        public void Clear(float distance = 500)
        {
            Frame_Graphics.Clear(RE.Empty_Color);

            for (int y = 0; y < Size.Height; y++)
                for (int x = 0; x < Size.Width; x++)
                {
                    Faces[x, y] = null;
                    Vertices[x, y] = null;
                    Distances[x, y] = 500;
                    Normals[x, y] = new Vector3(0);
                    Texels[x, y] = null;
                }
        }

    }


    public class Line
    {
        public Vertex v_lower;
        public Vertex v_heigher;

        public Vector3 delta_Location;
        public Vector3 delta_Normal;
        public Vector3 delta_Texel;

        public int startY;
        public int stopY;

        public int maxY;
        public int counterY;

        public bool active;

        public Vertex currentVertex;
    }




    public class REProperty
    {
        public Control Control;
        public virtual void Reshape(int width, int height) { }
    }


    public class Transform : REProperty
    {
        private Vector3 _Position = new Vector3();
        private Vector3 _Rotation = new Vector3();
        private Vector3 _Scale = new Vector3(1);

        private Vector3 delta = new Vector3();


        public Vector3 Position
        {
            get { return _Position; }
            set
            {
                delta = value - _Position;
                _Position = value;

                if (Position_Changed != null) Position_Changed(delta, EventArgs.Empty);
            }
        }
        public Vector3 Rotation
        {
            get { return _Rotation; }
            set
            {
                delta = value - _Rotation;
                _Rotation = value;
                if (Rotation_Changed != null) Rotation_Changed(delta, EventArgs.Empty);
            }
        }
        public Vector3 Scale
        {
            get { return _Scale; }
            set
            {
                delta = value / _Scale;
                _Scale = value;
                if (Scale_Changed != null) Scale_Changed(delta, EventArgs.Empty);
            }
        }


        public event EventHandler Position_Changed = delegate { };
        public event EventHandler Rotation_Changed = delegate { };
        public event EventHandler Scale_Changed = delegate { };


        public Transform()
        {
            Position = new Vector3();
            Rotation = new Vector3();
            Scale = new Vector3(1);

            Transform tempT = this;

            Control = new Control_Transform(tempT);
        }
        public Transform(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            Position = new Vector3(position);
            Rotation = new Vector3(rotation);
            Scale = new Vector3(scale);

            Transform tempT = this;

            Control = new Control_Transform(tempT);
        }

        public Transform(Transform transform)
        {
            Position = new Vector3(transform.Position);
            Rotation = new Vector3(transform.Rotation);
            Scale = new Vector3(transform.Scale);

            Transform tempT = this;

            Control = new Control_Transform(tempT);
        }


        public override void Reshape(int width, int height)
        {
            ((Control_Transform)Control).Reshape(width, height);
        }
    }

    public class Light_Properties : REProperty
    {
        public bool Visible;
        public bool Ambient;

        public float _FOV;
        public float Intensity;
        public Color Color;


        public Light_Properties(Color color, bool visible = true, bool ambient = false, float fov = 70, float intensity = 1)
        {
            Visible = visible;
            Ambient = ambient;
            _FOV = fov;
            Intensity = intensity;
            Color = color;

            Control = new Control_Light();
            ((Control_Light)Control).Set_Value(this);
        }


        public override void Reshape(int width, int height)
        {
            //((Control_Light)Control).Reshape(width, height);
        }
    }



}
