using System;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    public class GameEngine
    {
        private string generatedNumber;
        private PlayerHelper playerHelper = new PlayerHelper();
        private readonly NumberGenerator numberGenerator = new NumberGenerator();

        public GameEngine()
        {
        }

        

        public void Start()
        {
            PlayerCommand enteredCommand;
            do
            {
                ConsolePrinter.PrintWelcomeMessage();
                generatedNumber = numberGenerator.GenerateNumber();
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
                        cheats = playerHelper.PrintHelp(cheats, generatedNumber);
                    }
                    else if (enteredCommand == PlayerCommand.Restart)
                    {
                        playerHelper = new PlayerHelper();
                        Console.WriteLine();
                    }
                    else
                    {
                        if (IsValidInput(playerInput))
                        {
                            attempts++;
                            int bullsCount = CallculateBullsCount(playerInput, generatedNumber);
                            int cowsCount = CallculateCowsCount(playerInput, generatedNumber);
                            if (bullsCount == generatedNumber.Length)
                            {
                                ConsolePrinter.PrintCongratulateMessage(attempts, cheats);
                                FinishGame(attempts, cheats);
                                playerHelper = new PlayerHelper();
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
            }
            while (enteredCommand != PlayerCommand.Exit);
            Console.WriteLine("\nGood bye!");
        }

        private int CallculateBullsCount(string playerInput, string generatedNumber)
        {
            StringBuilder playerNumber = new StringBuilder(playerInput);
            StringBuilder number = new StringBuilder(generatedNumber);
            int cowsCount = 0;
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
            return cowsCount;
        }

        private int CallculateCowsCount(string playerInput, string generatedNumber)
        {
            int bullsCount = 0;
           
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

            return bullsCount;
        }

        private bool IsValidInput(string playerInput)
        {
            if (playerInput == String.Empty || playerInput.Length != generatedNumber.Length)
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