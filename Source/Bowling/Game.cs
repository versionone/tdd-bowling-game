using System;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private int _frameScore;
		private int _frameCount = 1;
		private int _frameRollCount;
		private bool _strikeWasRolled;
		private bool _needOneMoreBonusRoll;

		public void Roll(int pins)
		{
			_frameRollCount++;

			if (_needOneMoreBonusRoll)
			{
				_score += pins;
				_needOneMoreBonusRoll = false;
			}

			if (IsNewFrame)
			{
				if (IsPriorFrameSpare)
				{
					_score += pins;
				}

				if (_strikeWasRolled)
					_needOneMoreBonusRoll = true;

				StartNewFrame();

				if (IsGameOver)
					throw new Exception("game over");
			}

			if (pins == 10)
				_strikeWasRolled = true;

			_score += pins;
			_frameScore += pins;
		}

		private bool IsGameOver => _frameCount > 10;

		private void StartNewFrame()
		{
			_frameScore = 0;
			_frameCount++;
			_frameRollCount = 1;
			_strikeWasRolled = false;
		}

		private bool IsPriorFrameSpare => _frameScore == 10;

		private bool IsNewFrame
		{
			get { return _frameRollCount == 3 || _strikeWasRolled; }
		}

		public int GetScore()
		{
			return _score;
		}
	}
}
