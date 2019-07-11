using System;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private int _frameScore;
		private int _frameCount = 1;
		private int _frameRollCount;

		public void Roll(int pins)
		{
			_frameRollCount++;

			if (IsNewFrame)
			{
				if (IsPriorFrameSpare)
				{
					_score += pins;
				}

				_frameScore = 0;
				_frameCount++;
				_frameRollCount = 1;

				if (_frameCount > 10)
				{
					throw new Exception("game over");
				}
			}

			_score += pins;
			_frameScore += pins;
		}

		private bool IsPriorFrameSpare => _frameScore == 10;

		private bool IsNewFrame
		{
			get { return _frameRollCount == 3; }
		}

		public int GetScore()
		{
			return _score;
		}
	}
}
