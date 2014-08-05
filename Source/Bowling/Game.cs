using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using NUnit.Framework;

namespace Bowling
{
	public class Game
	{
		private readonly List<int> _rolls = new List<int>();

		private int CalculateScore(List<int> rolls)
		{
			var score = 0;
			var odd = true;
			var firstRollInFrame = 0;
			var isSpare = false;
			foreach (var roll in rolls)
			{
				score += roll;
				if (isSpare)
				{
					score += roll;
					isSpare = false;
				}
				
				if (odd)
				{
					odd = false;
					firstRollInFrame = roll;
					continue;
				}

				if(firstRollInFrame + roll == 10)
				{
					isSpare = true;
				}

				odd = true;
			}

			return score;
		}

		public int Score
		{
			get { return CalculateScore(_rolls); }
		}

		public void Roll(int pins)
		{
			_rolls.Add(pins);
		}
	}
}