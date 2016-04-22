using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{

		private int score = 0;

		public int GetScore()
		{
			return score;
		}

		public void rolls(int numberOfRolls, int numberOfPins)
		{
			score = numberOfRolls * numberOfPins;
		}
	}
}
