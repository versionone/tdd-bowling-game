namespace Bowling
{
	public class Game
	{
		private int _score;
		private int _rollCount;
		private int _frameScore;

		public void Roll(int pins)
		{
			_score += pins;
			_rollCount++;

			if (IsNewFrame)
			{
				if (IsPriorFrameSpare)
				{
					_score += pins;
				}

				_frameScore = 0;
			}

			_frameScore += pins;
		}

		private bool IsPriorFrameSpare => _frameScore == 10;

		private bool IsNewFrame
		{
			get { return _rollCount % 2 == 1; }
		}

		public int GetScore()
		{
			return _score;
		}
	}
}
