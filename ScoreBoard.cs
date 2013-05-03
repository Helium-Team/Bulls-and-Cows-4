using System;
using System.Linq;
using System.Collections.Generic;

namespace BullsAndCowsGame
{
    public class ScoreBoard
    {
        private const int SHOWED_TOP_SCORE = 5;
        private static ScoreBoard instance;
        private SortedList<string, int> ranking;

        public static ScoreBoard Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScoreBoard();
                }
                return instance;
            }
        }
        
        private ScoreBoard()
        {
            this.ranking = new SortedList<string, int>();
        }

        public void AddPlayer(string playerName, int attempts)
        {
            Player player = new Player(playerName, attempts);
            ranking.Add(playerName, attempts);
        }

        public void Print()
        {
            if (ranking.Count == 0)
            {
                Console.WriteLine("Top scoreboard is empty.");
            }
            else
            {
                Console.WriteLine("Scoreboard:");
                int i = 1;
                foreach (var p in ranking)
                {
                    Console.WriteLine("{0}. {1} --> {2} guess" + ((p.Value == 1) ? "" : "es"), i++, p.Key, p.Value);
                }
            }
        }
    }
}