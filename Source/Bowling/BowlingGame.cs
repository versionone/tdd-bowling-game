using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private int _score = 0;

		public void Roll(int pins)
		{
			_score += pins;
		}

		public int Score()
		{
			return _score;
		}
	}
}
