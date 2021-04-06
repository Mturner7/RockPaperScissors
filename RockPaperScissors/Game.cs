using System;

namespace RockPaperScissors
{
    class Game
    {
        private static bool ContinuePrompt(string msg)
        {
            string input;

            do
            {
                Console.Write($"\n{msg} (y/n): ");
                input = Console.ReadLine().ToLower();

            } while (input != "n" && input != "y");

            if (input == "n") return false;
            
            return true;
        }

        private static Player ChooseOpponent()
        {
            string input;

            do
            {
                Console.Write("\nDo you want to play against Longyboywolfie98 or Dynamo977? (l/d): ");
                input = Console.ReadLine().ToLower();

                if (input == "l" || input == "longboywolfie98") return new RockPlayer();


            } while ((input != "d" && input != "dynamo977"));

            return new RandomPlayer(new Random());
        }

        private static bool CheckForWinner(Player thePlayer, Player Opponent)
        {
            Values playerChoice = thePlayer.GenerateRoShamBo();
            Values oppChoice = Opponent.GenerateRoShamBo();

            Console.WriteLine($"\n{Opponent.Name}'s Move: {(oppChoice)}");
            Console.WriteLine($"{thePlayer.Name}'s Move: {(playerChoice)}\n");

            if ((oppChoice == Values.ROCK && playerChoice == Values.SCISSORS) || (oppChoice == Values.PAPER && playerChoice == Values.ROCK) 
                || (oppChoice == Values.SCISSORS && playerChoice == Values.PAPER))
            {
                Opponent.Wins++;
                Console.WriteLine($"{Opponent.Name} wins!");
            }
            else if (playerChoice == oppChoice)
            {
                Console.WriteLine("Tie! Nobody wins!");
                return false;
            }
            else
            {
                thePlayer.Wins++;
                Console.WriteLine($"{thePlayer.Name} wins!");
            }

            return true;
        }

        public static void PlayGame()
        {
            int ties = 0;
            int gameCount = 0;
            bool playing = true;
            bool DifferentOpponent = false;

            Console.WriteLine($"Welcome to Ro Sham Bo!");

            Console.Write("\nWhat's your name buckaroo? ");
            Human thePlayer = new Human(Console.ReadLine());

            Player Opponent = ChooseOpponent();

            while (playing)
            {
                
                Console.Clear();
                Console.WriteLine($"| Game: {++gameCount} |");
                Console.WriteLine($"| Ties: {ties} |");
                Console.WriteLine($"| {thePlayer.Name}'s total wins: {thePlayer.Wins} |");
                Console.WriteLine($"| {Opponent.Name}'s total wins: {Opponent.Wins} | \n");

                if (!CheckForWinner(thePlayer, Opponent)) ties++; // If nobody wins, increment the total of amount of ties

                playing = ContinuePrompt($"Would you like to play {Opponent.Name} again?");

                if (!playing) // Prompt the user if they want to play a different opponent before exiting
                {
                    DifferentOpponent = ContinuePrompt("Would you like play against a different opponent?");
                    playing = DifferentOpponent;
                }

                if (DifferentOpponent) // If the user chooses to continue with a different opponent, reset all stats
                {
                    thePlayer.Wins = gameCount = ties = 0;
                    Opponent = ChooseOpponent();
                }

            }
        }

        static void Main(string[] args)
        {
            PlayGame();
        }
    }
}
