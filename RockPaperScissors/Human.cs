using System;


namespace RockPaperScissors
{
    class Human : Player
    {
        public override Values GenerateRoShamBo()
        {
            bool valid;
            string input;

            do // This loop will only run once if the user enters a valid response
            {
                valid = true;
                Console.Write("Rock, paper, or scissors (r/p/s)? Your move... ");
                input = Console.ReadLine().ToLower();

                if (input == "r" || input == "rock") Choice = Values.ROCK;
                else if (input == "p" || input == "paper") Choice = Values.PAPER;
                else if (input == "s" || input == "scissors") Choice = Values.SCISSORS;
                
                else
                {
                    valid = false;
                    Console.WriteLine("Whoops! You made a mistake, that's not a valid response! Try again...\n");
                }

            } while (!valid);

            return Choice;
        }

        public Human(string name)
        {
            Name = name;
        }
    }
}
