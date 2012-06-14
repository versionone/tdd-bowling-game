using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    internal class Frame
    {
        internal List<int> rolls = new List<int>();

        internal bool isStrike()
        {
            // the first roll needs to be 10
            return (rolls[0] == 10);
        }

        internal bool isSpare()
        {
            // the total of the first and second rolls need to be 10 (but not a strike)
            return (rolls[0] + rolls[1] == 10) && !isStrike();
        }

    }
}
