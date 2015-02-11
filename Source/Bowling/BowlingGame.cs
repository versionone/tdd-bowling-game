namespace Bowling
{
	public class BowlingGame
	{
		public void Roll(int pins)
		{
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
		public int Score { get; private set; }
	}
}