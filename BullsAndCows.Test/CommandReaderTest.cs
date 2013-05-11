using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BullsAndCowsGame;

namespace BullsAndCows.Test
{
    [TestClass()]
    public class CommandReaderTest
    {
        [TestMethod()]
        public void ReadPlayerInputTest1()
        {
            string playerInput = string.Empty; 
            PlayerCommand actual = CommandReader.ReadPlayerInput(playerInput);
            Assert.AreEqual(PlayerCommand.Other, actual, "Input and expected commands are not equal!");
        }

        [TestMethod()]
        public void ReadPlayerInputTest2()
        {
            string playerInput = "something";
            PlayerCommand actual = CommandReader.ReadPlayerInput(playerInput);
            Assert.AreEqual(PlayerCommand.Other, actual, "Input and expected commands are not equal!");
        }

        [TestMethod()]
        public void ReadPlayerInputTest3()
        {
            string playerInput = "Top";
            PlayerCommand actual = CommandReader.ReadPlayerInput(playerInput);
            Assert.AreEqual(PlayerCommand.Top, actual, "Input and expected commands are not equal!");
        }

        [TestMethod()]
        public void ReadPlayerInputTest4()
        {
            string playerInput = "help";
            PlayerCommand actual = CommandReader.ReadPlayerInput(playerInput);
            Assert.AreEqual(PlayerCommand.Help, actual, "Input and expected commands are not equal!");
        }

        [TestMethod()]
        public void ReadPlayerInputTest5()
        {
            string playerInput = "Exit";
            PlayerCommand actual = CommandReader.ReadPlayerInput(playerInput);
            Assert.AreEqual(PlayerCommand.Exit, actual, "Input and expected commands are not equal!");
        }

        [TestMethod()]
        public void ReadPlayerInputTest6()
        {
            string playerInput = "restart";
            PlayerCommand actual = CommandReader.ReadPlayerInput(playerInput);
            Assert.AreEqual(PlayerCommand.Restart, actual, "Input and expected commands are not equal!");
        }
    }
}