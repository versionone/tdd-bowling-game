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
			
			currentFrame.AddRoll(pins);
			scorableRollCounters.Add(currentFrame.GetScorableRollCounter());
			
			if (currentFrame.IsComplete)
			{
				totalFramesBowled++;
				currentFrame = totalFramesBowled < 9 ? (Frame) new NormalFrame() : new LastFrame();
			}
		}
		
		private interface Frame
		{
			void AddRoll(int pins);
			int GetScorableRollCounter();
			bool IsComplete { get; }
		}

		private class NormalFrame : Frame
		{
			private int totalPins;
			private int numberOfRolls = 0;

			public void AddRoll(int pins)
			{
				totalPins += pins;
				numberOfRolls++;
			}
			
			public int GetScorableRollCounter()
			{
				if (IsStrike)
				{
					return 2;
				}
				if (IsSpare)
				{
					return 1;
				}
				return 0;
			}

			private bool IsSpare
			{
				get { return numberOfRolls == 2 && totalPins == 10; }
			}

			private bool IsStrike
			{
				get { return numberOfRolls == 1 && totalPins == 10; }
			}

			public bool IsComplete
			{
				get { return totalPins == 10 || numberOfRolls == 2; }
			}
		}

		private class LastFrame : Frame
		{
			List<int> rolls = new List<int>();
			public void AddRoll(int pins)
			{
				rolls.Add(pins);
			}

			public int GetScorableRollCounter()
			{
				return 0;
			}

			public bool IsComplete
			{
				get { return rolls.Count == 3 || rolls.Count == 2 && (rolls[0] + rolls[1] < 10); }
			}
		}

		private int totalFramesBowled = 0;
		private List<int> scorableRollCounters = new List<int>();
		private Frame currentFrame = new NormalFrame();

		public int Score { get; private set; }
	}
}