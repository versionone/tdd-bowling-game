using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private int _score;

		private int _roll_count = 0;

		private int[] _rolls = new int[21];

		public void Roll(int number)
		{
			_roll_count ++;
			_score += number;
			_rolls[_roll_count] = number;

			if ((_roll_count > 2) && 
				(_rolls[_roll_count - 1] + _rolls[_roll_count - 2] == 10) &&
				(_roll_count % 2 == 1))
			{
				_score += number;
			}
		}

		public int Score()
		{
			return _score;
		}
	}
}
