using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    public static class NumberGenerator
    {
        private const int NUMBER_LENGHT = 4;

        public static string GenerateNumber()
        {
            
            StringBuilder num = new StringBuilder(4);
            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);
            List<int> usedDigits = new List<int>();

            for (int i = 0; i < NUMBER_LENGHT; i++)
            {
                int randomDigit = randomNumberGenerator.Next(9);
                while (usedDigits.Contains(randomDigit))
                {
                    randomDigit = randomNumberGenerator.Next(9);
                }
                usedDigits.Add(randomDigit);
                num.Append(randomDigit);
            }

            return num.ToString();
        }
    }
}