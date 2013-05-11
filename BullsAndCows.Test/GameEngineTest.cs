using BullsAndCowsGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BullsAndCows.Test
{
    [TestClass()]
    public class GameEngineTest
    {
        
        [TestMethod()]
        public void GameEngineConstructorTest()
        {
            GameEngine target = new GameEngine();
            Assert.IsNotNull(target);
        }

       
    }
}