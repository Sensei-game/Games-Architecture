using OpenGL_Game.Components;
using OpenGL_Game.Objects;
using OpenGL_Game.Scenes;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenGL_Game.Systems
{
    class SystemAI : ISystem
    {

        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_AI);
        //private bool confirm = false;

       public static float a_velocity = 0.05f;
     
        //not private originally
       private Vector3 target;
       private Points current_target;
        private Points current_target2;
        private Points current_target3;
        private Points current_target4;
        private Points pass;

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

                MoveAI(entity, position, path);
            }
        }

        private void MoveAI(Entity entity, ComponentPosition position, ComponentAI path)
        {
            // switch(entity.Name)
            //{
            //    case "Wraith_Raider_Starship":
            //        break;
            //    default:break;
            //}

            //if (CurrentPoint != path.Paths.Last())
            //{


            Vector3 newpos = position.Position;
            
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


                


                //different states for following paths and follwing player


                //target sits in place of the foreach Point loop

                if (path.currentstate == ComponentAI.AIstates.idle)
                {
                    path.currentstate = ComponentAI.AIstates.patrol;
                }

                
                //Patrol(entity, position, path);

                

                
                //Alert
                //if (path.currentstate == ComponentAI.AIstates.patrol)
                //{ 
                //    target = current_target;
                //}
                //else if(path.currentstate == ComponentAI.AIstates.chase)
                //{
                //    target.point = Target;
                //}

            //lista 1 schimbata de lista 2 fa o diferentiere
            
                Alert1(entity, position.Position, path);
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

            
            //}
        }

        private void Patrol(Entity entity, Vector3 position, ComponentAI state)
        {
            //if()entity name =

            switch(entity.Name)
            {
                case "Ghost 1":
                    Ghost1(position, state);
                    pass = current_target;
                    break;

                case "Ghost 2":
                    Ghost2(position, state);
                    pass = current_target2;
                    break;

                case "Ghost 3":
                    Ghost3(position, state);
                    pass = current_target3;
                    break;

                case "Ghost 4":
                    Ghost4(position, state);
                    pass = current_target4;
                    break;

            }
            //change current_target for each Ghost
            //Ghost1
                      
        }

        private void Alert1(Entity entity,Vector3 position, ComponentAI state)
        {
             if(state.currentstate != ComponentAI.AIstates.disabled)
             {
                if(Vector3.Distance(position, GameScene.gameInstance.oldposition) < 5.0f)
                {
                    state.currentstate = ComponentAI.AIstates.chase;
                   // System.Console.WriteLine(state.currentstate);

                   Target = GameScene.gameInstance.oldposition;
                    
                    // target.point = GameScene.gameInstance.oldposition;
                }
                else if(Vector3.Distance(position, GameScene.gameInstance.oldposition) >= 5.0f)
                {
                    state.currentstate = ComponentAI.AIstates.patrol;
                   // System.Console.WriteLine(state.currentstate);
                    Patrol(entity, position, state);
                    //  low_alert = true;

                    Target = pass.point;
                }
             }
        }

        private void Ghost1(Vector3 position, ComponentAI state)
        {
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
                    if (position == Point.point)
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

        private void Ghost2(Vector3 position, ComponentAI state)
        {
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
                    if (position == Point.point)
                    {
                        //CurrentPoint = Point;
                        if (state.list_paths.Count == state.list_paths.IndexOf(Point) + 1)
                        {
                            current_target2 = state.list_paths.ElementAt(0);
                            // target = current_target;
                            break;
                        }

                        //NEW target is the current Point 

                        else
                        {
                            current_target2 = state.list_paths.ElementAt(state.list_paths.IndexOf(Point) + 1);
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
        private void Ghost3(Vector3 position, ComponentAI state)
        {
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
                    if (position == Point.point)
                    {
                        //CurrentPoint = Point;
                        if (state.list_paths.Count == state.list_paths.IndexOf(Point) + 1)
                        {
                            current_target3 = state.list_paths.ElementAt(0);
                            // target = current_target;
                            break;
                        }

                        //NEW target is the current Point 

                        else
                        {
                            current_target3 = state.list_paths.ElementAt(state.list_paths.IndexOf(Point) + 1);
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

        private void Ghost4(Vector3 position, ComponentAI state)
        {
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
                    if (position == Point.point)
                    {
                        //CurrentPoint = Point;
                        if (state.list_paths.Count == state.list_paths.IndexOf(Point) + 1)
                        {
                            current_target4 = state.list_paths.ElementAt(0);
                            // target = current_target;
                            break;
                        }

                        //NEW target is the current Point 

                        else
                        {
                            current_target4 = state.list_paths.ElementAt(state.list_paths.IndexOf(Point) + 1);
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
    }
}

