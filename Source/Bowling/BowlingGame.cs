using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		public int Score { get; set; }

		public int  RollCount { get; set; }
		public int lastPins { get; set; }
		public Frame gameFrame { get; set; }

		public BowlingGame()
		{
			gameFrame = new Frame();

		}

		public void Roll(int pins)
		{
			if (gameFrame.IsSpare)
			{
				Score += pins;
			}
			if (gameFrame.IsClosed)
			{
				gameFrame = new Frame();
			}

			gameFrame.Turn++;
			Score += gameFrame.Roll(pins);
		}
	}
}

