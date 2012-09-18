namespace Bowling
{
	public class BowlingGame
	{
		private int score;

		public void Roll(int i)
		{
			score += i;
		}

		public int CalculateScore()
		{
			return score;
		}
	}
}