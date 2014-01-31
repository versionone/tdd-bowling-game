using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private int score = 0;

		public int Score
		{
			get { return score; }
		}

		public void Roll(int value)
		{
			score += value;
		}
	}
}
