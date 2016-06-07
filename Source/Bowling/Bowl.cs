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
		public bool IsComplete => Second.HasValue || IsStrike;
	
	}

	public class Bowl
	{
		private List<Frame> frames = new List<Frame>();

		public int Frame { get; set; }

		public int Score {
			get
			{
				int score = 0;
				bool isSpare = false;
				bool isStrike = false;
				foreach (var f in frames)
				{
					if (isSpare || isStrike)
						score += f.First;
					if (isStrike)
						score += f.Second.GetValueOrDefault();
					score += f.First;
					score += f.Second.GetValueOrDefault();
					isSpare = f.IsSpare;
					isStrike = f.IsStrike;
				}
				return score;
			}
		}

		public void Roll(int pins = 0)
		{
			if (frames.Count == 0 || frames.Last().IsComplete)
			{
				frames.Add(new Frame(pins));
			}
			else
			{
				frames.Last().Second = pins;
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
