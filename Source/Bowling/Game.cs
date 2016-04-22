using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{

		private List<Frame> frames = new List<Frame>();

		public int GetScore()
		{
			int theScore  = 0;
			for (int i = 0; i < frames.Count; i++)
			{
				theScore += frames[i].GetScore();
			}
			return theScore;
		}

		public void roll(int numberOfPins)
		{
			if (frames.Count == 0)
			{
				frames.Add(new Frame());
			}
			else if (frames.Last().IsComplete())
			{
				frames.Last().NextFrame = new Frame();
				frames.Add(frames.Last().NextFrame);
			}
			Frame f = frames.Last();

			if (f.First.HasValue)
			{
				f.Second = numberOfPins;
			}
			else
			{
				f.First = numberOfPins;
			}

		}
	}

	internal class Frame
	{
		public Frame NextFrame { get; set; }
		public int? First { get; set; }
		public int? Second { get; set; }

		public bool IsComplete()
		{
			bool isComplete = First.HasValue && Second.HasValue;

			return isComplete;
		}

		public int GetScore()
		{
			int myScore = First.Value + Second.Value;
			if (myScore == 10)
			{
				return myScore + NextFrame.First.Value;
			}
			return myScore;
		}
	}
}
