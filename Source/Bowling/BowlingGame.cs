using System;
using System.Collections.Generic;
using System.Linq;


namespace Bowling
{
    public class FrameFullException : Exception
    {
        
    }

    public class Frame
    {
        private int[] _pins_fallen = new int[] {0, 0};
        private int _rolls_taken = 0;

        public Frame()
        {

        }

        public void addRoll(int pins_fallen)
        {
            _pins_fallen[_rolls_taken] = pins_fallen;
            _rolls_taken++;
        }

        public int getTotal()
        {
            return _pins_fallen.Sum();
        }

        private int getFirst()
        {
            return _pins_fallen[0];
        }

        public bool isComplete()
        {
            return (getTotal() == 10 || _rolls_taken >= 2);
        }

        public int my_score(Frame next1,  Frame next2)
        {
            if (getTotal() < 10)
            {
                return getTotal();
            }

            if (next1 != null)
            {
                //this is where we are
            }

    }

    }

    public class BowlingGame
    {
        public const int FRAMES_IN_GAME = 10;
        private Frame[] _frames = new Frame[FRAMES_IN_GAME];
        private int _current_frame = 0; // zero-based!
        public BowlingGame()
        {
            for(int i=0; i < FRAMES_IN_GAME; i++)
            {
                _frames[i] = new Frame();
            }
        }

        public int getScore()
        {

            returnFrameScore(frame, n1frame, n2frame) => correct frame score

            return _frames.Sum(frame => frame.getTotal());
        }



        public void Roll(int pins_fallen)
        {
            if (_frames[_current_frame].isComplete())
            {
                _current_frame++;
            }

            if(_current_frame >= FRAMES_IN_GAME)
            {
                throw new GameEndException();
            }

            _frames[_current_frame].addRoll(pins_fallen);
            // i dont know when to increment the frame count
            // i don't know when the game has ended
        }
    }
}