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
			if (frames.Count == 0 || frames.Last().IsComplete())
			{
				frames.Add(new Frame());
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
		public int? First { get; set; }
		public int? Second { get; set; }

		public bool IsComplete()
		{
			bool isComplete = First.HasValue && Second.HasValue;

			return isComplete;
		}

		public int GetScore()
		{
			return First.Value + Second.Value;
		}
	}
}
