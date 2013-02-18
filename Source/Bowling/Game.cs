using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private int _score;

		public void Roll(int number)
		{
			_score += number;
		}

		public int Score()
		{
			return _score;
		}
	}
}
