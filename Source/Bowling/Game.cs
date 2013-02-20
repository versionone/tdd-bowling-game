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
        private bool _isFirst;

        private int[,] frames = new int[10,2];

        public Game()
        {
            _score = 0;
            _frameCount = 0;
            _isFirst = true;
        }

        public void Roll(int _pins)
        {
            int _rollScore = _pins;
            if (_pins == 0) _rollScore = 0;
            
            //_score += _pins;
            int position = Convert.ToInt32(_isFirst);
            

            if (_isFirst && _frameCount != 0)
            {
                int _bonus = (frames[(_frameCount - 1), 0] + frames[(_frameCount - 1), 1]);
                if (_bonus > 9)
                {
                    frames[(_frameCount - 1), 1] += _rollScore;
                    
                }

            }

            frames[_frameCount, position] = _rollScore;

            
            if (!_isFirst)
            {
                _frameCount++;

            }

            _isFirst = !_isFirst;


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
