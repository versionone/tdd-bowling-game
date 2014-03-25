using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private List<int> rolls = new List<int>();
		private List<int> frames = new List<int>();

		public void Roll(int pinsKnockedDown)
		{
			rolls.Add(pinsKnockedDown);
		}

		public List<int> Frames
		{
			get { return frames; }
		}

		public int CalculateScore()
		{
			for (int i = 0; i < rolls.Count -1; i = i + 2)
			{
				int firstRoll = rolls[i];
				int secondRoll = rolls[i + 1];

				if (IsSpare(firstRoll, secondRoll))
				{
					frames.Add(firstRoll + secondRoll + rolls[i + 2]);
				}
				else
				{
					frames.Add(firstRoll + secondRoll);	
				}
			}
			return frames.Sum();
		}

		public bool IsSpare(int first, int second)
		{
			return (first + second == 10);
		}

		public int Score { get { return CalculateScore(); } }
	}
}
