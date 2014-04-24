using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		public List<int>Rolls { get; set; } 
		public int Score {
			get { return Rolls.Sum(); }
		}

		public BowlingGame()
		{
			Rolls = new List<int>();
		}

		public void Roll(int pins)
		{
			if (Rolls.Count == 2 && Rolls[0] + Rolls[1] == 10)
			{
				Rolls.Add(pins*2);
			}
			else
			{

				Rolls.Add(pins);
			}
		}
	}
}
