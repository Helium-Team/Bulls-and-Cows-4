using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCowsGame
{
    public class ScoreBoard
    {
        // Instead private Score<Player> Klasirane; ??
        private Dictionary<string, uint> players = new Dictionary<string, uint>();

        public Dictionary<string, uint> Players
        {
            get
            {
                return this.players;
            }
            set
            {
                this.players = value;
            }
        }

        public void AddPlayerToScoreboard(string playerName, uint attempts)
        {
            if (this.Players.Keys.Contains(playerName))
            {
                this.Players[playerName] = attempts;
            }
            else
            {
                this.Players.Add(playerName, attempts);
            }
        }

        public void PrintScoreboard()
        {
            if (this.Players.Count == 0)
            {
                Console.WriteLine("Top scoreboard is empty.");
            }
            else
            {
                Console.WriteLine("Scoreboard:");
                int number = 1;
                foreach (var player in this.Players.OrderBy(i => i.Key))
                {
                    Console.WriteLine("{0}. {1} {2}", number, player.Key, player.Value);
                    number++;
                }
            }
        }
    }
}