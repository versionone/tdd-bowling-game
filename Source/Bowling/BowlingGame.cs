using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class BowlingGame
	{
		private IList<Frame> frames = new List<Frame>();
		public void Roll(int pins)
		{
			GetCurrentFrame().AddRoll(pins);
		}

		private Frame GetCurrentFrame()
		{
			var frame = frames.LastOrDefault();
			
			if (frame== null || frame.IsComplete)
			{
				frame = new Frame();
				frames.Add(frame);
			}
			return frame;
		}


		public int CalculateScore()
		{
			var score = 0;
			Frame lastFrame = new Frame();
			Frame penultimateFrame = new Frame();
			foreach (var frame in frames)
			{
				score += frame.Pins;
				if (lastFrame.IsSpare)
				{
					score += frame.FirstRoll;
				}
				if (lastFrame.IsStrike)
				{
					score += frame.Pins;
					if (!frame.IsStrike && penultimateFrame.IsStrike)
					{
						score += lastFrame.Pins;
					}
				}

				penultimateFrame = lastFrame; 
				lastFrame = frame;

			}
			return score;
		}
	}

	internal class Frame
	{
		private List<int> rolls = new List<int>();
		public void AddRoll(int pins)
		{

			rolls.Add(pins);
		}

		public int FirstRoll {
			get { return rolls[0]; }
		}

		public int Pins {
			get { return rolls.Sum(); }
		}

		public bool IsSpare
		{
			get { return Pins == 10 && rolls.Count == 2; }
		}
		public bool IsStrike
		{
			get { return Pins == 10 && rolls.Count == 1; }
		}

		public bool IsComplete
		{
			get { return Pins == 10 || rolls.Count == 2; }
		}
	}
}