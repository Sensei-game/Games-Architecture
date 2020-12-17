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

        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_AI);
        //private bool confirm = false;

        const float a_velocity = 0.05f;
        Points target;
        Points CurrentPoint;

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

                //Wandering(entity, position, path);
                MoveAI(entity, /*velocity,*/ position, path);
            }
        }

        private void MoveAI(Entity entity, /*ComponentVelocity velocity,*/ ComponentPosition position, ComponentAI path)
        {
            // switch(entity.Name)
            //{
            //    case "Wraith_Raider_Starship":
            //        break;
            //    default:break;
            //}

            if (CurrentPoint != path.Paths.Last())
            {
                Vector3 newpos = position.Position;

                if (entity.Name == "Wraith_Raider_Starship")
                {
                    ///<summary>
                    ///for (int i = 0; i < path.list_paths.Count; i++)
                    ///{
                    ///    while (confirm != true) confirm will be a bool value
                    /// {
                    ///        same code for changing the Velocity
                    ///        different code or variable for when you reach the point ?
                    /// }
                    ///}
                    ///if ((Point.point.X == position.Position.X) && (Point.point.Z == position.Position.Z))
                    ///    {
                    ///        System.Console.WriteLine("WE HAVE REACHED DESTINATION");
                    ///        // confirm = true;
                    ///        //path.list_paths.Remove(Point);
                    ///    }
                    ///
                    /// </summary>

                    //different states for following paths and follwing player

                    //target sits in place of the foreach Point loop

                    Wandering(entity, position, path);


                    if (target.point.X < position.Position.X)
                    {
                        // velocity.Velocity = new Vector3(-0.5f, 0.0f, 0.0f);

                        newpos.X -= a_velocity;
                        newpos.X = (float)Math.Round(newpos.X, 3);

                        // position.Position += new Vector3(5.0f, 1.0f, 7.0f);

                        //position.Position += velocity.Velocity * GameScene.dt;
                    }

                    if (target.point.X > position.Position.X)
                    {
                        //velocity.Velocity = new Vector3(+0.5f, 0.0f, 0.0f);
                        //position.Position += velocity.Velocity * GameScene.dt;

                        newpos.X += a_velocity;
                        newpos.X = (float)Math.Round(newpos.X, 3);

                    }

                    if (target.point.Z < position.Position.Z)
                    {
                        //velocity.Velocity = new Vector3(0.0f, 0.0f, -0.5f);
                        // position.Position += velocity.Velocity * GameScene.dt;

                        newpos.Z -= a_velocity;
                        newpos.Z = (float)Math.Round(newpos.Z, 3);
                    }

                    if (target.point.Z > position.Position.Z)
                    {
                        // velocity.Velocity = new Vector3(0.0f, 0.0f, +0.5f);
                        //position.Position += velocity.Velocity * GameScene.dt;

                        newpos.Z += a_velocity;
                        newpos.Z = (float)Math.Round(newpos.Z, 3);
                    }
                    // position.Position += velocity.Velocity * GameScene.dt;   position.Position = same postion + const velocity+GameScene.dt;

                    position.Position = newpos;
                }
            }
        }

        private void Wandering(Entity entity, ComponentPosition position, ComponentAI state)
        {
            if (state.currentstate == ComponentAI.AIstates.idle)
            {
                foreach (Points Point in state.list_paths)
                {
                    //difference of position, not checking if is at the end of the list of points
                    if (position.Position == Point.point)
                    {
                        CurrentPoint = Point;
                        if (state.list_paths.Count == state.list_paths.IndexOf(Point) + 1)
                        {
                            target = state.list_paths.ElementAt(0);
                            break;
                        }

                        //NEW target is the current Point 

                        else
                        {
                            target = state.list_paths.ElementAt(state.list_paths.IndexOf(Point) + 1);
                            break;
                        }
                    }
                    //else
                    //{
                    //    target = state.list_paths.ElementAt(state.list_paths.IndexOf(Point) + 2);
                    //    break;
                    //}
                }
            }
        }

    }
}
