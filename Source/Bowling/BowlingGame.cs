using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Bowling
{
	public class BowlingGame
	{
		private int TotalFrames;
		private int TotalFrameRolls;
		private List<int> RollMultipliers;
		private int LastRoll;

		public BowlingGame()
		{
			RollMultipliers = new List<int>() {1, 1};
		}

		public void Roll(int pins)
		{
			Score += pins* RollMultipliers.First();
			RollMultipliers.RemoveAt(0);
			RollMultipliers.Add(1);

			if (TotalFrames < 9)
			{
				if (TotalFrameRolls == 0 && pins == 10)
				{
					RollMultipliers[0] += 1;
					RollMultipliers[1] += 1;
				}
				else if (TotalFrameRolls == 1 && LastRoll + pins == 10)
				{
					RollMultipliers[0] += 1;
				}
			}

			if (TotalFrameRolls == 1)
			{
				TotalFrameRolls = 0;
				TotalFrames++;
			}
			else if (pins == 10)
			{
				TotalFrames++;
			}
			else
			{
				TotalFrameRolls++;
			}

			LastRoll = pins;
		}

		public int Score { get; private set; }

		public bool CanRoll
		{
			get { return TotalFrames < 10; }
		}
	}
}