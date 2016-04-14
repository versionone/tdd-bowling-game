namespace Bowling
{

	public class Scoreboard
	{
	
		private int _score;
		private bool _lastFrameWasSpare;

		public void Record(int pins1, int pins2)
		{
			var frameScore = pins1 + pins2;
			_score += frameScore;
			if (_lastFrameWasSpare)
			{
				_score += pins1;
			}
			_lastFrameWasSpare = frameScore == 10;
		}

		public int Score
		{
			get { return _score; }
		}
	}
}