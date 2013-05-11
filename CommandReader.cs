using System;
using System.Linq;

namespace BullsAndCowsGame
{
    /// <summary>
    /// Contains method that read player input and convert it in appropriate command.
    /// </summary>
    public static class CommandReader
    {
        /// <summary>
        /// Read player input and convert it in appropriate command.
        /// </summary>
        /// <param name="playerInput">Represent string that player is written to the console.</param>
        /// <returns>Object that represent element from enum PlayerCommand.</returns>
        public static PlayerCommand ReadPlayerInput(string playerInput)
        {
            if (playerInput.ToLower() == "top")
            {
                return PlayerCommand.Top;
            }
            else if (playerInput.ToLower() == "restart")
            {
                return PlayerCommand.Restart;
            }
            else if (playerInput.ToLower() == "help")
            {
                return PlayerCommand.Help;
            }
            else if (playerInput.ToLower() == "exit")
            {
                return PlayerCommand.Exit;
            }
            else
            {
                return PlayerCommand.Other;
            }
        }
        
    }
}