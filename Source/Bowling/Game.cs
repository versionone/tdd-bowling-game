namespace Bowling
{
	public class Game
	{
		private int _score;
		private int _rollCount;

		public void Roll(int pins)
		{
			if (_score == 10 && _rollCount == 2)
			{
				_score += pins;
			}
			_score += pins;
			_rollCount++;
		}

		public int GetScore()
		{
			return _score;
		}
	}
}
