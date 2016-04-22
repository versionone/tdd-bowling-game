using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{

		private List<int> scores = new List<int>();

		public int GetScore()
		{
			int theScore  = 0;
			for (int i = 0; i < scores.Count; i++)
			{
				theScore += scores[i];
			}
			return theScore;
		}

		public void roll(int numberOfPins)
		{
			scores.Add(numberOfPins);
		}
	}
}
