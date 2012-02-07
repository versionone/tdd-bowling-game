using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private List<BowlingFrame> _frames = new List<BowlingFrame>();

		public BowlingGame()
		{
			for(int index = 0; index <= 10; index++)
				_frames.Add(new BowlingFrame());
		}

		public void Roll(int pinsKnockedDown)
		{
			BowlingFrame latestFrame = _frames.First(f => !f.IsComplete());
			latestFrame.ApplyRoll(pinsKnockedDown);
		}

		public int Score()
		{
			var score = 0;

			for (int index = 0; index < _frames.Count; index++)
			{
				BowlingFrame thisFrame = _frames.ElementAt(index);
				BowlingFrame nextFrame = _frames.ElementAtOrDefault(index + 1);
				BowlingFrame followingFrame = _frames.ElementAtOrDefault(index + 2);

				score += thisFrame.CalculateScore(nextFrame, followingFrame);
			}

			return score;
		}
	}
}
