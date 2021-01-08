using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenGL_Game.Components;

namespace OpenGL_Game.Objects
{
    class Entity
    {
        public string name;
        List<IComponent> componentList = new List<IComponent>();
        ComponentTypes mask;
 
        public Entity(string name)
        {
            this.name = name;
        }

        /// <summary>Adds a single component</summary>
        public void AddComponent(IComponent component)
        {
            Debug.Assert(component != null, "Component cannot be null");

            componentList.Add(component);
            mask |= component.ComponentType;
        }
      
        public void CallClose()
        {
            //sanity check
            foreach (var component in componentList)
            {
                component.Close();
            }
        }

        public string Name
        {
            get { return name; }
        }

        public ComponentTypes Mask
        {
            get { return mask; }
        }

        public List<IComponent> Components
        {
            get { return componentList; }
        }

        public ComponentAudio GetComponent<ComponentAudio>()
        {
            return (ComponentAudio)componentList.Find(value => value.ComponentType == ComponentTypes.COMPONENT_AUDIO);
        }

        public IComponent GetPosition<ComponentPosition>()
        {
            return componentList.Find(value => value.ComponentType == ComponentTypes.COMPONENT_POSITION);
        }
        public IComponent GetGeometry<ComponentGeometry>()
        {
            return componentList.Find(value => value.ComponentType == ComponentTypes.COMPONENT_GEOMETRY);
        }
    }
}
