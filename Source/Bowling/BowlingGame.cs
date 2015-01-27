namespace Bowling
{
	public class BowlingGame
	{
		public int Score { get; private set; }
		
	    private bool _firstRoll = true;

		private int FrameScore { get; set; }
		
		public void Roll(int pins)
		{
			if (_firstRoll)
			{
				if (FrameScore == 10)
					Score += pins;
	
				FrameScore = 0;
			}

			FrameScore += pins;

			Score += pins;
			
			_firstRoll = !_firstRoll;
		}
		
	}
}