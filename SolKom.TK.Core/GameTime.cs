namespace SolKom.TK.Core
{
    public class GameTime
    {
        public TimeSpan GameTimeTotal { get; set; }
        public TimeSpan GameTimeElapsed { get; set; }
        public GameTime()
        {
            GameTimeTotal = TimeSpan.Zero;
            GameTimeElapsed = TimeSpan.Zero;
        }
        public GameTime(TimeSpan gameTimeTotal, TimeSpan gameTimeElapsed)
        {
            GameTimeTotal = gameTimeTotal;
            GameTimeElapsed = gameTimeElapsed;
        }

    }
}
