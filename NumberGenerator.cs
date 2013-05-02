using System;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    public static class NumberGenerator
    {
        public static string GenerateNumber(int numberLenght)
        {
            StringBuilder num = new StringBuilder(4);
            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < numberLenght; i++)
            {
                int randomDigit = randomNumberGenerator.Next(9);
                num.Append(randomDigit);
            }

            return num.ToString();
        }
    }
}