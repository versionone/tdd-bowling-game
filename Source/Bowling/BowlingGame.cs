using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private int _score;

		public void Roll(int pinsKnockedDown)
		{
			_score += pinsKnockedDown;
		}

		public int Score()
		{
			return _score;
		}
	}
}
