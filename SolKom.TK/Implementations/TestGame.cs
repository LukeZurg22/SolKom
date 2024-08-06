using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using SolKom.TK.Classes;
using SolKom.TK.Core;

namespace SolKom.TK
{
    internal class TestGame : Game
    {
        public TestGame(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
        {

        }

        protected override void Initialize()
        {
            UniversalData data = new();

            Task.Run(() =>
            {
                Console.WriteLine("Running SolKom Command Window thread...");
                CommandConsole commandConsole = new();
                commandConsole.Initialize();
            });
        }

        protected override void LoadContent()
        {

        }

        protected override void Render(GameTime gameTime)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color4.CornflowerBlue);
            //Console.WriteLine(gameTime.GameTimeTotal.TotalSeconds);
        }

        protected override void Update(GameTime gameTime)
        {
        }
    }
}
