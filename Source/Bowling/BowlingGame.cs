namespace Bowling
{
	public class BowlingGame
	{
		public void Roll(int pins)
		{
			Score += pins;

			if (lastFrameIsSpare)
			{
				Score += pins;
				lastFrameIsSpare = false;
			}

			if (IsSpare(pins))
			{
				lastFrameIsSpare = true;
			}

			startOfFrame = !startOfFrame;
			lastRoll = pins;
		}

		private bool IsSpare(int pins)
		{
			return !startOfFrame && pins + lastRoll == 10;
		}

		private bool startOfFrame = true;
		private int? lastRoll;
		private bool lastFrameIsSpare = false;
		public int Score { get; private set; }
	}
}