using System;
using System.Net.Configuration;

namespace Bowling
{
	public class BowlingGame
	{
		public void Roll(int pins)
		{
			if(_frameCount == 10)
				throw new InvalidOperationException(("game over"));

			_rollCount++;
			var firstBall = _rollCount % 2 != 0;

			if(firstBall)
			{
				if(_lastFrameScore == 10)
				{
					Score += pins;
				}
				_lastFrameScore = 0;
			}
			else
			{
				_frameCount++;
			}

			Score += pins;
			_lastFrameScore += pins;
		}

		private int _lastFrameScore;

		public int Score { get; private set; }

		private int _rollCount;
		private int _frameCount;



	}
}