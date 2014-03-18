using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Bowling
{
    public class Scorecard
    {
        private int[] scores;
        private int numRolls;

        public Scorecard()
        {
            scores = new int[24];
            numRolls = 0;
        }

        private bool isStrike(int index)
        {
            return (scores[index] == 10) && (index % 2 == 0);
        }

        private bool isSpare(int index)
        {
            return ((scores[index] + scores[index + 1] == 10) && (scores[index]) != 10 && index % 2 == 0);
        }

        public int GetScore()
        {
            int score = 0;
            for(var i = 0; i < 20; i = i + 2)
            {
                if (isStrike(i))
                {
                    score = score + scores[i];
                    score = score + scores[i + 2];
                    if (isStrike(i + 2))
                    {
                        score = score + scores[i + 4];
                    }
                    else
                    {
                        score = score + scores[i + 3];
                    }
                }
                else if (isSpare(i))
                {
                    score = score + scores[i] + scores[i + 1] + scores[i + 2];
                }
                else
                {
                    score = score + scores[i] + scores[i + 1];
                }
                
            }

            return score;
        }

        public void roll(int score)
        {

            if ((numRolls >= 21 && !isStrike(18)) 
                || (numRolls >= 22 && !isStrike(20)) 
                || (numRolls >= 24) 
                || (numRolls >= 20 && !isStrike(16) && !isStrike(18) && !isSpare(18)) )
            {
                throw new TooManyRollsException();
            }

            scores[numRolls] = score;
            if (score == 10 && numRolls%2 != 1)
            {
                numRolls = numRolls + 2;
            }
            else
            {
                numRolls++;
            }


        }
    }

    public class TooManyRollsException : Exception
    {
        
    }
}
