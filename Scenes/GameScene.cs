using OpenTK;
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
        public EntityManager entityManager;
        SystemManager systemManager;
       

        bool[] keysPressed = new bool[255];

        public Camera camera;
        public Vector3 oldposition;

        public static GameScene gameInstance;

        public int count = 0;
        public int score = 000;
        public int life = 3;

        private bool AI_Debug = false;
        private bool LINE_Debug = false;

        //public CollisionManager SpherecollisionManager;
        //public CollisionManager LinecollisionManager;

        //Vector3 sourcePosition;

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
            camera = new Camera(new Vector3(0.0f, 1.0f, 7.0f), new Vector3(0.0f, 1.0f, 0.0f), 0.5f ,(float)(sceneManager.Width) / (float)(sceneManager.Height), 0.1f, 100f);
            // oldposition = camera.cameraPosition;

            //sourcePosition = new Vector3(-5.0f, 1.0f, 0.0f);

            CreateEntities();
            CreateSystems();

            // TODO: Add your initialization logic here

        }

        private void CreateEntities()
        {
            Entity newEntity;
            List<Coordinates> list = LimitList();
            List<Points> path = PathList();

            newEntity = new Entity("Blue 1");
            newEntity.AddComponent(new ComponentPosition(-5.0f, 1.0f, 0.0f));
            newEntity.AddComponent(new ComponentVelocity(0.0f, +0.05f, 0.0f));
            newEntity.AddComponent(new ComponentAudio("Audio/buzz.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Blue Orb/Fixed Blue Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Blue 2");
            newEntity.AddComponent(new ComponentPosition(-14.34f, 1.0f, -10.01f));
            newEntity.AddComponent(new ComponentVelocity(0.0f, +0.05f, 0.0f));
            newEntity.AddComponent(new ComponentAudio("Audio/buzz.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Blue Orb/Fixed Blue Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Blue 3");
            newEntity.AddComponent(new ComponentPosition(-15.10f, 1.0f, 18.32f));
            newEntity.AddComponent(new ComponentVelocity(0.0f, +0.05f, 0.0f));
            newEntity.AddComponent(new ComponentAudio("Audio/buzz.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Blue Orb/Fixed Blue Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Blue 4");
            newEntity.AddComponent(new ComponentPosition(14.23f, 1.0f, 17.19f));
            newEntity.AddComponent(new ComponentVelocity(0.0f, +0.05f, 0.0f));
            newEntity.AddComponent(new ComponentAudio("Audio/buzz.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Blue Orb/Fixed Blue Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Blue 5");
            newEntity.AddComponent(new ComponentPosition(14.14f, 1.0f, -11.02f));
            newEntity.AddComponent(new ComponentVelocity(0.0f, +0.05f, 0.0f));
            newEntity.AddComponent(new ComponentAudio("Audio/buzz.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Blue Orb/Fixed Blue Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 1");
            newEntity.AddComponent(new ComponentPosition(5.0f, 0.5f, 0.0f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 2");
            newEntity.AddComponent(new ComponentPosition(-25.08f, 0.5f, -11.98f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 3");
           // newEntity.AddComponent(new ComponentPosition(-25.65f, 0.5f, -19.30f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 4");
            newEntity.AddComponent(new ComponentPosition(-16.42f, 0.5f, -21.72f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 5");
            newEntity.AddComponent(new ComponentPosition(-26.95f, 0.5f, -21.62f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 6");
            newEntity.AddComponent(new ComponentPosition(-21.45f, 0.5f, -21.54f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 7");
            newEntity.AddComponent(new ComponentPosition(-26.77f, 0.5f, -16.77f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 8");
            newEntity.AddComponent(new ComponentPosition(-20.28f, 0.5f, -4.86f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 9");
            newEntity.AddComponent(new ComponentPosition(-20.30f, 0.5f, 0.83f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 10");
            newEntity.AddComponent(new ComponentPosition(-20.33f, 0.5f, 9.23f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 11");
            newEntity.AddComponent(new ComponentPosition(-20.35f, 0.5f, 16.03f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 12");
            newEntity.AddComponent(new ComponentPosition(-27.21f, 0.5f, 30.21f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 13");
            newEntity.AddComponent(new ComponentPosition(-26.44f, 0.5f, 25.38f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 14");
            newEntity.AddComponent(new ComponentPosition(-26.36f, 0.5f, 19.78f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 15");
            newEntity.AddComponent(new ComponentPosition(-21.84f, 0.5f, 29.72f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 16");
            newEntity.AddComponent(new ComponentPosition(-16.24f, 0.5f, 29.47f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 17");
            newEntity.AddComponent(new ComponentPosition(-10.22f, 0.5f, 23.43f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 18");
            newEntity.AddComponent(new ComponentPosition(-3.20f, 0.5f, 23.57f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 19");
            newEntity.AddComponent(new ComponentPosition(4.42f, 0.5f, 23.73f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 20");
            newEntity.AddComponent(new ComponentPosition(11.95f, 0.5f, 23.66f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 21");
            newEntity.AddComponent(new ComponentPosition(25.91f, 0.5f, 29.37f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 22");
            newEntity.AddComponent(new ComponentPosition(21.01f, 0.5f, 29.14f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 23");
            newEntity.AddComponent(new ComponentPosition(15.12f, 0.5f, 28.93f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 24");
            newEntity.AddComponent(new ComponentPosition(25.55f, 0.5f, 23.85f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 25");
            newEntity.AddComponent(new ComponentPosition(25.26f, 0.5f, 18.36f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 26");
            newEntity.AddComponent(new ComponentPosition(19.62f, 0.5f, 15.62f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 27");
            newEntity.AddComponent(new ComponentPosition(19.59f, 0.5f, 9.29f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 28");
            newEntity.AddComponent(new ComponentPosition(19.57f, 0.5f, 2.09f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 29");
            newEntity.AddComponent(new ComponentPosition(19.55f, 0.5f, -6.00f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 30");
            newEntity.AddComponent(new ComponentPosition(25.25f, 0.5f, -22.11f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 31");
            newEntity.AddComponent(new ComponentPosition(19.65f, 0.5f, -22.06f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 32");
            newEntity.AddComponent(new ComponentPosition(14.55f, 0.5f, -22.10f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 33");
            newEntity.AddComponent(new ComponentPosition(25.66f, 0.5f, -16.17f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 34");
            newEntity.AddComponent(new ComponentPosition(25.56f, 0.5f, -11.07f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 35");
            newEntity.AddComponent(new ComponentPosition(9.73f, 0.5f, -16.58f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 36");
            newEntity.AddComponent(new ComponentPosition(2.74f, 0.5f, -16.98f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 37");
            newEntity.AddComponent(new ComponentPosition(-3.42f, 0.5f, -16.71f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Yellow 38");
            newEntity.AddComponent(new ComponentPosition(-10.41f, 0.5f, -16.44f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Maze");
            newEntity.AddComponent(new ComponentPosition(28.0f, -0.5f, -25.0f));
            newEntity.AddComponent(new ComponentLineCollision(list));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Maze/maze.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Ground");
            newEntity.AddComponent(new ComponentPosition(26.5f, 0.80f, -24.0f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Ground/ground final.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Ghost");
            newEntity.AddComponent(new ComponentPosition(5.0f, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro super.wav"));
            newEntity.AddComponent(new ComponentAI(path));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Ghost/Dumb Ghost.obj"));
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
            //System.Console.WriteLine("fps=" + (int)(1.0/dt));

            //check position of player/camera
            System.Console.WriteLine("x =" + (float)camera.cameraPosition.X + " , y =" + (float)camera.cameraPosition.Y + " , z =" + (float)camera.cameraPosition.Z);
         
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

            if (keysPressed[(char)Key.W])
            {
                camera.RotateZ(0.01f);
            }

            if (keysPressed[(char)Key.S])
            {
                camera.RotateZ(-0.01f);
            }

            if (keysPressed[(char)Key.Number1])
            {
                //Ai
                if (SystemAI.a_velocity == 0.05f)
                {
                    SystemAI.a_velocity = 0.00f;
                    AI_Debug = true;
                }
                else
                {
                    SystemAI.a_velocity = 0.05f;
                    AI_Debug = false;
                }
            }

            if (keysPressed[(char)Key.Number2])
            {
                //Line
                if (LineCollisionManager.debug_line == false)
                {
                    LineCollisionManager.debug_line = true;
                }
                else
                {
                    LineCollisionManager.debug_line = false;
                }
            }

            if (life <= 0)
            {
                sceneManager.ChangeScene((SceneTypes)3);
            }

            if(count >= 42)
            {
                sceneManager.ChangeScene((SceneTypes)3);
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

            // Render score and life
            float width = sceneManager.Width, height = sceneManager.Height, fontSize = Math.Min(width, height) / 10f;
            GUI.clearColour = Color.Transparent;
            GUI.Label(new Rectangle(0, 0, (int)width, (int)(fontSize * 2f)), "Score: " + score, 18, StringAlignment.Near, Color.GreenYellow);
            GUI.Label(new Rectangle(0, 25, (int)width, (int)(fontSize * 2f)), "AI_Debug Mode: " + AI_Debug, 18, StringAlignment.Near, Color.White);
            GUI.Label(new Rectangle(0, 60, (int)width, (int)(fontSize * 2f)), "AI_LineCollsion Mode: " + LineCollisionManager.debug_line, 18, StringAlignment.Near, Color.White);
            GUI.Label(new Rectangle(700, 15, (int)width, (int)(fontSize * 2f)), "Lifes: " + life, 18, StringAlignment.Near, Color.Coral);
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
