using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenGL_Game.Components;
using OpenGL_Game.Systems;
using OpenGL_Game.Managers;
using OpenGL_Game.Objects;
using System.Drawing;
using System;

namespace OpenGL_Game.Scenes
{
    class GameOverScene : Scene
    {
        public GameOverScene(SceneManager sceneManager) : base(sceneManager)
        {
            // Set the title of the window
            sceneManager.Title = "Game Over";
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;

            //Keyboard delegate
            sceneManager.keyboardDownDelegate += Keyboard_KeyDown;

            // sceneManager.mouseDelegate += Mouse_BottonPressed;
        }

        public override void Update(FrameEventArgs e)
        {
        }

        public override void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Width, sceneManager.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, sceneManager.Width, 0, sceneManager.Height, -1, 1);

            GUI.clearColour = Color.CornflowerBlue;

            //Display the Title
            float width = sceneManager.Width, height = sceneManager.Height, fontSize = Math.Min(width, height) / 10f;
            GUI.Label(new Rectangle(0, (int)(fontSize / 2f), (int)width, (int)(fontSize * 2f)), "Game Over", (int)fontSize, StringAlignment.Center);

            GUI.Render();
        }

        //public void Mouse_BottonPressed(MouseButtonEventArgs e)
        //{
        //    //sceneManager.ChangeScene

        //    switch (e.Button)
        //    {



        //    }
        //}

        public void Keyboard_KeyDown(KeyboardKeyEventArgs e)
        {
            switch (e.Key)
            {
                //Press Any key to Start Menu
                case Key:
                    sceneManager.ChangeScene((SceneTypes)1);
                    break;
                         
              
            }
        }

        public override void Close()
        {
            // sceneManager.mouseDelegate -= Mouse_BottonPressed;

            sceneManager.keyboardDownDelegate -= Keyboard_KeyDown;
        }
    }
}
