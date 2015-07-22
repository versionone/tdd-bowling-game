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

		public Game()
		{
			Frames = new List<Frame>();
			Frames.Add(currentFrame);
		}

		public bool Roll(int pins)
		{
			if (currentFrame.IsComplete && Frames.Count == 10 && !currentFrame.IsStrike) return false;

			if (currentFrame.IsSpare)
			{
				currentFrame.Rolls.Add(pins);
			}
			if (currentFrame.IsComplete && Frames.Count < 10)
			{
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
				Frame nextFrame;
				for (var i = 0; i < Frames.Count; i++)
				{
					var atEndOfGame = i == Frames.Count - 1;
					var currentScoreFrame = Frames[i];
					if (!atEndOfGame) nextFrame = Frames[i + 1]; 
					if (currentScoreFrame.IsSpare && !atEndOfGame)
					{
						score += nextFrame.Rolls[0];
					}

					if (currentScoreFrame.IsStrike)
					{
						score += nextFrame.Rolls.Sum();
						if (atEndOfGame && currentScoreFrame.Rolls.Count < 3)
						{
							if (nextFrame.Rolls.Count == 1 && i + 2 < Frames.Count)
							{
								score += Frames[i + 2].Rolls[0];
							}
						}
					}
				}
				return score;
			}
		}
	}
}
