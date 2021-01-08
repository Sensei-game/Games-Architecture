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
     
        //not private originally
       private Vector3 target;
       private Points current_target;
       private Vector3 Target;

        //Points CurrentPoint;

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

                //Patrol(entity, position, path);
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

            //if (CurrentPoint != path.Paths.Last())
            //{

            

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
                /// 

                Vector3 newpos = position.Position;

                //different states for following paths and follwing player


                //target sits in place of the foreach Point loop

                if (path.currentstate == ComponentAI.AIstates.idle)
                {
                    path.currentstate = ComponentAI.AIstates.patrol;
                }

                
                //Patrol(entity, position, path);

                

                Alert(entity, position, path);
                //Alert
                //if (path.currentstate == ComponentAI.AIstates.patrol)
                //{ 
                //    target = current_target;
                //}
                //else if(path.currentstate == ComponentAI.AIstates.chase)
                //{
                //    target.point = Target;
                //}
                target = Target;



                if (target.X < position.Position.X)
                {
                    // velocity.Velocity = new Vector3(-0.5f, 0.0f, 0.0f);

                    newpos.X -= a_velocity;
                    newpos.X = (float)Math.Round(newpos.X, 3);

                    // position.Position += new Vector3(5.0f, 1.0f, 7.0f);

                    //position.Position += velocity.Velocity * GameScene.dt;
                }

                if (target.X > position.Position.X)
                {
                    //velocity.Velocity = new Vector3(+0.5f, 0.0f, 0.0f);
                    //position.Position += velocity.Velocity * GameScene.dt;

                    newpos.X += a_velocity;
                    newpos.X = (float)Math.Round(newpos.X, 3);

                }

                if (target.Z < position.Position.Z)
                {
                    //velocity.Velocity = new Vector3(0.0f, 0.0f, -0.5f);
                    // position.Position += velocity.Velocity * GameScene.dt;

                    newpos.Z -= a_velocity;
                    newpos.Z = (float)Math.Round(newpos.Z, 3);
                }

                if (target.Z > position.Position.Z)
                {
                    // velocity.Velocity = new Vector3(0.0f, 0.0f, +0.5f);
                    //position.Position += velocity.Velocity * GameScene.dt;

                    newpos.Z += a_velocity;
                    newpos.Z = (float)Math.Round(newpos.Z, 3);
                }
                // position.Position += velocity.Velocity * GameScene.dt;   position.Position = same postion + const velocity+GameScene.dt;

                position.Position = newpos;

            }
            //}
        }

        private void Patrol(Entity entity, ComponentPosition position, ComponentAI state)
        {
            //if()entity name =
            if (state.currentstate == ComponentAI.AIstates.patrol)
            {
                foreach (Points Point in state.list_paths)
                {
                    //if(low_alert == true)
                    //{
                    //    low_alert = false;



                    //}
                    //else

                    //difference of position, not checking if is at the end of the list of points
                    if (position.Position == Point.point)
                    {
                        //CurrentPoint = Point;
                        if (state.list_paths.Count == state.list_paths.IndexOf(Point) + 1)
                        {
                            current_target = state.list_paths.ElementAt(0);
                           // target = current_target;
                            break;
                        }

                        //NEW target is the current Point 

                        else
                        {
                            current_target = state.list_paths.ElementAt(state.list_paths.IndexOf(Point) + 1);
                            //target = current_target;
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

        private void Alert(Entity entity, ComponentPosition position, ComponentAI state)
        {
             if(state.currentstate != ComponentAI.AIstates.disabled)
             {
                if(Vector3.Distance(position.Position, GameScene.gameInstance.oldposition) < 5.0f)
                {
                    state.currentstate = ComponentAI.AIstates.chase;
                    System.Console.WriteLine(state.currentstate);

                   Target = GameScene.gameInstance.oldposition;
                    
                    // target.point = GameScene.gameInstance.oldposition;
                }
                else if(Vector3.Distance(position.Position, GameScene.gameInstance.oldposition) >= 5.0f)
                {
                    state.currentstate = ComponentAI.AIstates.patrol;
                    System.Console.WriteLine(state.currentstate);
                    Patrol(entity, position, state);
                    //  low_alert = true;

                    Target = current_target.point;


                }
             }
        }

    }
}
