using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Bowling
{
	public class Frame
	{
		public Frame(int pins)
		{
			First = pins;
		}

		public int First { get; private set; }
		public int? Second { get; set; }

		public bool IsSpare => Second.HasValue && First + Second == 10;
		public bool IsStrike => First == 10;
		public virtual bool IsComplete => Second.HasValue || IsStrike;

		public virtual int Score(List<Frame> frames, int myIndex)
		{
			if (IsStrike)
			{
				return 10 + frames[myIndex+1].First + (frames[myIndex + 1].Second.HasValue ? frames[myIndex + 1].Second.Value : frames[myIndex + 2].First);
			}
			else if (IsSpare)
			{
				return 10 + frames[myIndex + 1].First;
			}
			else
			{
				return First + Second.GetValueOrDefault();
			}
		}

		public virtual void Roll(int pins)
		{
			Second = pins;
		}
	}

	public class LastFrame : Frame
	{
		public LastFrame(int pins) : base(pins)
		{

		}

		public int? Third { get; set; }
		public override bool IsComplete => Third.HasValue || !(IsSpare || IsStrike) && Second.HasValue;

		public override void Roll(int pins)
		{
			if (Second.HasValue)
				Third = pins;
			else
			{
				base.Roll(pins);
			}
		}

		public override int Score(List<Frame> frames, int myIndex)
		{
			return First + Second.Value + Third.GetValueOrDefault();
		}

	}

	public class Bowl
	{
		private List<Frame> frames = new List<Frame>();

		public int Frame { get; set; }

		public int Score
		{
			get
			{

				int score = 0;
				for (int i = 0; i < frames.Count; i++)
				{
					score += frames[i].Score(frames, i);
				}
				return score;
			}
		}

		public void Roll(int pins = 0)
		{
			if (frames.Count == 0 || frames.Last().IsComplete)
			{
				frames.Add(frames.Count == 9 ? new LastFrame(pins) : new Frame(pins));
			}
			else
			{
				frames.Last().Roll(pins);
			}
		}

		public void PlayGame(int pins = 0)
		{
			for (var i = 0; i < 20; i++)
				Roll(pins);

		}

		public void PlayGame(List<int> pins)
		{
			foreach (var i in pins)
			{
				Roll(i);
			}
		}

	}
}
