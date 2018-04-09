namespace Bowling
{
	public class Game
	{
		private int _score;
		private int _ballsThrown;
		private bool _isSpare;
		private int _lastBallThrown;

		public int Score
		{
			get { return _score; }
		}

		public void Roll(int pins)
		{
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
				_ballsThrown = 0;
			_lastBallThrown = pins;
		}
	}
}