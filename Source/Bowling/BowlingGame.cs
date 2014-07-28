using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class BowlingGame
    {
        private const int SPARE = 10;
        private const int MAX_NUM_ROLLS = 20;
        private int numOfRolls = 0;
        private int previousFrameScore = 0;
        private int lastRollScore = 0;

        public void Bowl(int pins)
        {
            numOfRolls++;
            if (numOfRolls > MAX_NUM_ROLLS)
            {
                throw new GameOverException();
            }

            if (previousFrameScore == SPARE)
            {
                Score = Score + pins;
                previousFrameScore = 0;
            }
           
            if (numOfRolls % 2 == 1)
            {
                // first roll in current frame
                lastRollScore = pins;
            }
            else
            {
                previousFrameScore = pins + lastRollScore;
            }
            Score = Score + pins;
        }

        public int Score { get; set; }
    }

    public class GameOverException : Exception { 
    }
}
