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
		public int lastPins { get; set; }

		public int Roll(int pins)
		{
			RollCount++;
			Score += pins;

			if (IsEndOfFrame() && IsASpare(pins))
			{
				IsSpare = true;
			}
			else if (IsSpare)
			{
				Score += pins;
				IsSpare = false;
			}

			lastPins = pins;
			return pins;
		}

		private bool IsASpare(int pins)
		{
			return (lastPins + pins) == 10;
		}

		private bool IsEndOfFrame()
		{
			return (RollCount % 2) == 0;
		}
	}
}

