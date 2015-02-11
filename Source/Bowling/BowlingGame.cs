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

			if (previousFrameIsSpare)
			{
				Score += pins;
				previousFrameIsSpare = false;
			}

			if (IsCurrentSpare(pins))
			{
				previousFrameIsSpare = true;
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

		private bool startOfFrame = true;
		private int lastRoll;
		private bool previousFrameIsSpare = false;
		private int totalFramesBowled = 0;

		public int Score { get; private set; }
	}
}