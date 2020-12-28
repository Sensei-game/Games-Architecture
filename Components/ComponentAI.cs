using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGL_Game.Components
{
    class ComponentAI : IComponent
    {
        public List<Points> Paths;

        public enum AIstates : byte
        {
            idle,
            chasing,
            disabled
        }

        public AIstates currentstate
        {
            get ;
            set ;
        }


        public ComponentAI(List<Points> _paths)
        {
            Paths = _paths;
        }

        public List<Points> list_paths
        {
            get { return Paths; }
            set { Paths = value; }
        }

        public void Close()
        {

        }

        public ComponentTypes ComponentType
       {
            get { return ComponentTypes.COMPONENT_AI; }
       }

    }

    class Points
    {
        public Vector3 point;

        public Points(Vector3 a_point)
        {
            point = a_point;
        }
    }
}
