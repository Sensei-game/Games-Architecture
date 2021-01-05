﻿using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenGL_Game.Components;
using OpenGL_Game.Systems;
using OpenGL_Game.Managers;
using OpenGL_Game.Objects;
using System.Drawing;
using System;
using System.Collections.Generic;
using OpenTK.Audio.OpenAL;

namespace OpenGL_Game.Scenes
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    class GameScene : Scene
    {
        public static float dt = 0;
        EntityManager entityManager;
        SystemManager systemManager;
       

        bool[] keysPressed = new bool[255];

        public Camera camera;
        public Vector3 oldposition;

        public static GameScene gameInstance;

        //public CollisionManager SpherecollisionManager;
        //public CollisionManager LinecollisionManager;

        Vector3 sourcePosition;

        public GameScene(SceneManager sceneManager) : base(sceneManager)
        {
           gameInstance = this;
           entityManager = new EntityManager();
           systemManager = new SystemManager();

           //SpherecollisionManager = new SphereCollisionManager();
           // LinecollisionManager = new LineCollisionManager();
               
            // Set the title of the window
            sceneManager.Title = "Game";

            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;

            // Set Keyboard events to go to a method in this class
            sceneManager.keyboardDownDelegate += Keyboard_KeyDown;
            sceneManager.keyboardUpDelegate += Keyboard_KeyUp;

            // Enable Depth Testing
            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            // Set Camera
            camera = new Camera(new Vector3(0.0f, 1.0f, 7.0f), new Vector3(0.0f, 1.0f, 0.0f), 1.5f ,(float)(sceneManager.Width) / (float)(sceneManager.Height), 0.1f, 100f);
            // oldposition = camera.cameraPosition;

            sourcePosition = new Vector3(-5.0f, 1.0f, 0.0f);

            CreateEntities();
            CreateSystems();

            // TODO: Add your initialization logic here

        }

        private void CreateEntities()
        {
            Entity newEntity;
            List<Coordinates> list = LimitList();
            List<Points> path = PathList();


            newEntity = new Entity("Moon");
            newEntity.AddComponent(new ComponentPosition(-5.0f, 1.0f, 0.0f));
            newEntity.AddComponent(new ComponentVelocity(0.0f, +0.05f, 0.0f));
            //newEntity.AddComponent(new ComponentAudio("Audio/buzz.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1.8f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Moon/moon.obj"));
            entityManager.AddEntity(newEntity);


            newEntity = new Entity("Maze");
            newEntity.AddComponent(new ComponentPosition(28.0f, 0.0f, -25.0f));
            newEntity.AddComponent(new ComponentLineCollision(list));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Maze/maze.obj"));
            entityManager.AddEntity(newEntity);


            newEntity = new Entity("Wraith_Raider_Starship");
            newEntity.AddComponent(new ComponentPosition(5.0f, 0.0f, 0.0f));
            // newEntity.AddComponent(new ComponentVelocity(0.0f, 0.0f, +5.0f));

            newEntity.AddComponent(new ComponentAudio("Audio/buzz.wav"));
            newEntity.AddComponent(new ComponentAI(path));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Wraith_Raider_Starship/Wraith_Raider_Starship.obj"));
            entityManager.AddEntity(newEntity);


            newEntity = new Entity("Intergalactic_Spaceship");
            //newEntity.AddComponent(new ComponentVelocity(0.0f, 0.0f, +0.7f));
            newEntity.AddComponent(new ComponentPosition(0.0f, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Intergalactic_Spaceship/Intergalactic_Spaceship.obj"));
            entityManager.AddEntity(newEntity);
        }

        private List<Coordinates> LimitList()
        {
            List<Coordinates> limits = new List<Coordinates>();
            limits.Add(new Coordinates(new Vector3(-3.04f, 1.00f, 11.06f), new Vector3(-2.87f, 1.00f, 20.80f)));

            return limits;
        }

        private List<Points> PathList()
        {
            List<Points> points = new List<Points>();

            points.Add(new Points(new Vector3(5.0f, 0.0f, 0.0f))); //initial position of the entity
            points.Add(new Points(new Vector3(5.0f, 0.0f, 7.0f)));  // target position
            points.Add(new Points(new Vector3(-0.5f, 0.0f, 24.15f)));
            points.Add(new Points(new Vector3(0.0f, 0.0f, 0.0f)));

            return points;
        }
       
        
        //lIST OF POSITIONS/nODES FOR ai

        //2Collision Sphere one actuall collision one for the player
        
        // Nodes for patrolls, when player is near follow Player position, give it more Velocity(in a manager)

        // Add LineCollision COmponent to ghosts 

        private void CreateSystems()
        {
            ISystem newSystem;

            newSystem = new SystemRender();
            systemManager.AddSystem(newSystem);

            newSystem = new SystemPhysics();
            systemManager.AddSystem(newSystem);

            // Add System Collision here

            newSystem = new SystemSphereCollision();
            systemManager.AddSystem(newSystem);

            newSystem = new SystemLineCollision();
            systemManager.AddSystem(newSystem);

            // Add System AI here

            newSystem = new SystemAI();
            systemManager.AddSystem(newSystem);

            newSystem = new SystemAudio();
            systemManager.AddSystem(newSystem);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="e">Provides a snapshot of timing values.</param>
        
        public override void Update(FrameEventArgs e)
        {
            dt = (float)e.Time;
         //   System.Console.WriteLine("fps=" + (int)(1.0/dt));

            //check position of player/camera
          //  System.Console.WriteLine("x =" + (float)camera.cameraPosition.X + " , y =" + (float)camera.cameraPosition.Y + " , z =" + (float)camera.cameraPosition.Z);
         
            oldposition = camera.cameraPosition;

            // NEW for Audio
            // Update OpenAL Listener Position and Orientation based on the camera
            AL.Listener(ALListener3f.Position, ref camera.cameraPosition);
            AL.Listener(ALListenerfv.Orientation, ref camera.cameraDirection, ref camera.cameraUp);


            if (GamePad.GetState(1).Buttons.Back == ButtonState.Pressed)
                sceneManager.Exit();

            if (keysPressed[(char)Key.Up])
            {
                camera.MoveForward(0.1f);
            }

            if (keysPressed[(char)Key.Down])
            {
                camera.MoveForward(-0.1f);
            }

            if (keysPressed[(char)Key.Left])
            {
                camera.RotateY(-0.01f);
            }

            if (keysPressed[(char)Key.Right])
            {
                camera.RotateY(0.01f);
            }


            //Press M to game OVER
            if (keysPressed[(char)Key.M])
            {
                sceneManager.ChangeScene((SceneTypes)3);
            }

            // press key for calling Change Scene in SceneManager
            //Press K for Main Menu

            if (keysPressed[(char)Key.K])
            {
                sceneManager.ChangeScene((SceneTypes)1);
            }

            if(keysPressed[(char)Key.P])
            {

            }

            if (keysPressed[(char)Key.W])
            {
                camera.RotateZ(0.01f);
            }

            if (keysPressed[(char)Key.S])
            {
                camera.RotateZ(-0.01f);
            }

        }

        // TODO: Add your update logic here

    

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="e">Provides a snapshot of timing values.</param>
        
        public override void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Width, sceneManager.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Action ALL systems
            systemManager.ActionSystems(entityManager);

            // Render score
            float width = sceneManager.Width, height = sceneManager.Height, fontSize = Math.Min(width, height) / 10f;
            GUI.clearColour = Color.Transparent;
            GUI.Label(new Rectangle(0, 0, (int)width, (int)(fontSize * 2f)), "Score: 000", 18, StringAlignment.Near, Color.White);
            GUI.Render();
        }

        /// <summary>
        /// This is called when the game exits.
        /// </summary>
       
        public override void Close()
        {
            sceneManager.keyboardDownDelegate -= Keyboard_KeyDown;

            sceneManager.keyboardUpDelegate -= Keyboard_KeyUp;

            // NEW for Audio
            entityManager.CloseAllEntities();

            ResourceManager.RemoveAllAssets();
        }

        public void Keyboard_KeyDown(KeyboardKeyEventArgs e)
        {
            
            keysPressed[(char)e.Key] = true;


            // Copy this in Update() and replace the argument with the KeyPressed bool array

            /*
             switch (e.Key)
            {
                case Key.Up:
                    camera.MoveForward(0.1f);
                    break;
                case Key.Down:
                    camera.MoveForward(-0.1f);
                    break;
                case Key.Left:
                    camera.RotateY(-0.01f);
                    break;
                case Key.Right:
                    camera.RotateY(0.01f);
                    break;

                    //Press M to game OVER
                case Key.M:
                    sceneManager.ChangeScene((SceneTypes)3);
                    break;

                // case key for calling Change Scene in SceneManager

                //Press K for Main Menu
                case Key.K:
                    sceneManager.ChangeScene((SceneTypes)1);
                    break;
            
            }*/
        }
         
        public void Keyboard_KeyUp(KeyboardKeyEventArgs e)
        {
            keysPressed[(char)e.Key] = false;
        }
    }
}
