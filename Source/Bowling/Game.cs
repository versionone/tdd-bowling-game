using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using NUnit.Framework;
using System.Linq;

namespace Bowling
{
	public class Frame
	{
		private readonly int FirstRoll;
		private int? SecondRoll;
		private int? ThirdRoll;

		public Frame(int firstRoll)
		{
			FirstRoll = firstRoll;
		}

		public bool IsSpare
		{
			get { return SecondRoll.HasValue && (FirstRoll + SecondRoll == 10); }
		}

		public bool IsStrike
		{
			get { return FirstRoll == 10; }
		}

		public bool Completed
		{
			get { return IsStrike || SecondRoll.HasValue; }
		}

		public int Score
		{
			get { return FirstRoll + SecondRoll ?? 0 + ThirdRoll ?? 0; }
		}

		public bool NeedAnotherRoll
		{
			get
			{
				return (IsStrike && !(SecondRoll.HasValue && ThirdRoll.HasValue))
						|| (IsSpare && !ThirdRoll.HasValue)
						|| !SecondRoll.HasValue;
			}
		}

		public void Roll(int roll)
		{
			if (SecondRoll.HasValue)
				ThirdRoll = roll;
			else
				SecondRoll = roll;
		}
	}

	public class Game
	{
		private readonly List<int> _rolls = new List<int>();

		private int CalculateScore(List<int> rolls)
		{
			var frames = new List<Frame>();
			Frame currentFrame = null;
			foreach(var roll in rolls)
			{
				if (currentFrame == null)
				{
					currentFrame = new Frame(roll);
				}
				else if (currentFrame.Completed)
				{
					frames.Add(currentFrame);
					currentFrame = new Frame(roll);
				}
				else if (currentFrame.NeedAnotherRoll)
					currentFrame.Roll(roll);

				if (frames.Any())
				{
					var lastFrame = frames.Last();
					if (lastFrame.NeedAnotherRoll)
					{
						lastFrame.Roll(roll);
					}
				}
			}

			return frames.Sum(frame => frame.Score);

/*
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
*/
		}

		public int Score
		{
			get { return CalculateScore(_rolls); }
		}

		public void Roll(int pins)
		{
			if(_rolls.Count == 20)
			{
				throw new InvalidOperationException("Game Over");
			}
			_rolls.Add(pins);
		}
	}
}