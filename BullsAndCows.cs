using System;
using System.Linq;

namespace BullsAndCowsGame
{
    class BullsAndCows
    {
        /// <summary>
        /// Create new game and start it.
        /// </summary>
        static void Main(string[] args)
        {
            GameEngine game = new GameEngine();
            game.Start();
        }
    }
}