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

                if (input == "l" || input == "longboywolfie98") return new Longboywolfie98();
               

            } while ((input != "d" && input != "dynamo977"));
          
            return new Dynamo977(new Random());
        }


        public static void PlayGame()
        {
            int gameCount = 0;
            bool playing = true;
            
            Console.WriteLine($"Welcome to Ro Sham Bo!");

            Console.Write("\nWhat's your name buckaroo? ");
            Human thePlayer = new Human(Console.ReadLine());

            Player Opponent = ChooseOpponent();

            while (playing)
            {
                Console.Clear();
                Console.WriteLine($"| Game: {++gameCount} |");
                Console.WriteLine($"| {thePlayer.Name}'s total wins: {thePlayer.Wins} |");
                Console.WriteLine($"| {Opponent.Name}'s total wins: {Opponent.Wins} | \n");

                int playerChoice = (int)thePlayer.GenerateRoShamBo();
                int oppChoice = (int)Opponent.GenerateRoShamBo();

                Console.WriteLine();
                Console.WriteLine($"{Opponent.Name}'s Move: {((Player.Values)oppChoice)}");
                Console.WriteLine($"{thePlayer.Name}'s Move: {((Player.Values)playerChoice)}\n");

                if ((oppChoice == 2 && playerChoice == 1) || (oppChoice == 3 && playerChoice == 2) || (oppChoice == 1 && playerChoice == 3))
                {
                    Opponent.Wins++;
                    Console.WriteLine($"{Opponent.Name} wins!");
                }
                
                else if (playerChoice == oppChoice) Console.WriteLine("\nTie! Nobody wins!");
                
                else
                {
                    thePlayer.Wins++;
                    Console.WriteLine($"{thePlayer.Name} wins!");
                }

                playing = ContinuePrompt("Would you like to play again?");
            }
        }

        static void Main(string[] args)
        {
            PlayGame();
        }
    }
}
