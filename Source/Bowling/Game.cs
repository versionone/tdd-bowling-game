using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		public List<Frame> Frames { get; set; }
		private Frame currentFrame = new Frame();
		private Frame previousFrame { get; set; }

		public Game()
		{
			Frames = new List<Frame>();
			Frames.Add(currentFrame);
		}

		public bool Roll(int pins)
		{
			if (currentFrame.IsComplete && Frames.Count == 10) return false;

			if (previousFrame != null && currentFrame.IsComplete && previousFrame.IsStrike)
			{
				previousFrame.Rolls.AddRange(currentFrame.Rolls);
			}

			if (currentFrame.IsSpare)
			{
				currentFrame.Rolls.Add(pins);
			}
			if (currentFrame.IsComplete)
			{
				previousFrame = Frames.Last();
				currentFrame = new Frame();
				Frames.Add(currentFrame);
			}
			currentFrame.Rolls.Add(pins);
			Debug.WriteLine(string.Format("Frame {0}/{1}: {2}", Frames.Count, currentFrame.Rolls.Count, Score));
			return true;
		}

		public int Score
		{
			get
			{
				return Frames.Sum(f => f.Rolls.Sum());
			}
		}
	}
}
