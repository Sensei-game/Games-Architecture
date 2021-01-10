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

            List<Points> path1 = PathList1();
            
            List<Points> path2 = PathList2();

            List<Points> path3 = PathList3();

            List<Points> path4 = PathList4();

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

            newEntity = new Entity("Blue 6");
            newEntity.AddComponent(new ComponentPosition(5.46f, 1.0f, 9.14f));
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
            newEntity.AddComponent(new ComponentPosition(-25.65f, 0.5f, -19.30f));
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

            newEntity = new Entity("Yellow 39");
            newEntity.AddComponent(new ComponentPosition(-5.65f, 0.5f, 9.16f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro points.wav"));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Yellow Orb/Fixed Yellow Orb.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Maze");
            newEntity.AddComponent(new ComponentPosition(28.0f, -0.5f, -25.0f));
            newEntity.AddComponent(new ComponentLineCollision(list));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Maze/maze.obj"));
            entityManager.AddEntity(newEntity);

            //newEntity = new Entity("Skybox");
            //newEntity.AddComponent(new ComponentPosition(0.0f, 0.0f, 0.0f));
            //newEntity.AddComponent(new ComponentGeometry("Geometry/Skybox/sky54.obj"));
            //entityManager.AddEntity(newEntity);

            newEntity = new Entity("Ground");
            newEntity.AddComponent(new ComponentPosition(26.5f, 0.80f, -24.0f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Ground/ground final.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Ghost 1");
            newEntity.AddComponent(new ComponentPosition(5.0f, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro super.wav"));
            newEntity.AddComponent(new ComponentAI(path1));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Ghost/Dumb Ghost.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Ghost 2");
            newEntity.AddComponent(new ComponentPosition(-5.50f, 0.1f, 9.50f));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro super.wav"));
            newEntity.AddComponent(new ComponentAI(path2));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Ghost/Dumb Ghost.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Ghost 3");
            newEntity.AddComponent(new ComponentPosition(-5.15f, 0.1f, -1.75f));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro super.wav"));
            newEntity.AddComponent(new ComponentAI(path3));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Ghost/Dumb Ghost.obj"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Ghost 4");
            newEntity.AddComponent(new ComponentPosition(5.25f, 0.2f, 9.25f));
            newEntity.AddComponent(new ComponentSphereCollision(1f));
            newEntity.AddComponent(new ComponentAudio("Audio/Retro super.wav"));
            newEntity.AddComponent(new ComponentAI(path4));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Ghost/Dumb Ghost.obj"));
            entityManager.AddEntity(newEntity);

        }

        private List<Coordinates> LimitList()
        {
            List<Coordinates> limits = new List<Coordinates>();

            limits.Add(new Coordinates(new Vector3(-3.04f, 1.00f, 11.06f), new Vector3(-2.87f, 1.00f, 20.80f)));
            limits.Add(new Coordinates(new Vector3(-17.71f, 1.00f, 15.47f), new Vector3(-13.02f, 1.00f, 15.52f)));
            limits.Add(new Coordinates(new Vector3(-13.02f, 1.00f, 15.52f), new Vector3(-12.78f, 1.00f, 20.70f)));
            limits.Add(new Coordinates(new Vector3(-12.78f, 1.00f, 20.70f), new Vector3(-2.87f, 1.00f, 20.80f)));
            //WHY DO THEY NOT WORK
            limits.Add(new Coordinates(new Vector3(2.35f, 1f, -14.01f), new Vector3(10.95f, 1f, -13.92f)));
            limits.Add(new Coordinates(new Vector3(-7.57f, 1f,11.11f), new Vector3(-2.81f, 1f, 11.19f)));
            limits.Add(new Coordinates(new Vector3(-8.12f, 1f, 5.74f), new Vector3(-7.57f, 1f, 11.11f)));
            limits.Add(new Coordinates(new Vector3(-17.55f, 1f, 5.69f), new Vector3(-8.12f, 1f, 5.74f)));
            limits.Add(new Coordinates(new Vector3(-18.28f, 1f, 5.69f), new Vector3(-17.55f, 1f, 15.78f)));

            limits.Add(new Coordinates(new Vector3(-22.64f, 1f, -8.75f), new Vector3(-22.59f, 1f, 15.88f)));
            limits.Add(new Coordinates(new Vector3(-27.77f, 1f, 16.20f), new Vector3(-23.14f, 1f, 16.54f)));
            limits.Add(new Coordinates(new Vector3(-27.77f, 1f, 16.20f), new Vector3(-27.58f, 1f, 30.81f)));
            limits.Add(new Coordinates(new Vector3(-27.58f, 1f, 30.53f), new Vector3(-13.29f,1f,30.81f)));
            limits.Add(new Coordinates(new Vector3(-13.39f,1f,26.03f), new Vector3(-13.28f, 1f, 30.22f)));

            limits.Add(new Coordinates(new Vector3(-12.90f, 1f, 25.65f), new Vector3(11.99f,1f,25.74f)));
            limits.Add(new Coordinates(new Vector3(12.50f, 1f, 26.12f), new Vector3(12.61f,1f,30.87f)));
            limits.Add(new Coordinates(new Vector3(12.39f, 1f, 30.49f), new Vector3(26.76f, 1f, 30.79f)));
            limits.Add(new Coordinates(new Vector3(26.46f, 1f, 16.14f), new Vector3(26.50f, 1f, 30.49f)));
            limits.Add(new Coordinates(new Vector3( 21.96f, 1f, 16.28f), new Vector3(26.65f, 1f, 16.64f)));

            limits.Add(new Coordinates(new Vector3(21.55f, 1f, -9.01f), new Vector3(21.60f, 1f, 15.90f)));
            limits.Add(new Coordinates(new Vector3(22.02f, 1f,  -9.52f), new Vector3(26.79f, 1f, -9.32f)));
            limits.Add(new Coordinates(new Vector3(26.38f, 1f, -23.58f), new Vector3(26.49f, 1f, -9.51f)));
            limits.Add(new Coordinates(new Vector3(12.17f, 1f, -23.48f), new Vector3(26.37f, 1f, -23.34f)));
            limits.Add(new Coordinates(new Vector3(12.47f, 1f, -23.50f), new Vector3(12.51f, 1f, -19.13f)));

            limits.Add(new Coordinates(new Vector3(-12.97f, 1f,-18.69f), new Vector3(11.86f, 1f, -18.46f)));
            limits.Add(new Coordinates(new Vector3(-13.59f, 1f, -23.78f), new Vector3(-13.29f, 1f, -19.05f)));
            limits.Add(new Coordinates(new Vector3(-27.74f, 1f, -23.41f), new Vector3(-13.61f, 1f, -23.28f)));
            limits.Add(new Coordinates(new Vector3(-27.20f, 1f, -23.67f), new Vector3(-27.12f, 1f, -9.28f)));
            limits.Add(new Coordinates(new Vector3(-27.37f, 1f, -9.63f), new Vector3(-22.97f, 1f, -9.49f)));

            limits.Add(new Coordinates(new Vector3(-17.79f, 1f, 1.30f), new Vector3(-8.35f, 1f,  1.66f)));
            limits.Add(new Coordinates(new Vector3(-18.63f, 1f, -8.98f), new Vector3(-18.53f, 1f, 0.89f)));
            limits.Add(new Coordinates(new Vector3(-17.79f, 1f, -10.00f), new Vector3(-13.13f,1f, -9.75f)));
            limits.Add(new Coordinates(new Vector3(-13.83f, 1f, -13.95f), new Vector3(-13.63f, 1f, -9.46f)));
            limits.Add(new Coordinates(new Vector3(-12.86f, 1f, -14.74f), new Vector3(-3.01f, 1f, -14.58f)));
            limits.Add(new Coordinates(new Vector3(-2.60f, 1f, -13.74f), new Vector3(-2.45f, 1f, -4.17f)));
            limits.Add(new Coordinates(new Vector3(-7.61f, 1f, -3.66f), new Vector3(-3.13f, 1f, -3.40f)));
            limits.Add(new Coordinates(new Vector3(-7.73f, 1f, -3.53f), new Vector3(-7.42f, 1f, 0.98f)));

            limits.Add(new Coordinates(new Vector3(1.36f, 1f, -13.96f), new Vector3(1.39f, 1f, -4.23f)));
            limits.Add(new Coordinates(new Vector3(2.15f, 1f, -14.68f), new Vector3(12.01f, 1f, -14.48f)));
            limits.Add(new Coordinates(new Vector3(12.67f, 1f, -13.67f), new Vector3(12.81f, 1f, -9.20f)));
            limits.Add(new Coordinates(new Vector3(12.52f, 1f,-9.70f), new Vector3(16.97f, 1f, -9.48f)));
            limits.Add(new Coordinates(new Vector3(17.45f, 1f, -8.81f), new Vector3(17.76f, 1f, 0.97f)));
            limits.Add(new Coordinates(new Vector3(7.03f, 1f, 1.29f), new Vector3(16.61f, 1f, 1.41f)));
            limits.Add(new Coordinates(new Vector3(6.17f, 1f, -3.81f), new Vector3(6.67f, 1f, 0.76f)));
            limits.Add(new Coordinates(new Vector3(2.22f, 1f,  -3.45f), new Vector3(6.58f, 1f, -3.34f)));

            limits.Add(new Coordinates(new Vector3(7.35f, 1f, 5.40f), new Vector3(16.99f, 1f, 5.55f)));
            limits.Add(new Coordinates(new Vector3(6.41f, 1f, 6.07f), new Vector3(6.44f, 1f, 10.63f)));
            limits.Add(new Coordinates(new Vector3(2.16f, 1f, 10.15f), new Vector3(6.68f, 1f, 10.64f)));
            limits.Add(new Coordinates(new Vector3(1.51f, 1f, 11.03f), new Vector3(1.60f, 1f, 20.80f)));
            limits.Add(new Coordinates(new Vector3(2.26f, 1f, 21.41f), new Vector3(11.70f, 1f, 21.46f)));
            limits.Add(new Coordinates(new Vector3( 12.57f, 1f, 16.59f), new Vector3(12.62f, 1f, 20.79f)));
            limits.Add(new Coordinates(new Vector3(12.28f, 1f, 16.47f), new Vector3(16.79f, 1f, 16.49f)));
            limits.Add(new Coordinates(new Vector3(17.24f, 1f,  6.22f), new Vector3(17.48f, 1f, 15.67f)));
            limits.Add(new Coordinates(new Vector3(7.18f, 1f, 5.43f), new Vector3(16.86f, 1f, 5.67f)));
            limits.Add(new Coordinates(new Vector3(12.44f, 1f, 16.72f), new Vector3(12.81f, 1f, 20.45f)));
            limits.Add(new Coordinates(new Vector3( 12.81f, 1f, 16.68f), new Vector3(16.25f, 1f, 16.94f)));

            return limits;
        }

        private List<Points> PathList1()
        {
            List<Points> points = new List<Points>();

            points.Add(new Points(new Vector3(5.0f, 0.0f, 0.0f))); //initial position of the entity
            points.Add(new Points(new Vector3(5.0f, 0.0f, 7.0f)));  // target position
            points.Add(new Points(new Vector3(-0.5f, 0.0f, 24.15f)));
            points.Add(new Points(new Vector3(11.30f, 0.0f, 23.35f)));
            points.Add(new Points(new Vector3(19.15f, 0.0f, 15.60f)));
            points.Add(new Points(new Vector3(19.25f, 0.0f, 4.60f)));
            points.Add(new Points(new Vector3(6.45f, 0.0f, 3.90f)));


            return points;
        }
        private List<Points> PathList2()
        {
            List<Points> points = new List<Points>();

            points.Add(new Points(new Vector3(-5.50f, 0.1f, 9.50f)));
            points.Add(new Points(new Vector3(-5.60f, 0.1f, 5.00f)));
            points.Add(new Points(new Vector3(-18.95f, 0.1f, 3.50f)));
            points.Add(new Points(new Vector3(-21.20f, 0.1f, 19.90f)));
            points.Add(new Points(new Vector3(-22.70f, 0.1f, 25.25f)));
            points.Add(new Points(new Vector3(0f, 0.1f, 23.50f)));
            points.Add(new Points(new Vector3(0.35f, 0.1f, 10.45f)));

            return points;
        }

        private List<Points> PathList3()
        {
            List<Points> points = new List<Points>();

            points.Add(new Points(new Vector3(-5.15f, 0.1f, -1.75f)));
            points.Add(new Points(new Vector3(-0.40f, 0.1f, -1.05f)));
            points.Add(new Points(new Vector3(-0.55f, 0.1f, -16.35f)));
            points.Add(new Points(new Vector3(-13.85f, 0.1f, -16.25f)));
            points.Add(new Points(new Vector3(-18.80f, 0.1f, -21.90f)));
            points.Add(new Points(new Vector3(-26f, 0.1f, -21.70f)));
            points.Add(new Points(new Vector3(-25.80f, 0.1f, -11.95f)));
            points.Add(new Points(new Vector3(-20.60f, 0.1f, -12f)));
            points.Add(new Points(new Vector3(-20.45f, 0.1f, 2.60f)));
            points.Add(new Points(new Vector3(-3.25f, 0.1f, 3.25f)));

            return points;
        }

        private List<Points> PathList4()
        {
            List<Points> points = new List<Points>();

            points.Add(new Points(new Vector3(5.25f, 0.2f, 9.25f)));
            points.Add(new Points(new Vector3(4.10f, 0.2f, 3.95f)));
            points.Add(new Points(new Vector3(19.40f, 0.2f, 2.90f)));
            points.Add(new Points(new Vector3(19.45f, 0.2f, -9.80f)));
            points.Add(new Points(new Vector3(25.05f, 0.2f, -10.75f)));
            points.Add(new Points(new Vector3(25.40f, 0.2f, -21.95f)));
            points.Add(new Points(new Vector3(14.90f, 0.2f, -21.35f)));
            points.Add(new Points(new Vector3(13.30f, 0.2f, -16.05f)));
            points.Add(new Points(new Vector3(-0.70f, 0.2f, -17.65f)));
            points.Add(new Points(new Vector3(-0.00f, 0.2f, -2.15f)));


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

            if(count >= 45)
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
            GUI.Label(new Rectangle(0, 60, (int)width, (int)(fontSize * 2f)), "LineCollsion_Debug Mode: " + LineCollisionManager.debug_line, 18, StringAlignment.Near, Color.White);
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
