using System.Net.Configuration;

namespace Bowling
{
	public class BowlingGame
	{
		public void Roll(int pins)
		{
			_rollCount++;
			var firstBall = _rollCount%2 != 0;

			if(firstBall)
			{
				if(_lastFrameScore == 10)
				{
					Score += pins;
				}
				_lastFrameScore = 0;

			}

			Score += pins;
			_lastFrameScore += pins;
		}

		private int _lastFrameScore;

		public int Score { get; private set; }

		private int _rollCount;



	}
}