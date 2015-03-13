using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Specs
{
	class BowlingGame
	{
		private int _totalPins;

		internal void Roll(int pins)
		{
			_totalPins += pins;
		}

		internal int GetScore()
		{
			return _totalPins;
		}
	}
}
