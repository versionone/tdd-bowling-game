namespace Bowling
{
	public class BowlingGame
	{
		public int Score { get; set; }
		
		public bool FirstRoll = true;

		public int FrameScore { get; set; }
		
		public void Roll(int pins)
		{
			if (FirstRoll)
			{
				if (FrameScore == 10)
					Score += pins;
	
				FrameScore = 0;
			}

			FrameScore += pins;

			Score += pins;
			
			FirstRoll = !FirstRoll;
		}
		
	}
}