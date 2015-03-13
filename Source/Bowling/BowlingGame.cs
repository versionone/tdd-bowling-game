using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Bowling
{
	public class BowlingGame
	{
		private int _currentFrame;
		private int _rolls;

		private IList<int> _frameScores = new List<int>() ;

		public void Roll(int pins)
		{
			if (_currentFrame == 10)
			{
				throw new ApplicationException("game over");
			}

			_rolls += 1;
			var isFirstRoll= _rolls%2 != 0;

			if (isFirstRoll)
			{
				_frameScores.Add(pins);
				if (_currentFrame != 0)
				{
					var previousFrame = _frameScores[_currentFrame - 1];
					if (previousFrame == 10)
					{
						_frameScores[_currentFrame - 1] += pins;
					}
				}
			}
			else
			{
				_frameScores[_currentFrame] += pins;
				_currentFrame++;
			}
		}

		public int GetScore()
		{
			return _frameScores.Sum();
		}
	}
}
