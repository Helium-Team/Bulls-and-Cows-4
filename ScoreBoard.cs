using System;
using System.Linq;
using System.Collections.Generic;

namespace BullsAndCowsGame
{
    public class ScoreBoard
    {
        private const int SHOWED_TOP_SCORE = 5;
        private static ScoreBoard instance;
        private List<KeyValuePair<string, int>> ranking;

        public static ScoreBoard Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (instance)
                    {
                        if (instance == null)
                            instance = new ScoreBoard();
                    }
                }
                
                return instance;
            }
        }
        
        private ScoreBoard()
        {
            this.ranking = new List<KeyValuePair<string, int>>();
        }

        public void AddPlayer(string playerName, int attempts)
        {
            if (playerName == null || string.IsNullOrWhiteSpace(playerName)) 
            {
                throw new ArgumentException("Invalid Player Name");
            }
            if (attempts < 0)
            {
                throw new ArgumentException("Attemps can't be less than null");
            }
            this.ranking.Add(new KeyValuePair<string, int>(playerName, attempts));
        }

        private List<KeyValuePair<string, int>> Sort()
        {
            var sortedRanking = this.ranking.OrderBy(attempts => attempts.Value).ThenBy(attempts => attempts.Key).ToList();
            return sortedRanking;
        }

        public void Print()
        {
            if (ranking.Count == 0)
            {
                Console.WriteLine("Top scoreboard is empty.");
            }
            else
            {
                var sortedRanking = Sort();
                Console.WriteLine("Scoreboard:");
                int i = 1;
                foreach (var p in sortedRanking)
                {
                    if (i <= SHOWED_TOP_SCORE)
                    {
                        Console.WriteLine("{0}. {1} --> {2} guess" + ((p.Value == 1) ? "" : "es"), i++, p.Key, p.Value);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}