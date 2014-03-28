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

		public void Roll(int pins)
		{
			if (_isSecondRoll)
			{
				if (_previousScore + pins == 10)
				{
					_spare = true;
				}

				_isSecondRoll = false;
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
