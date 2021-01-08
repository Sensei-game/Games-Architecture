using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGL_Game.Components
{
    class ComponentSphereCollision : IComponent
    {
        //There is the auto property, but I would rather see what happends

        float radius;

        public ComponentSphereCollision(float x)
        {
            radius = x;
        }

        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public void Close()
        {
            radius = 0.0f;
        }

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_SPHERECOLLISION; }
        }
    }
}
