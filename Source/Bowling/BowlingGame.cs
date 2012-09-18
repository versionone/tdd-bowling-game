namespace Bowling
{
	public class BowlingGame
	{
		private int score;
		private int roll;
		private int lastFrameTally;
		private bool lastFrameWasStrike;
		public void Roll(int pins)
		{

			roll++;
			if (pins == 10) //strike, so incrementing rolls to simulate new frame
			{
				roll++;
			}
			if (StrikeInLastFrame() || LastFrameWasASpare())
			{
				score += pins;
			}
			score += pins;

			if (roll % 2 != 0)
			{
				lastFrameTally = pins;
			}
			else
			{
				lastFrameTally += pins;
				lastFrameWasStrike = (pins == 10);
			}
		}

		private bool StrikeInLastFrame()
		{
			return lastFrameWasStrike;
		}

		private bool LastFrameWasASpare()
		{
			return lastFrameTally == 10;
		}

		public int CalculateScore()
		{
			return score;
		}
	}
}