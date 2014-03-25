using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		public class GameOverException : Exception
		{
			public GameOverException(string message) : base(message)
			{
			}
		}

		private List<int> rolls = new List<int>();
		private List<int> frames = new List<int>();

		public void Roll(int pinsKnockedDown)
		{
			rolls.Add(pinsKnockedDown);
			if (pinsKnockedDown == 10) //stuffing the frame with a zero so we don't have to mess with the offset
			{
				rolls.Add(0);
			}
			CalculateScore();
		}

		public List<int> Frames
		{
			get { return frames; }
		}

		public void CalculateScore()
		{
			frames.Clear();
			for (int i = 0; i < (rolls.Count - 1); i = i + 2)
			{
				int firstRoll = rolls[i];
				int secondRoll = rolls[i + 1];

				if (IsStrike(firstRoll))
				{
					AddStrikeAndBonusToScore(i);
				}
				else if (IsSpare(firstRoll, secondRoll) && (i + 2 < rolls.Count))
				{
					frames.Add(firstRoll + secondRoll + rolls[i + 2]);
				}
				else
				{
					frames.Add(firstRoll + secondRoll);
				}
			}
			if (frames.Count > 10 || (frames.Count == 10 && rolls.Count == 21))
			{
				throw new GameOverException("The game is over!");
			}
			Score = frames.Sum();
		}

		private void AddStrikeAndBonusToScore(int i)
		{
			if (RollExistsAt(i,2) && IsStrike(rolls[i + 2]))
			{
				if (RollExistsAt(i,4)) frames.Add(rolls[i] + rolls[i + 2] + rolls[i + 4]);
			}
			else if (RollExistsAt(i,3))
			{
				frames.Add(rolls[i] + rolls[i + 2] + rolls[i + 3]);
			}
		}

		private bool RollExistsAt(int index, int offset)
		{
			return index + offset < rolls.Count;
		}

		public bool IsSpare(int first, int second)
		{
			return (first + second == 10) && !IsStrike(first);
		}

		public bool IsStrike(int first)
		{
			return first == 10;
		}
		public int Score { get; private set; } 
	}
}
