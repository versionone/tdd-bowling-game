namespace Bowling
{
	public class BowlingGame
	{
		public void Roll(int pins)
		{
			RollCount++;

			if(Score == 10 && RollCount == 3)
				Score += pins;

			Score += pins;
		}

		public int Score { get; private set; }

		public int RollCount { get; private set; }
	}
}