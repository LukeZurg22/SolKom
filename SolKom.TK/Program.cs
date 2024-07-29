using SolKom.TK.Core;
using System;

namespace SolKom.TK
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Running program.");
            Game game = new TestGame("Test Prog", 1920, 1080);
            game.Run();
        }
    }
}