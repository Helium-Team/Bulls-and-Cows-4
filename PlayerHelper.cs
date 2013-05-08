using System;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    public static class PlayerHelper
    {
        private static string helpPattern = null;
        private static StringBuilder helpNumber = new StringBuilder("XXXX");

        public static int PrintHelp(int cheats, string generatedNumber)
        {
            if (cheats < 4)
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

        private static void RevealDigit(int cheats, string generatedNumber)
        {
            if (helpPattern == null)
            {
                GenerateHelpPattern();
            }
            int digitToReveal = helpPattern[cheats] - '0';
            helpNumber[digitToReveal - 1] = generatedNumber[digitToReveal - 1];
        }

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
    }
}