using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private int _score;

		public void Roll(int pins)
		{
			_score += pins;
		}

		public int Score
		{
			get { return _score; }
		}
	}
}
