using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    class Dynamo977 : Player
    {
        private static Random rand;

        public override Values GenerateRoShamBo()
        {
            int c = rand.Next(1, 4);
            Choice = (Values)c;
            return Choice;
        }

        public Dynamo977(Random rng)
        {
            rand = rng;
            Name = "Dynamo977";
        }
    }
}
