using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REngine
{
    public class Scene
    {
        public string Name;

        public List<Mesh> Meshes;
        public List<Light> Lights;
        public List<Camera> Cameras;


        public Scene(string name)
        {
            Name = name;
            Meshes = new List<Mesh>();
            Lights = new List<Light>();
            Cameras = new List<Camera>();
        }
        public Scene(Scene scene)
        {
            Name = scene.Name;
            Meshes = scene.Meshes;
            Lights = scene.Lights;
        }


    }
}
