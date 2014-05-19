using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

namespace Bowling
{
    public class BowlingGame
    {
        public int Score { get; set; }
        private int Frame { get; set; }
        private int Ball { get; set; }
        private int LastRoll { get; set; }
        private int SecondToLastRoll { get; set; }

        public BowlingGame()
        {
            Score = 0;
            Frame = 1;
            Ball = 1;
            LastRoll = 0;
            SecondToLastRoll = 0;
        }

        public void Roll(int pins)
        {
            Debug.Print("{0} {1} - {2}", Frame, Ball, pins);
            CheckGameOver();
            UpdateScore(pins);
            UpdateLastRolls(pins);
            UpdateBallAndFrame();
            Debug.Print(" Score: {0}", Score);
        }

        private void UpdateScore(int pins)
        {
            /*
             * STLR LR  MULT
             * X    X   3
             * n    /   2
             * n    X   2
             * X    n   2
             * else     1
             */
            int multiplier = 1;
            if (!TenthFrame || Ball < 3)
            {
                if (LastRoll == 10 && SecondToLastRoll == 10)
                {
                    multiplier = 3;
                }
                else if (Ball == 1 && (LastRoll + SecondToLastRoll) == 10 || LastRoll == 10 || SecondToLastRoll == 10)
                {
                    multiplier = 2;
                }

                // Handle second ball in tenth frame special case
                if (TenthFrame && Ball == 2 && LastRoll == 10)
                {
                    multiplier--;
                }
            }

            Score += multiplier * pins;
        }

        private void UpdateLastRolls(int pins)
        {
            SecondToLastRoll = LastRoll;
            LastRoll = pins;
        }

        private void UpdateBallAndFrame()
        {
            Ball++;
            if (FrameComplete)
            {
                Ball = 1;
                Frame++;
            }
        }

        private bool FrameComplete
        {
            get
            {
                /*
                 * FrameComplete if:
                 * - non-tenth frame:
                 *   - We roll two balls
                 *   - The first ball we roll is a strike
                 * - tenth frame:
                 *  - We roll three balls
                 *  - We roll two balls with no marks
                 */
                if (TenthFrame)
                {
                    return Ball > 3 || Ball == 3 && !(LastRoll == 10 || SecondToLastRoll == 10 || (SecondToLastRoll + LastRoll) == 10);
                }
                else
                {
                    return Ball > 2 || LastRoll == 10;
                }
            }
        }

        private bool TenthFrame
        {
            get { return Frame == 10; }
        }

        private void CheckGameOver()
        {
            // If we are done with the tenth frame already, throw an exception
            if (Frame > 10)
                throw new InvalidOperationException("Game Over");
        }
    }
}
