using OpenGL_Game.Components;
using OpenGL_Game.Managers;
using OpenGL_Game.Objects;
using OpenGL_Game.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGL_Game.Systems
{
    class SystemLineCollision : ISystem
    {
        LineCollisionManager lineHabit = new LineCollisionManager();

        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_LINECOLLISION);

        public SystemLineCollision() 
        {

        }

        public string Name
        {
            get { return "SystemLineCollision"; }
        }

        public void OnAction(Entity entity)
        {
            if ((entity.Mask & MASK) == MASK)
            {
                List<IComponent> components = entity.Components;

                IComponent LineCollisionComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_LINECOLLISION;
                });
                         
                ComponentLineCollision collision = (ComponentLineCollision)LineCollisionComponent;


                IComponent positionComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                });

                ComponentPosition position = (ComponentPosition)positionComponent;

                // ((ComponentCollisionLine)CollisionSpherecomponent)

                Collision(entity, collision);
            }
        }

        private void Collision(Entity entity, ComponentLineCollision collision)
        {
            if(entity.Name == "Maze")
            {
                foreach(Coordinates Limit in collision.limits_coordinates)
                {

                    float cameraX = (float)Math.Round(GameScene.gameInstance.camera.cameraPosition.X, 4);
                    float cameraZ = (float)Math.Round(GameScene.gameInstance.camera.cameraPosition.Z, 4);

                    //float cameraX = GameScene.gameInstance.camera.cameraPosition.X;
                    //float cameraZ = GameScene.gameInstance.camera.cameraPosition.Z;

                    if ((Limit.PointA.X <= cameraX) && (Limit.PointB.X >= cameraX) && (Limit.PointA.Z <= cameraZ) && (Limit.PointB.Z >= cameraZ))
                    {
                        //System.Console.WriteLine("Collision happening with Limit");
                        lineHabit.ProcessCollision(entity);
                    }
                }
            }
        }
    }
}
