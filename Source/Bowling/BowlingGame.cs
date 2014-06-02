using System;
using System.Net.Configuration;

namespace Bowling
{
	public class BowlingGame
	{
		public void Roll(int pins)
		{
			CheckGameOver();

			var firstBall = _rollCount % 2 == 0;

			if(firstBall)
			{
				HandleLastFrameBonus(pins);
			}
			else
			{
				_frameCount++;
			}

			_rollCount++;
			Score += pins;
			_lastFrameScore += pins;
		}

		private void HandleLastFrameBonus(int pins)
		{
			if (LastFrameWasASpare)
			{
				Score += pins;
			}

			_lastFrameScore = 0;
		}

		private void CheckGameOver()
		{
			if (_frameCount == 10)
				throw new InvalidOperationException(("game over"));
		}

		private bool LastFrameWasASpare
		{
			get { return _lastFrameScore == 10; }
		}

		private int _lastFrameScore;

		public int Score { get; private set; }

		private int _rollCount;
		private int _frameCount;
	}
}