using System;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private int _rollCount;
		private int _frameScore;
		//private int _frameCount;

		public void Roll(int pins)
		{
			//if (_frameCount >= 10)
			if (_rollCount >= 20)
			{
				throw new Exception("game over");
			}

			_score += pins;
			_rollCount++;

			if (IsNewFrame)
			{
				if (IsPriorFrameSpare)
				{
					_score += pins;
				}

				_frameScore = 0;
				//_frameCount++;
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
