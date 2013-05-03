using System;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    public class GameEngine
    {
        private PlayerHelper playerHelper;
        private readonly NumberGenerator numberGenerator;
        private string playerInput = null;
        private string generatedNumber;
        private bool isGameFinished = false;
        private int attempts = 0;
        private int cheats = 0;
        
        public GameEngine()
        {
            this.numberGenerator = new NumberGenerator();
            this.playerHelper = new PlayerHelper();
            this.generatedNumber = numberGenerator.GenerateNumber();
        }
        
        public void Start()
        {
            PlayerCommand enteredCommand;
            do
            {
                ConsolePrinter.PrintWelcomeMessage();
                //generatedNumber = numberGenerator.GenerateNumber();
                this.isGameFinished = false;
                int attempts = 0;
                int cheats = 0;
                
                do
                {
                    Console.Write("Enter your guess or command: ");
                    playerInput = Console.ReadLine();
                    enteredCommand = CommandReader.ReadPlayerInput(playerInput);
                    ExecuteCommand(enteredCommand);
                }
                while (enteredCommand != PlayerCommand.Exit &&
                       enteredCommand != PlayerCommand.Restart &&
                       this.isGameFinished != true);
            }
            while (enteredCommand != PlayerCommand.Exit);
            Console.WriteLine("\nGood bye!");
        }

        private void ExecuteCommand(PlayerCommand command)
        {
            switch (command)
            {
                case PlayerCommand.Top:
                    {
                        ScoreBoard.Instance.Print();
                        break;
                    }
                   
                case PlayerCommand.Restart:
                    {
                        this.playerHelper = new PlayerHelper();
                        this.cheats = 0;
                        this.attempts = 0;
                        Console.WriteLine();
                        break;
                    }
                case PlayerCommand.Help:
                    {
                        this.cheats = playerHelper.PrintHelp(cheats, generatedNumber);
                        break;
                    }
                case PlayerCommand.Exit:
                    {
                        break;
                    }
                case PlayerCommand.Other:

                    if (IsValidInput())
                    {
                        ProcessGame();
                    }
                    else
                    {
                        ConsolePrinter.PrintWrongCommandMessage();
                    }
                    break;
                default:
                    {
                        throw new InvalidOperationException("Invalid Input Command!");
                    }
            }
        }

        private void ProcessGame()
        {
            this.attempts++;
            int bullsCount = CallculateBullsCount();
            int cowsCount = CallculateCowsCount();
            if (bullsCount == generatedNumber.Length)
            {
                ConsolePrinter.PrintCongratulateMessage(attempts, cheats);
                FinishGame();
                playerHelper = new PlayerHelper();
                this.isGameFinished = true;
                this.cheats = 0;
                this.attempts = 0;
            }
            else
            {
                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}",
                    bullsCount, cowsCount);
            }
        }
        
        private int CallculateBullsCount()
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

        private int CallculateCowsCount()
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

        private bool IsValidInput()
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

        private void FinishGame()
        {
            if (cheats == 0)
            {
                Console.Write("Please enter your name for the top scoreboard: ");
                string playerName = Console.ReadLine();
                ScoreBoard.Instance.AddPlayer(playerName, attempts);
                ScoreBoard.Instance.Print();
            }
            else
            {
                Console.WriteLine("You are not allowed to enter the top scoreboard.");
            }
        }
    }
}