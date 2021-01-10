using System;
using System.Collections.Generic;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenGL_Game.Components;
using OpenGL_Game.OBJLoader;
using OpenGL_Game.Objects;
using OpenGL_Game.Scenes;
using System.Linq;

namespace OpenGL_Game.Systems
{
    class SystemPhysics : ISystem
    {
        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_VELOCITY);


        private Vector3 newpos;
        private const float a_velocity = 0.02f;
        private float target;
        
       
        //protected int pgmID;
        //protected int vsID;
        //protected int fsID;
        //protected int uniform_stex;
        //protected int uniform_mmodelviewproj;
        //protected int uniform_mmodel;
        //protected int uniform_diffuse;  // OBJ NEW

        public SystemPhysics()
        {
            //pgmID = GL.CreateProgram();
            //LoadShader("Shaders/vs.glsl", ShaderType.VertexShader, pgmID, out vsID);
            //LoadShader("Shaders/fs.glsl", ShaderType.FragmentShader, pgmID, out fsID);
            //GL.LinkProgram(pgmID);
            //Console.WriteLine(GL.GetProgramInfoLog(pgmID));

            //uniform_stex = GL.GetUniformLocation(pgmID, "s_texture");
            //uniform_mmodelviewproj = GL.GetUniformLocation(pgmID, "ModelViewProjMat");
            //uniform_mmodel = GL.GetUniformLocation(pgmID, "ModelMat");
            //uniform_diffuse = GL.GetUniformLocation(pgmID, "v_diffuse");     // OBJ NEW
        }

       
        
        //void LoadShader(String filename, ShaderType type, int program, out int address)
        //{
        //    address = GL.CreateShader(type);
        //    using (StreamReader sr = new StreamReader(filename))
        //    {
        //        GL.ShaderSource(address, sr.ReadToEnd());
        //    }
        //    GL.CompileShader(address);
        //    GL.AttachShader(program, address);
        //    Console.WriteLine(GL.GetShaderInfoLog(address));
        //}

        public string Name
        {
            get { return "SystemPhysics"; }
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

               // Vector3 velocity = ((ComponentVelocity)velocityComponent).Velocity;

                IComponent positionComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                });


                //  Vector3 position = ((ComponentPosition)positionComponent).Position;
                //Matrix4 model = Matrix4.CreateTranslation(position);


                //replace OnAction pos and model with Motion and change parameters
                Motion(entity, (ComponentPosition)positionComponent);
            }
        }

        private void Motion(Entity entity, ComponentPosition position)
        {
            //chnage to switch case
            switch(entity.Name)
            {
                case "Blue 1":
                    Calculate(position);
                    break;

                case "Blue 2":
                    Calculate(position);
                    break;

                case "Blue 3":
                    Calculate(position);
                    break;

                case "Blue 4":
                    Calculate(position);
                    break;

                case "Blue 5":
                    Calculate(position);
                    break;
                case "Blue 6":
                    Calculate(position);
                    break;

                default:break;
            }           
        }
        private void Calculate(ComponentPosition position)
        {
            newpos = position.Position;

            if (position.Position.Y == target)
            {
                if (target == 1.2f)
                {
                    target = 0.0f;
                }
                else
                {
                    target = 1.2f;
                }
            }

            if (position.Position.Y > target)
            {
                newpos.Y -= a_velocity /** GameScene.dt*/;
                newpos.Y = (float)Math.Round(newpos.Y, 3);
            }

            if (position.Position.Y < target)
            {
                newpos.Y += a_velocity /** GameScene.dt*/;
                newpos.Y = (float)Math.Round(newpos.Y, 3);
            }
            position.Position = newpos;
        }
    }
}
