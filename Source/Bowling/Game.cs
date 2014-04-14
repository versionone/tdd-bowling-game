
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class Game
	{
		private int _score = 0;
		List<int> Rolls = new List<int>();

		public Game()
		{
		}

		public void Roll(int pins)
		{
			if (CountCompletedFrames() == 10)
				throw new Exception();

			Rolls.Add(pins);

		}

		private bool firstRollsAreBonus(List<int> rolls)
		{
			return rolls.Take(1).Sum() == 10 || rolls.Take(2).Sum() == 10;
		}

		private bool onLastFrame()
		{
			return (Rolls.Count == (20 - CountStrikes()));
		}
		public int CountStrikes()
		{
			return Rolls.Count(x => x == 10);
		}

		public int CountCompletedFrames()
		{
			return CountCompletedFrames(Rolls);
		}

		public int CountCompletedFrames(List<int> rolls)
		{
			if (rolls.Count < 2)
				return 0;

			//Strike
			if (rolls[0] == 10 && rolls.Count >= 3)
			{
				return 1 + CountCompletedFrames(rolls.Skip(1).ToList());
			}

			//Spare
			if (firstRollsAreBonus(rolls) && rolls.Count >= 3)
			{
				return 1 + CountCompletedFrames(rolls.Skip(2).ToList());
			}

			if (!firstRollsAreBonus(rolls))
				return 1 + CountCompletedFrames(rolls.Skip(2).ToList());

			return 0;
		}

		public int CalculateScore()
		{
			if (CountCompletedFrames() < 10)
				return 0;
			return CalculateScore(Rolls);
		}

		public int CalculateScore(List<int> rolls)
		{
			if (rolls.Count == 0)
				return 0;

			//Strike
			if (rolls[0] == 10 )
			{
				return rolls.Take(3).Sum() + CalculateScore(rolls.Skip(1).ToList());
			}

			//Spare
			if (firstRollsAreBonus(rolls))
			{
				return rolls.Take(3).Sum() + CalculateScore(rolls.Skip(2).ToList());
			}

			if (!firstRollsAreBonus(rolls))
				return rolls.Take(2).Sum() + CalculateScore(rolls.Skip(2).ToList());

			return 0;
		}
		public int Score
		{

			get { return CalculateScore(); }
		}
	}
}
