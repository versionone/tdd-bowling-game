using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class Frame
    {
        public int RollOne { get; set; }
        public int? RollTwo { get; set; }
        // public int Bonus { get; set; } = 0;

        public bool IsComplete => IsStrike || RollTwo.HasValue;
        public bool IsStrike => RollOne == 10;
        public bool IsSpare => !IsStrike && RollOne + (RollTwo ?? 0) == 10;

        //public int GetTotal()
        //{
        //    return RollOne + (RollTwo ?? 0) + Bonus;
        //}
    }
}
