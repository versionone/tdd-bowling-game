using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class BowlingGame
    {
        private int numOfRolls = 0;
        private int previousFrameScore = 0;
        private int lastRollScore = 0;
        private bool wasPreviousFrameASpare = false;

        public void Bowl(int pins)
        {
            if (previousFrameScore == 10)
            {
                Score = Score + pins;
                previousFrameScore = 0;
            }
            numOfRolls++;
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
}
