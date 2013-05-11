using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BullsAndCowsGame;
using System.IO;
using System.Text;

namespace BullsAndCows.Test
{


    [TestClass()]
    public class PlayerHelperTest
    {
        private static StringBuilder helpNumber = new StringBuilder("XXXX");
         
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PrintHelpTest1()
        {
            PlayerHelper.PrintHelp(1, string.Empty);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PrintHelpTest2()
        {
            PlayerHelper.PrintHelp(1, null);
        }
        
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PrintHelpTest3()
        {
            PlayerHelper.PrintHelp(-3, "5678");
        }

        [TestMethod()]
        public void PrintHelpTest4()
        {
            int cheats = 2;
            int expected = cheats+1;
            int actual = PlayerHelper.PrintHelp(cheats, "5789");
            Assert.AreEqual(expected, actual, "Cheats are calculated wrong!");
        }
        
        [TestMethod()]
        public void PrintHelpTest5()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                
                PlayerHelper.PrintHelp(5, "5678");

                string expected = string.Format("You are not allowed to ask for more help!{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString(), "Wrong message printed!");

                sw.Flush();
            }
        }

        [TestMethod()]
        public void ClearHelpTest()
        {
            StringBuilder expected = new StringBuilder("XXXX");
            PlayerHelper.ClearHelp();

            Assert.AreEqual(expected, helpNumber, "Help number is not cleared correctly!");
        }
    }
}
