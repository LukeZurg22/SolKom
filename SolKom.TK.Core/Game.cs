using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
namespace SolKom.TK.Core
{
    public abstract class Game
    {
        protected string WindowTitle { get; set; }
        protected int InitialWindowWidth { get; set; }
        protected int InitialWindowHeight { get; set; }
        private GameWindowSettings _gameWindowSettings = GameWindowSettings.Default;
        private NativeWindowSettings _nativeWindowSettings = NativeWindowSettings.Default;

        public Game(string windowTitle, int initialWindowWidth, int initialWindowHeight)
        {
            WindowTitle = windowTitle;
            InitialWindowWidth = initialWindowWidth;
            InitialWindowHeight = initialWindowHeight;
        }

        public void Run()
        {
            Initialize();
            using GameWindow gameWindow = new(_gameWindowSettings, _nativeWindowSettings);
            GameTime gameTime = new();
            gameWindow.Load += LoadContent;
            
            // Game Frame Update
            gameWindow.UpdateFrame += (FrameEventArgs eventArgs) =>
            {
                double time = eventArgs.Time;
                gameTime.GameTimeElapsed = TimeSpan.FromMilliseconds(time);
                gameTime.GameTimeTotal += TimeSpan.FromSeconds(time);
                Update(gameTime);
            };
            
            // Draw Function
            gameWindow.RenderFrame += (FrameEventArgs eventArgs) =>
            {
                Render(gameTime);
                gameWindow.SwapBuffers();
            };

            gameWindow.Run();

        }

        protected abstract void Initialize();
        protected abstract void LoadContent();
        protected abstract void Update(GameTime gameTime);
        protected abstract void Render(GameTime gameTime);
    }
}