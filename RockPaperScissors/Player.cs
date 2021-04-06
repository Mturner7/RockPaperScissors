using System;

namespace RockPaperScissors
{
    public enum Values
    {
        ROCK = 1,
        PAPER = 2,
        SCISSORS = 3
    }

    abstract class Player
    {

        public int Wins { get; set; }
        public string Name { get; set; }
        public Values Choice { get; set; }

        public virtual Values GenerateRoShamBo() 
        {
            Values rock = Values.ROCK;
            return rock;
        }

        public Player()
        {
            Wins = 0;
        }
    }
}
