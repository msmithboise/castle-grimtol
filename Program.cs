using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var game = new Game(new Room("starting room", "where you start"), new Player());
            game.StartGame();
        }
    }
}
