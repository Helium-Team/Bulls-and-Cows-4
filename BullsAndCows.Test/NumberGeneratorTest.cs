using BullsAndCowsGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BullsAndCows.Test
{
    [TestClass()]
    public class NumberGeneratorTest
    {
        [TestMethod()]
        public void GenerateNumberTestIfNumbersAreDifferent()
        {
            for (int j = 0; j < 50000; j++)
            {
                string actual = NumberGenerator.GenerateNumber();
                for (int i = 0; i < actual.Length - 1; i++)
                {
                    Assert.AreNotEqual(actual[i], actual[i + 1]);
                }
            }
        }

        [TestMethod()]
        public void GenerateNumberTestIsValidDigitInRange()
        {
            for (int j = 0; j < 50000; j++)
            {
                string actual = NumberGenerator.GenerateNumber();
                for (int i = 0; i < actual.Length - 1; i++)
                {
                    if (int.Parse(actual[i].ToString()) > 9 && int.Parse(actual[i].ToString()) < 0)
                    {
                        Assert.Fail("Invalid Number");
                    }
                }
            }
        }

        [TestMethod()]
        public void GenerateNumberTestCheckNumberLength()
        {
            for (int j = 0; j < 50000; j++)
            {
                string actual = NumberGenerator.GenerateNumber();
                for (int i = 0; i < actual.Length - 1; i++)
                {
                    Assert.AreEqual(4, actual.Length);
                }
            }
        }
    }
}