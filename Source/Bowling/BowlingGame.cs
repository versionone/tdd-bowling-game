using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private int _score = 0;

		public void Roll(int knockedDownPins)
		{
			_score += knockedDownPins;
		}

		public int Score { get { return _score; } }
	}
}
