using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		public List<Frame> Frames { get; set; }
		private Frame currentFrame = new Frame();

		public Game()
		{
			Frames = new List<Frame>();
			Frames.Add(currentFrame);
		}

		public void Roll(int pins)
		{
			if (currentFrame.IsSpare)
			{
				currentFrame.Rolls.Add(pins);
			}
			if (currentFrame.IsComplete)
			{
				currentFrame = new Frame();
				Frames.Add(currentFrame);
			}
			currentFrame.Rolls.Add(pins);
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
