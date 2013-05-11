using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BullsAndCowsGame;
using System.IO;

namespace BullsAndCows.Test
{
    [TestClass()]
    public class ConsolePrinterTest
    {
        
        [TestMethod()]
        public void PrintCongratulateMessageTest1()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.Flush();
                Console.SetOut(sw);

                ConsolePrinter.PrintCongratulateMessage(2, 0);

                string expected = string.Format("\nCongratulations! You guessed the secret number in 2 attempts.{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString(), "Wrong congratulation message printed!");
            }
        }

        [TestMethod()]
        public void PrintCongratulateMessageTest2()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.Flush();
                Console.SetOut(sw);

                ConsolePrinter.PrintCongratulateMessage(2, 2);

                string expected = string.Format("\nCongratulations! You guessed the secret number in 2 attempts and 2 cheats.{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString(), "Wrong congratulation message printed!");
            }
        }

        [TestMethod()]
        public void PrintWelcomeMessageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.Flush();
                Console.SetOut(sw);

                ConsolePrinter.PrintWelcomeMessage();

                string expected = string.Format("Welcome to “Bulls and Cows” game. " +
                                               "Please try to guess my secret 4-digit number." +
                                               "Use 'top' to view the top scoreboard, 'restart' " +
                                               "to start a new game and 'help' to cheat and 'exit' to quit the game.{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString(), "Wrong welcome message printed!");
            }
        }

        [TestMethod()]
        public void PrintWrongCommandMessageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.Flush();
                Console.SetOut(sw);

                ConsolePrinter.PrintWrongCommandMessage();

                string expected = string.Format("Incorrect guess or command!{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString(), "Invalid wrong command message printed!");
            }
        }
    }
}