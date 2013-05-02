using System;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    class BullsAndCows
    {
       
       
        private string generatedNumber;
        private Score<Player> Klasirane;
        private const int NUMBER_LENGHT = 4;

        public BullsAndCows()
        {
            Klasirane = new Score<Player>();
        }

        private PlayerCommand PlayerInputToPlayerCommand(string playerInput)
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
                    enteredCommand = PlayerInputToPlayerCommand(playerInput);

                    if (enteredCommand == PlayerCommand.Top)
                    {
                        PrintScoreboard();
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
                AddPlayerToScoreboard(playerName, attempts);
                PrintScoreboard();
            }
            else
            {
                Console.WriteLine("You are not allowed to enter the top scoreboard.");
            }
        }

        private void AddPlayerToScoreboard(string playerName, int attempts)
        {
            Player player = new Player(playerName, attempts);
            Klasirane.Add(player);
        }

        private void PrintScoreboard()
        {
            if (Klasirane.Count == 0)
            {
                Console.WriteLine("Top scoreboard is empty.");
            }
            else
            {
                Console.WriteLine("Scoreboard:");
                int i = 1;
                foreach (Player p in Klasirane)
                {
                    Console.WriteLine("{0}. {1} --> {2} guess" + ((p.Attempts == 1) ? "" : "es"), i++, p.Name, p.Attempts);
                }
            }
        }

        static void Main(string[] args)
        {
            BullsAndCows game = new BullsAndCows();
            game.Start();
        }
    }
}