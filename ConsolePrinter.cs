using System;
using System.Linq;

namespace BullsAndCowsGame
{
    /// <summary>
    /// Contains methods that print informational messages.
    /// </summary>
    public static class ConsolePrinter
    {
        private const string WELCOME_MESSAGE = "Welcome to “Bulls and Cows” game. " +
                                               "Please try to guess my secret 4-digit number." +
                                               "Use 'top' to view the top scoreboard, 'restart' " +
                                               "to start a new game and 'help' to cheat and 'exit' to quit the game.";
       
        private const string WRONG_COMMAND_MESSAGE = "Incorrect guess or command!";

        /// <summary>
        /// Print message when game begin.
        /// </summary>
        /// <returns>Write message to the console</returns>
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine(WELCOME_MESSAGE);
        }

        /// <summary>
        /// Print message when invalid command is inputed.
        /// </summary>
        /// <returns>Write message to the console</returns>
        public static void PrintWrongCommandMessage()
        {
            Console.WriteLine(WRONG_COMMAND_MESSAGE);
        }

        /// <summary>
        /// Print message when game finish.
        /// </summary>
        /// <param name="attempt">Represent number of player's tries to guess the number.</param>
        /// <param name="cheats">Represent how many times player is used help command.</param>
        /// <returns>Write different messages to the console depending of players cheats.</returns>
        public static void PrintCongratulateMessage(int attempts, int cheats)
        {
            Console.Write("\nCongratulations! You guessed the secret number in {0} attempts", attempts);
            if (cheats == 0)
            {
                Console.WriteLine(".");
            }
            else
            {
                Console.WriteLine(" and {0} cheats.", cheats);
            }
        }
    }
}