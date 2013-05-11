using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BullsAndCowsGame;
using System.Collections.Generic;
using System.IO;

namespace BullsAndCows.Test
{
    [TestClass()]
    public class ScoreBoardTest
    {
        [TestMethod()]
        public void PrintTest1()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.Flush();
                Console.SetOut(sw);

                ScoreBoard.Instance.Print();

                string expected = string.Format("Top scoreboard is empty.{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString(), "Wrong message printed!");
            }
        }

        [TestMethod()]
        public void PrintTest2()
        {
            ScoreBoard.Instance.AddPlayer("Cecka", 5);
            ScoreBoard.Instance.AddPlayer("Puh", 2);
            ScoreBoard.Instance.AddPlayer("Tranka", 2);

            using (StringWriter sw = new StringWriter())
            {
                sw.Flush();
                Console.SetOut(sw);

                ScoreBoard.Instance.Print();

                string expected = string.Format("Scoreboard:{0}" +
                                                "1. Puh --> 2 guesses{0}" +
                                                "2. Tranka --> 2 guesses{0}" +
                                                "3. Cecka --> 5 guesses{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString(), "Wrong message printed!");
            }
        }
        
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void AddPlayerTest1()
        {
            ScoreBoard.Instance.AddPlayer(null, 5);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void AddPlayerTest2()
        {
            ScoreBoard.Instance.AddPlayer(String.Empty, 5);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void AddPlayerTest3()
        {
            ScoreBoard.Instance.AddPlayer("Cecka", -2);
        }

        [TestMethod()]
        public void InstanceTest()
        {
            
        }
    }
}