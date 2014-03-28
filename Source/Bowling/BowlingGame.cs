using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private int _score = 0;
		private bool _isSecondRoll = false;
		private int _previousScore = 0;
		private bool _spare = false;
		private int _frameCounter = 0;

		public void Roll(int pins)
		{
			if (_frameCounter == 10)
			{
				throw new Exception("More than 10 frames");
			}
			if (_isSecondRoll)
			{
				if (_previousScore + pins == 10)
				{
					_spare = true;
				}

				_isSecondRoll = false;
				_frameCounter++;
			}
			else
			{
				if (_spare)
				{
					_score += pins;
					_spare = false;
				}

				_isSecondRoll = true;
			}

			_score += pins;

			_previousScore = pins;
		}

		public int Score()
		{
			return _score;
		}
	}
}
