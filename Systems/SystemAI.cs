using OpenGL_Game.Components;
using OpenGL_Game.Objects;
using OpenGL_Game.OBJLoader;
using OpenGL_Game.Scenes;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGL_Game.Systems
{
    class SystemAI : ISystem
    {

        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_VELOCITY | ComponentTypes.COMPONENT_AI);


        public SystemAI()
        {

        }
        public string Name
        {
            get { return "SystemAI"; }
        }

        public void OnAction(Entity entity)
        {
            if ((entity.Mask & MASK) == MASK)
            {
                List<IComponent> components = entity.Components;

                IComponent velocityComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_VELOCITY;
                });

                ComponentVelocity velocity = (ComponentVelocity)velocityComponent;


                IComponent positionComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                });

                ComponentPosition position = (ComponentPosition)positionComponent;

                IComponent pathComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_AI;
                });

                ComponentAI path = (ComponentAI)pathComponent;

                MoveAI(entity, velocity, position, path);
            }
        }

        private void MoveAI(Entity entity, ComponentVelocity velocity, ComponentPosition position, ComponentAI path)
        {
            if(entity.Name == "Wraith_Raider_Starship")
            {
                foreach(Points Point in path.list_paths)
                {
                    if(Point.point.X < position.Position.X)
                    {

                    }
                }
                position.Position += velocity.Velocity * GameScene.dt;
            }
            

        }

    }
}
