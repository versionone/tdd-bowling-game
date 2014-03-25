using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class Frame
	{
		public List<int> rolls = new List<int>();


		public int RequiredRolls
		{
			get
			{
				if (IsStrike() || IsSpare())
				{
					return 3;
				}
				else
				{
					return 2;
				}
			}
		}

		public bool IsStrike()
		{
			return rolls.Count == 1 && rolls.Sum() == 10;
		}

		public bool IsSpare()
		{
			return rolls.Count == 2 && rolls.Sum() == 10;
		}

		public bool IsOpen()
		{
			return rolls.Count < 2 && !IsStrike();
		}

		public void AddRoll(int roll)
		{
			rolls.Add(roll);
		}
	}

	public class BowlingGame
	{
		private readonly List<Frame> _frames = new List<Frame>(); 
		private Frame _bonus = new Frame();

		public void Roll(int pins)
		{
			if (IsGameFinished()) throw new Exception("Game is finished");

			CurrentFrame().AddRoll(pins);
		}

		public Frame CurrentFrame()
		{
			var firstOpen = _frames.FirstOrDefault(frame => frame.IsOpen());
			if (firstOpen != null)
				return firstOpen;

			if (_frames.Count == 10)
				return _bonus;

			Frame newFrame = new Frame();
			_frames.Add(newFrame);

			return newFrame;
		}

		public int RequiredRolls
		{
			get { return _frames.Select(frame => frame.RequiredRolls).Sum(); }
		}

		public int PerformedRolls
		{
			get { return _frames.SelectMany(frame => frame.rolls).Concat(_bonus.rolls).Count(); }
		}

		public bool IsGameFinished()
		{
			if (_frames.Count < 10)
				return false;

			var last = _frames.Last();

			return last.rolls.Concat(_bonus.rolls).Count() == last.RequiredRolls;
		}

		public IEnumerable<int> getRolls(int frameIndex, int rolls)
		{
			return _frames.Skip(frameIndex).SelectMany(frame => frame.rolls).Concat(_bonus.rolls).Take(rolls);
		}

		public int Score()
		{
			return _frames.SelectMany(frame => getRolls(_frames.IndexOf(frame), frame.RequiredRolls)).Sum();
		}
	}
}
