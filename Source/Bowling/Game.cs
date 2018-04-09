namespace Bowling
{
	public class Game
	{
		private int _score;

		public int Score { get { return _score; } }

		public void Roll(int pins)
		{
			_score = _score + pins;
		}
	}
}
