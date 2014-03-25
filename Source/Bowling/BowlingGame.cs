using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private int _rolls = 0;
		private int _score = 0;
		private int _previousRollInFrame = -1;
		private bool _spare = false;

		public void Roll(int pins)
		{
			if (_rolls == 20) throw new Exception("Game is finished");
			_rolls++;
			_score += pins;
			applySpare(pins);
			checkSpare(pins);
		}

		public void checkSpare(int pins)
		{
			if (_previousRollInFrame >= 0)
			{
				if (pins + _previousRollInFrame == 10)
				{
					_spare = true;
				}

				_previousRollInFrame = -1;
			}
			else
			{
				_previousRollInFrame = pins;
			}
		}

		public void applySpare(int pins)
		{
			if (_spare)
			{
				_score += pins;
				_spare = false;
			}
		}

		public int Score()
		{
			return _score;
		}
	}
}
