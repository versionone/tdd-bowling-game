namespace Bowling
{
	public class Game
	{
		private int _score;
		private int _ballsThrown;

		public int Score { get { return _score; } }

		public void Roll(int pins)
		{
			_ballsThrown += 1;
			_score = _score + pins;
			if (_score == 10 && _ballsThrown == 2)
				_score += pins;
		}
	}
}
