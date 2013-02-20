using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class Game
    {
        private int _score;

        public Game()
        {
            _score = 0;
        }

        public void Roll(int _pins)
        {
            if (_pins == 0) _score = 0;
            _score += _pins;
        }

        public int Score()
        {
            return _score;
        }
    }
}
