using System;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    public class GameEngine
    {
        private string generatedNumber;
        private const int NUMBER_LENGHT = 4;

        public GameEngine()
        {
        }

        public void Start()
        {
            PlayerCommand enteredCommand;
            do
            {
                ConsolePrinter.PrintWelcomeMessage();
                generatedNumber = NumberGenerator.GenerateNumber(NUMBER_LENGHT);
                int attempts = 0;
                int cheats = 0;
                
                do
                {
                    Console.Write("Enter your guess or command: ");
                    string playerInput = Console.ReadLine();
                    enteredCommand = CommandReader.ReadPlayerInput(playerInput);

                    if (enteredCommand == PlayerCommand.Top)
                    {
                        ScoreBoard.Print();
                    }
                    else if (enteredCommand == PlayerCommand.Help)
                    {
                        cheats = PlayerHelper.PrintHelp(cheats, generatedNumber);
                    }
                    else
                    {
                        if (IsValidInput(playerInput))
                        {
                            attempts++;
                            int bullsCount;
                            int cowsCount;
                            CalculateBullsAndCowsCount(playerInput, generatedNumber, out bullsCount, out cowsCount);
                            if (bullsCount == NUMBER_LENGHT)
                            {
                                ConsolePrinter.PrintCongratulateMessage(attempts, cheats);
                                FinishGame(attempts, cheats);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bullsCount, cowsCount);
                            }
                        }
                        else
                        {
                            if (enteredCommand != PlayerCommand.Restart && enteredCommand != PlayerCommand.Exit)
                            {
                                ConsolePrinter.PrintWrongCommandMessage();
                            }
                        }
                    }
                }
                while (enteredCommand != PlayerCommand.Exit && enteredCommand != PlayerCommand.Restart);
                Console.WriteLine();
            }
            while (enteredCommand != PlayerCommand.Exit);
            Console.WriteLine("Good bye!");
        }

        private void CalculateBullsAndCowsCount(string playerInput, string generatedNumber, out int bullsCount, out int cowsCount)
        {
            bullsCount = 0;
            cowsCount = 0;
            StringBuilder playerNumber = new StringBuilder(playerInput);
            StringBuilder number = new StringBuilder(generatedNumber);
            for (int i = 0; i < playerNumber.Length; i++)
            {
                if (playerNumber[i] == number[i])
                {
                    bullsCount++;
                    playerNumber.Remove(i, 1);
                    number.Remove(i, 1);
                    i--;
                }
            }

            for (int i = 0; i < playerNumber.Length; i++)
            {
                for (int j = 0; j < number.Length; j++)
                {
                    if (playerNumber[i] == number[j])
                    {
                        cowsCount++;
                        playerNumber.Remove(i, 1);
                        number.Remove(j, 1);
                        j--;
                        i--;
                        break;
                    }
                }
            }
        }

        private bool IsValidInput(string playerInput)
        {
            if (playerInput == String.Empty || playerInput.Length != NUMBER_LENGHT)
            {
                return false;
            }
            for (int i = 0; i < playerInput.Length; i++)
            {
                char currentChar = playerInput[i];
                if (!Char.IsDigit(currentChar))
                {
                    return false;
                }
            }
            return true;
        }

        private void FinishGame(int attempts, int cheats)
        {
            if (cheats == 0)
            {
                Console.Write("Please enter your name for the top scoreboard: ");
                string playerName = Console.ReadLine();
                ScoreBoard.AddPlayer(playerName, attempts);
                ScoreBoard.Print();
            }
            else
            {
                Console.WriteLine("You are not allowed to enter the top scoreboard.");
            }
        }
        
    }
}