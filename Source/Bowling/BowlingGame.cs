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
		private int _bonuses = 0;

		public void Roll(int pins)
		{
			if (_rolls == 20) throw new Exception("Game is finished");
			_rolls++;
			_score += pins;
			applyBonuses(pins);
			checkBonuses(pins);
		}

		public void checkBonuses(int pins)
		{
			if (_previousRollInFrame >= 0)
			{
				if (pins + _previousRollInFrame == 10)
				{
					_bonuses++;
				}

				_previousRollInFrame = -1;
			}
			else
			{
				if (pins == 10)
				{
					_bonuses += 2;
					_rolls++;
				}
				_previousRollInFrame = pins;
			}
		}

		public void applyBonuses(int pins)
		{
			while (_bonuses > 0)
			{
				_score += pins;
				_bonuses--;
			}
		}

		public int Score()
		{
			return _score;
		}
	}
}
