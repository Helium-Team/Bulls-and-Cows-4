using System;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    public class NumberGenerator
    {
        private const int NUMBER_LENGHT = 4;

        public string GenerateNumber()
        {
            StringBuilder num = new StringBuilder(4);
            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < NUMBER_LENGHT; i++)
            {
                int randomDigit = randomNumberGenerator.Next(9);
                num.Append(randomDigit);
            }

            return num.ToString();
        }
    }
}