namespace Bowling
{
	public class BowlingGame
	{
		private int TotalRolls;
		private int LastRoll;
		private bool IsLastFrameSpare;

		public void Roll(int pins)
		{
			Score += pins;

			if (TotalRolls % 2 == 0)
			{
				if (IsLastFrameSpare)
				{
					Score += pins;
				}

				IsLastFrameSpare = false;
			}
			else if (LastRoll + pins == 10)
			{
				IsLastFrameSpare = true;
			}

			TotalRolls++;
			LastRoll = pins;
		}

		public int Score { get; private set; }
	}
}