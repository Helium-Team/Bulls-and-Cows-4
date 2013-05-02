using System;
using System.Linq;

namespace BullsAndCowsGame
{
    public static class ScoreBoard
    {
        private static readonly Score<Player> rankList = new Score<Player>();

        public static void AddPlayer(string playerName, int attempts)
        {
            Player player = new Player(playerName, attempts);
            rankList.Add(player);
        }

        public static void Print()
        {
            if (rankList.Count == 0)
            {
                Console.WriteLine("Top scoreboard is empty.");
            }
            else
            {
                Console.WriteLine("Scoreboard:");
                int i = 1;
                foreach (Player p in rankList)
                {
                    Console.WriteLine("{0}. {1} --> {2} guess" + ((p.Attempts == 1) ? "" : "es"), i++, p.Name, p.Attempts);
                }
            }
        }
    }
}