using OpenGL_Game.Components;
using OpenGL_Game.Managers;
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
    class SystemSphereCollision :ISystem
    {
        SphereCollisionManager sphereHabit = new SphereCollisionManager();

        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_SPHERECOLLISION);

        public SystemSphereCollision()
        {

        }
        public string Name
        {
            get { return "SystemSphereCollision"; }
        }

        public void OnAction(Entity entity)
        {
            if ((entity.Mask & MASK) == MASK)
            {
                List<IComponent> components = entity.Components;

                IComponent SphereCollisionComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_SPHERECOLLISION;
                });
                // Radius maybe variable

                //float spherecol = ((ComponentCollisionSphere)CollisionSpherecomponent).Radius;

                ComponentSphereCollision collision = (ComponentSphereCollision)SphereCollisionComponent;


                IComponent positionComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                });

                //Vector3 position = ((ComponentPosition)positionComponent).Position;
                // Matrix4 model = Matrix4.CreateTranslation(position);



                ComponentPosition position = (ComponentPosition)positionComponent;
                // ((ComponentCollisionLine)CollisionSpherecomponent).
                Collision(entity, collision, position);



                //Calculus((ComponentPosition)positionComponent, (ComponentSphereCollision)SphereCollisionComponent);
            }
        }

        private void Collision(Entity entity, ComponentSphereCollision componentCollisionSphere, ComponentPosition position)
        {
            //Add Camera / player entity no need

            //Moon Collision
            

            if ((position.Position - GameScene.gameInstance.camera.cameraPosition).Length < componentCollisionSphere.Radius + GameScene.gameInstance.camera.Radius)
            {
                // System.Console.WriteLine("Collision happening");
                sphereHabit.ProcessCollision(entity);
            }
        }
    }
}
