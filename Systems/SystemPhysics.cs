using System;
using System.Collections.Generic;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenGL_Game.Components;
using OpenGL_Game.OBJLoader;
using OpenGL_Game.Objects;
using OpenGL_Game.Scenes;



namespace OpenGL_Game.Systems
{
    class SystemPhysics : ISystem
    {
        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_VELOCITY);

        /// <summary>
       
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

                Motion((ComponentVelocity)velocityComponent, (ComponentPosition)positionComponent);
            }
        }

        private void Motion(ComponentVelocity velocity, ComponentPosition position)
        {

            position.Position += velocity.Velocity * GameScene.dt;
        }
    }
}
