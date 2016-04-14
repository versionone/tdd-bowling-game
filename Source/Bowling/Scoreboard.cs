using System;

namespace Bowling
{

	public class Scoreboard
	{
		private int _framesBowled = 0;
		private int _score;
		private bool _lastFrameWasSpare;

		public void Record(int pins1, int pins2)
		{
			if (_framesBowled >= 10)
			{
				throw new Exception("You already bowled 10 frames");
			}

			var frameScore = pins1 + pins2;
			_score += frameScore;
			if (_lastFrameWasSpare)
			{
				_score += pins1;
			}
			_lastFrameWasSpare = frameScore == 10;
			_framesBowled++;
		}

		public int Score
		{
			get { return _score; }
		}
	}
}