using OpenGL_Game.Managers;
using OpenGL_Game.OBJLoader;

namespace OpenGL_Game.Components
{
    class ComponentGeometry : IComponent
    {
        Geometry geometry;
        private string nullOBJ = "NULL";


        public ComponentGeometry(string geometryName)
        {
            this.geometry = ResourceManager.LoadGeometry(geometryName);
        }

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_GEOMETRY; }
        }

        public void NullGeometry()
        {
            this.geometry = ResourceManager.LoadGeometry(nullOBJ);
        }

        public void Close()
        {
            geometry.RemoveGeometry();
        }

        public Geometry Geometry()
        {
            return geometry;
        }
    }
}
