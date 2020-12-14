//using OpenGL_Game.Components;
//using OpenGL_Game.Objects;
//using OpenGL_Game.OBJLoader;
//using OpenGL_Game.Scenes;
//using OpenTK;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace OpenGL_Game.Systems
//{
//    class SystemAI :ISystem
//    {
        
//        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_VELOCITY);




//        public SystemAI()
//        {

//        }
//        public string Name
//        {
//            get { return "SystemSphereCollision"; }
//        }

//        public void OnAction(Entity entity)
//        {
//            if ((entity.Mask & MASK) == MASK)
//            {
//                List<IComponent> components = entity.Components;

//                IComponent SphereCollisionComponent = components.Find(delegate (IComponent component)
//                {
//                    return component.ComponentType == ComponentTypes.COMPONENT_SPHERECOLLISION;
//                });
//                // Radius maybe variable

//                //float spherecol = ((ComponentCollisionSphere)CollisionSpherecomponent).Radius;

//                ComponentSphereCollision collision = (ComponentSphereCollision)SphereCollisionComponent;


//                IComponent positionComponent = components.Find(delegate (IComponent component)
//                {
//                    return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
//                });

//                //Vector3 position = ((ComponentPosition)positionComponent).Position;
//                // Matrix4 model = Matrix4.CreateTranslation(position);



//                ComponentPosition position = (ComponentPosition)positionComponent;
//                // ((ComponentCollisionLine)CollisionSpherecomponent).
//                Collision(entity, collision, position);



//                //Calculus((ComponentPosition)positionComponent, (ComponentSphereCollision)SphereCollisionComponent);
//            }
//        }

//        public void Collision(Entity entity, ComponentSphereCollision componentCollisionSphere, ComponentPosition position)
//        {
//            //Add Camera / player entity

//            //Moon Collision
//            if (entity.Name == "Moon")
//            {
//                if ((position.Position - GameScene.gameInstance.camera.cameraPosition).Length < componentCollisionSphere.Radius + GameScene.gameInstance.camera.Radius)
//                {
//                   // System.Console.WriteLine("Collision happening");
//                }
//                else
//                {
//                   // System.Console.WriteLine("Not touchy");
//                }
//            }
//        }

//    }
//}
