namespace Bowling
{
	public class BowlingGame
	{
		private int TotalFrames;
		private int TotalFrameRolls;
		private int DoubleCountRolls;
		private int LastRoll;

		public void Roll(int pins)
		{
			Score += pins;

			if (DoubleCountRolls > 0)
			{
				Score += pins;
				DoubleCountRolls--;
			}

			if(TotalFrameRolls == 0 && pins == 10)
			{
				DoubleCountRolls = 2;
			}
			else if (TotalFrameRolls == 1 && LastRoll + pins == 10)
			{
				DoubleCountRolls = 1;
			}

			if (TotalFrameRolls == 1)
			{
				TotalFrameRolls = 0;
				TotalFrames++;
			}
			else if (pins == 10)
			{
				TotalFrames++;
			}
			else
			{
				TotalFrameRolls++;
			}

			LastRoll = pins;
		}

		public int Score { get; private set; }

		public bool CanRoll
		{
			get { return TotalFrames < 10; }
		}
	}
}