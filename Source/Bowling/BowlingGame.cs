using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		public int Score { get ; set; }

		public int  RollCount { get; set; }
		public int lastPins { get; set; }
		public List<Frame> gameFrames { get; set; }

		public bool IsComplete
		{
			get { 
				var frameCount = this.gameFrames.Count() == 10;
				var frameAllClosed = this.gameFrames.All(f => f.IsClosed);

				return frameCount && frameAllClosed;
			}
		}

		public BowlingGame()
		{
			gameFrames = new List<Frame> { new Frame() };

		}

		public void Roll(int pins)
		{
			
			if (gameFrames.Last().IsSpare)
			{
				Score += pins;
			}
			if (gameFrames.Last().IsClosed)
			{
				gameFrames.Add(new Frame());
			}

			gameFrames.Last().Turn++;
			Score += gameFrames.Last().Roll(pins);
		}
	}
}

