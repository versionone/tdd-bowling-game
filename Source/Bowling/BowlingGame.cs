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
        protected int[] _pins_fallen = new int[] {0, 0};
        protected int _rolls_taken = 0;

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

        private int getFirstTwo()
        {
            return _pins_fallen[0] + _pins_fallen[1];
        }

        private int getFirst()
        {
            return _pins_fallen[0];
        }

        public virtual bool isComplete()
        {
            return (getTotal() == 10 || _rolls_taken >= 2);
        }

        public bool is_strike()
        {
            return getTotal() == 10 && _rolls_taken == 1;
        }
        
        public bool is_spare()
        {
            return getTotal() == 10 && _rolls_taken == 2;
        }

        public virtual  int compute_score(Frame next1, Frame next2)
        {
            int total = getTotal();
            if (this.is_strike())
            {
                if (next1.is_strike())
                {
                    total += next1.getFirstTwo() + next2.getFirst();
                }
                else
                {
                    total += next1.getFirstTwo();
                }
            }
            if (this.is_spare())
            {
                total += next1.getFirst();
            }
            return total;
        }

    }


    public class FinalFrame: Frame
    {
        public FinalFrame()
        {
            _pins_fallen = new int[] { 0, 0, 0 };
        }

        public override bool isComplete()
        {
            if( _rolls_taken >= 3)
            {
                return true;
            }

            if( _rolls_taken == 2)
            {
                if(getTotal() < 10)
                {
                    return true;
                }
            }
            return false;
        }
    }


    public class BowlingGame
    {
        public const int FRAMES_IN_GAME = 10;
        public const int FRAMES_WITH_DUMMIES = FRAMES_IN_GAME + 2;
        private Frame[] _frames = new Frame[FRAMES_WITH_DUMMIES];
        private int _current_frame = 0; // zero-based!
        public BowlingGame()
        {
            for(int i=0; i < FRAMES_WITH_DUMMIES; i++)
            {
                _frames[i] = new Frame();
            }

            _frames[FRAMES_IN_GAME - 1] = new FinalFrame();
        }

        public int getScore()
        {
            int total = 0;
            for (int i = 0; i< FRAMES_IN_GAME; i++)
            {
                total += _frames[i].compute_score(_frames[i+1], _frames[i+2]); 
            }
            return total;
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
        }
    }
}