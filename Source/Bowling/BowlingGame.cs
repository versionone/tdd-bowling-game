using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Bowling
{
	public class BowlingGame
	{
		public void Roll(int pins)
		{
			if (totalFramesBowled >= 10)
			{
				throw new InvalidOperationException("Game over! Max number of frames already bowled.");
			}
			Score += pins;

			scorableRollCounters = scorableRollCounters
				.Where(value => value > 0)
				.Select(value =>
				{
					Score += pins;
					return value - 1;
				})
				.ToList();
			
			if (IsCurrentStrike(pins))
			{
				startOfFrame = false;
				scorableRollCounters.Add(2);
			}
			else if (IsCurrentSpare(pins))
			{
				scorableRollCounters.Add(1);
			}
			
			if (!startOfFrame)
			{
				totalFramesBowled++;
			}
			startOfFrame = !startOfFrame;
			lastRoll = pins;
		}

		private bool IsCurrentSpare(int pins)
		{
			return !startOfFrame && pins + lastRoll == 10;
		}

		private bool IsCurrentStrike(int pins)
		{
			return startOfFrame && pins == 10;
		}

		private bool startOfFrame = true;
		private int lastRoll;
		private int totalFramesBowled = 0;
		private List<int> scorableRollCounters = new List<int>();

		public int Score { get; private set; }
	}
}