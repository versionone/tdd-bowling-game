using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class BowlingGame
    {
        private const int SPARE = 10;
        private const int STRIKE = 10;
        private const int MAX_NUM_FRAMES = 10;
        private int numOfRollsInFrame = 0;
        private int numOfFrames = 0;
        private int previousFrameScore = 0;
        private int lastRollScore = 0;

        public void Bowl(int pins)
        {
            numOfRollsInFrame++;
            if (numOfFrames >= MAX_NUM_FRAMES)
            {
                throw new GameOverException();
            }

            if (previousFrameScore == SPARE)
            {
                Score = Score + pins;
                previousFrameScore = 0;
            }
           
            if (IsFirstRollOfFrame())
            {
                // first roll in current frame
                lastRollScore = pins;
                if (pins == STRIKE)
                {
                    numOfFrames++;
                    numOfRollsInFrame = 0;
                    previousFrameScore = pins;
                }
            }
            else
            {
                numOfFrames++;
                numOfRollsInFrame = 0;
                previousFrameScore = pins + lastRollScore;
            }
            Score = Score + pins;
        }

        public int Score { get; set; }

        private bool IsFirstRollOfFrame() {
            return numOfRollsInFrame % 2 == 1;
        }
    }

    public class GameOverException : Exception { 
    }
}
