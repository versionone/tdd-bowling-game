using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class BowlingGame
    {
        public void Bowl(int pins)
        {
            Score = Score + pins;
        }

        public int Score { get; set; }
    }
}
