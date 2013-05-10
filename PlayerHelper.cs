using System;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    /// <summary>
    /// Contains methods that generate, print and clear one digit 
    /// from the generated number when command "Help" is executed.
    /// </summary>
    public static class PlayerHelper
    {
        private static string helpPattern = null;
        private static StringBuilder helpNumber = new StringBuilder("XXXX");
        
        /// <summary>
        /// Print help number if there are not revealed digit in the generated number.
        /// </summary>
        /// <param name="cheats">Represent number of revealed digit</param>
        /// <param name="generatedNumber">Represent generated number which have to be guessed in string format</param>
        /// <returns>Integer number that reperesent number of revealed digit from the generated number</returns>
        public static int PrintHelp(int cheats, string generatedNumber)
        {
            int maxCheats = generatedNumber.Length;
            if (cheats < maxCheats)
            {
                RevealDigit(cheats, generatedNumber);
                cheats++;
                Console.WriteLine("The number looks like {0}.", helpNumber);
            }
            else
            {
                Console.WriteLine("You are not allowed to ask for more help!");
            }
            return cheats;
        }

        /// <summary>
        /// Generate number with new digit to be revealed.
        /// </summary>
        /// <param name="cheats">Represent number of revealed digit</param>
        /// <param name="generatedNumber">Represent generated number which have to be guessed in string format</param>
        private static void RevealDigit(int cheats, string generatedNumber)
        {
            if (helpPattern == null)
            {
                GenerateHelpPattern();
            }
            int digitToReveal = helpPattern[cheats] - '0';
            helpNumber[digitToReveal - 1] = generatedNumber[digitToReveal - 1];
        }

        /// <summary>
        /// Generate help pattern.
        /// </summary>
        private static void GenerateHelpPattern()
        {
            string[] helpPaterns =
            {
                "1234", "1243", "1324", "1342", "1432", "1423",
                "2134", "2143", "2314", "2341", "2431", "2413",
                "3214", "3241", "3124", "3142", "3412", "3421",
                "4231", "4213", "4321", "4312", "4132", "4123",
            };

            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);
            int randomPaternNumber = randomNumberGenerator.Next(helpPaterns.Length - 1);
            helpPattern = helpPaterns[randomPaternNumber];
        }

        /// <summary>
        /// Clear previously generated help number. 
        /// </summary>
        public static void ClearHelp()
        {
            helpNumber = new StringBuilder("XXXX");
        }
    }
}