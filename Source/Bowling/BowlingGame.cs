namespace Bowling
{
	public class BowlingGame
	{
		public int Score { get; private set; }

		public void Roll(int pins)
		{
			Score = Score + pins;
		}
	}
}