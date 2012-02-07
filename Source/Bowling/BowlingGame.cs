using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private List<BowlingFrame> _frames = new List<BowlingFrame>();

		public void Roll(int pinsKnockedDown)
		{
			BowlingFrame latestFrame = null;
			
			if(_frames.Count > 0)
				latestFrame = _frames.Last();

			if (latestFrame == null || latestFrame.IsComplete())
			{
				latestFrame = new BowlingFrame();
				_frames.Add(latestFrame);
			}

			if (!latestFrame.Roll1.HasValue)
				latestFrame.Roll1 = pinsKnockedDown;
			else
				latestFrame.Roll2 = pinsKnockedDown;
		}

		public int Score()
		{
			var score = 0;

			for (int index = 0; index < _frames.Count; index++)
			{
				BowlingFrame thisFrame = _frames[index];
				BowlingFrame nextFrame = null;
				BowlingFrame followingFrame = null;

				if (index < _frames.Count - 1)
					nextFrame = _frames[index + 1];
				if (index < _frames.Count - 2)
					followingFrame = _frames[index + 2];

				score += thisFrame.CalculateScore(nextFrame, followingFrame);
			}

			return score;
		}
	}
}
