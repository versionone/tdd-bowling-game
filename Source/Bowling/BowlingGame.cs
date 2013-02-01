using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		public int Score { get; set; }
		public bool IsSpare { get; set; }
		public int  RollCount { get; set; }

		public int Roll(int pins)
		{
			RollCount++;
			Score += pins;
			if (RollCount == 2 && Score == 10)
			{
				IsSpare = true;
			}
			if (IsSpare && RollCount == 3)
			{
				Score += pins;
			}
			return pins;
		}
	}
}
