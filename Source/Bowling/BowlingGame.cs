using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private readonly int[] _balls = new int[21];
		private int _currentBall = 0;

		public void Roll(int i)
		{
			_balls[_currentBall++] = i;
		}

		public int Score
		{
			get { return CalculateScore(); }
		}

		private int CalculateScore()
		{
			var score = 0;
			var prevFrameSpare = false;

			for (var i = 0; i < _balls.Length; i++)
			{
				if (prevFrameSpare)
				{
					score += _balls[i];
					prevFrameSpare = false;
				}

				score += _balls[i];

				if (i > 0)
				{
					prevFrameSpare = (_balls[i] + _balls[i - 1] == 10);
				}
			}

			return score;
		}
	}
}
