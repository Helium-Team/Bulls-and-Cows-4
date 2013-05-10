using System;
using System.Linq;

namespace BullsAndCowsGame
{
    public class GameEngine
    {
        const int MAX_COW_VARIATIONS = 10;
        private string playerInput = null;
        private string generatedNumber = null;
        private bool isGameFinished = false;
        private int attempts = 0;
        private int cheats = 0;
        
        public GameEngine()
        {
        }
        
        public void Start()
        {
            PlayerCommand enteredCommand;
            do
            {
                ConsolePrinter.PrintWelcomeMessage();
                this.generatedNumber = NumberGenerator.GenerateNumber();
                this.isGameFinished = false;
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
                        PlayerHelper.ClearHelp();
                        this.cheats = 0;
                        this.attempts = 0;
                        Console.WriteLine();
                        break;
                    }
                case PlayerCommand.Help:
                    {
                        this.cheats = PlayerHelper.PrintHelp(cheats, generatedNumber);
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
            bool[] isBull = new bool[generatedNumber.Length];
            CheckPlayerInputForBull(isBull);
            int bullsCount = CallculateBullsCount(isBull);
            int cowsCount = CallculateCowsCount(isBull);
            this.attempts++;
            if (bullsCount == generatedNumber.Length)
            {
                ConsolePrinter.PrintCongratulateMessage(attempts, cheats);
                FinishGame();
                PlayerHelper.ClearHelp();
                this.isGameFinished = true;
                this.cheats = 0;
                this.attempts = 0;
            }
            else
            {
                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bullsCount, cowsCount);
            }
        }

        private void CheckPlayerInputForBull(bool[] isBull)
        {
            for (int i = 0; i < this.playerInput.Length; i++)
            {
                if (this.playerInput[i] == this.generatedNumber[i])
                {
                    isBull[i] = true;
                }
            }
        }
        
        private int CallculateBullsCount(bool[] isBull)
        {
            int bullsCount = 0;
            for (int i = 0; i < isBull.Length; i++)
            {
                if (isBull[i] == true)
                {
                    bullsCount++;
                }
            }
            return bullsCount;
        }

        private int CallculateCowsCount(bool[] isBull)
        {
            int cowsCount = 0;
            bool[] isNumberACow = new bool[MAX_COW_VARIATIONS];
            
            for (int i = 0; i < this.playerInput.Length; i++)
            {
                for (int j = 0; j < this.generatedNumber.Length; j++)
                {
                    int checkedDigit = int.Parse(this.generatedNumber[i].ToString());
                    if ((this.playerInput[i] == this.generatedNumber[j]) && (!isBull[i]) && (!isNumberACow[checkedDigit]))
                    {
                        cowsCount++;
                        isNumberACow[checkedDigit] = true;
                    }
                }
            }
            return cowsCount;
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
                while (playerName == null || string.IsNullOrWhiteSpace(playerName))
                {
                    Console.WriteLine("Invalid name!\nEnter valid name");
                    playerName = Console.ReadLine();
                }
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