using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Bowling
{
	public class BowlingGame
	{
		public void Roll(int pins)
		{
			if (totalFramesBowled >= 10)
			{
				throw new InvalidOperationException("Game over! Max number of frames already bowled.");
			}
			Score += pins;

			scorableRollCounters = scorableRollCounters
				.Where(value => value > 0)
				.Select(value =>
				{
					Score += pins;
					return value - 1;
				})
				.ToList();
			
			currentFrame.addRoll(pins);
			scorableRollCounters.Add(currentFrame.getScorableRollCounter());
			
			if (currentFrame.isComplete())
			{
				totalFramesBowled++;
				if (totalFramesBowled < 9)
				{
					currentFrame = new NormalFrame();
				}
				else
				{
					currentFrame = new LastFrame();
				}
			}
		}
		
		private interface Frame
		{
			void addRoll(int pins);
			int getScorableRollCounter();
			bool isComplete();
		}

		private class NormalFrame : Frame
		{
			private int totalPins;
			private int numberOfRolls = 0;

			public void addRoll(int pins)
			{
				totalPins += pins;
				numberOfRolls++;
			}
			
			public int getScorableRollCounter()
			{
				if (numberOfRolls == 1 && totalPins == 10)
				{
					return 2;
				}
				else if (numberOfRolls == 2 && totalPins == 10)
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}

			public bool isComplete()
			{
				return totalPins == 10 || numberOfRolls == 2;
			}
		}

		private class LastFrame : Frame
		{
			List<int> rolls = new List<int>();
			public void addRoll(int pins)
			{
				rolls.Add(pins);
			}

			public int getScorableRollCounter()
			{
				return 0;
			}

			public bool isComplete()
			{
				if (rolls.Count == 3)
				{
					return true;
				}
				return rolls.Count == 2 && (rolls[0] + rolls[1] < 10);
			}
		}

		private int totalFramesBowled = 0;
		private List<int> scorableRollCounters = new List<int>();
		private Frame currentFrame = new NormalFrame();

		public int Score { get; private set; }
	}
}