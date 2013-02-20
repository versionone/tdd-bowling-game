using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class Game
    {
        private int _score;
        private int _frameCount;
        private bool _isFirstRoll;

        private int[,] frames = new int[10,2];

        public Game()
        {
            _score = 0;
            _frameCount = 0;
            _isFirstRoll = true;
        }

        public void Roll(int _pins)
        {
            int _rollScore = _pins;

            if (_isFirstRoll && _frameCount != 0)
            {
                if (IsSpare(frames[(_frameCount - 1), 0], frames[(_frameCount - 1), 1]))
                {
                    frames[(_frameCount - 1), 1] += _rollScore;
                }
            }

            frames[_frameCount, Convert.ToInt32(_isFirstRoll)] = _rollScore;

            
            if (!_isFirstRoll)
            {
                _frameCount++;

            }

            _isFirstRoll = !_isFirstRoll;
        }

        private bool IsSpare(int firstRoll, int secondRoll)
        {
            return firstRoll + secondRoll == 10;
        }

        public int Score()
        {
            for (int i = 0; i < _frameCount; i++)
            {

                _score += (frames[(i), 0] + frames[(i), 1]);
            }
            return _score;
        }
    }
}
