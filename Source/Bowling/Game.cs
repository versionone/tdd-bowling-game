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
				var score = Frames.Sum(f => f.Rolls.Sum());
				for (var i = 0; i < Frames.Count; i++)
				{
					if (Frames[i].IsSpare && i+1 < Frames.Count)
					{
						score += Frames[i + 1].Rolls[0];
					}

					if (Frames[i].IsStrike && i+1 < Frames.Count)
					{
						score += Frames[i + 1].Rolls.Sum();
						if (Frames[i + 1].Rolls.Count == 1 && i + 2 < Frames.Count)
						{
							score += Frames[i + 2].Rolls[0];
						}
					}
				}
				return score;
			}
		}
	}
}
