using System;

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

			if (remainingRollsToAdd > 0)
			{
				Score += pins;
				remainingRollsToAdd--;
			}
			
			if (IsCurrentStrike(pins))
			{
				startOfFrame = false;
				remainingRollsToAdd = 2;
			}
			else if (IsCurrentSpare(pins))
			{
				remainingRollsToAdd = 1;
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
		private int remainingRollsToAdd = 0;

		public int Score { get; private set; }
	}
}