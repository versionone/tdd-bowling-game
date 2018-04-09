using System;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private int _ballsThrown;
		private bool _isSpare;
		private int _lastBallThrown;
		private int _numberOfFrames = 1;

		public int Score
		{
			get { return _score; }
		}

		public void Roll(int pins)
		{
			if (_numberOfFrames > 10)
				throw new TooManyFramesException();

			_ballsThrown += 1;
			if (_isSpare == true)
			{
				_score += pins;
				_isSpare = false;
			}

			if (_ballsThrown == 2 && (pins + _lastBallThrown) == 10)
				_isSpare = true;

			_score = _score + pins;

			if (_ballsThrown == 2)
			{
				_ballsThrown = 0;
				_numberOfFrames++;
			}

			_lastBallThrown = pins;
		}
	}

	public class TooManyFramesException : Exception { }
}