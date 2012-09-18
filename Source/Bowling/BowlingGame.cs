namespace Bowling
{
	public class BowlingGame
	{
		private int score;
		private int roll;
		private int lastFrameTally;
		public void Roll(int pins)
		{

			roll++;
			if (LastFrameWasASpare())
			{
				score += pins;
			}
			if (roll % 2 != 0)
				lastFrameTally = pins;
			else
				lastFrameTally += pins;

			score += pins;
			// create history of last two rolls for next call

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