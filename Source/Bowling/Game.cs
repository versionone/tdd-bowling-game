namespace Bowling
{
	public class Game
	{
		private int _score;
		private int _rollCount;
		private int _frameScore;

		public void Roll(int pins)
		{
/*			if (_score == 10 && _rollCount == 2)
			{
				_score += pins;
			}*/

			_score += pins;
			_rollCount++;

			if (_rollCount % 2 == 1)
			{
				if (_frameScore == 10)
				{
					_score += pins;
				}

				_frameScore = 0;
			}

			_frameScore += pins;
		}

		public int GetScore()
		{
			return _score;
		}
	}
}
