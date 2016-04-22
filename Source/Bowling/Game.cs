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
				if (frames.Count >= 10 )
				{
					throw new Exception();
				}
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

	internal class SpecialFrame : Frame
	{
		public int? Third { get; set; }

		public override bool IsComplete()
		{
			if (isSpare())
			{
				if (Third.HasValue)
				{
					return true;
				}		
			}

			if (isStrike())
			{
				
			}
		}
	}

	internal class Frame
	{
		public Frame NextFrame { get; set; }
		public int? First { get; set; }
		public int? Second { get; set; }

		public virtual bool IsComplete()
		{
			bool isComplete = isStrike() || First.HasValue && Second.HasValue;

			return isComplete;
		}

		public int GetScore()
		{
			int myScore = First.GetValueOrDefault() + Second.GetValueOrDefault();
			if (isSpare())
			{
				return myScore + NextFrame.First.Value;
			}

			if (isStrike())
			{
				if (NextFrame.isStrike())
				{
					return myScore + NextFrame.First.Value + NextFrame.NextFrame.First.Value;
				}
				else
				{
					return myScore + NextFrame.First.Value + NextFrame.Second.Value;
				}
			}

			return myScore;
		}

		public bool isSpare()
		{
			return Second.HasValue && First.Value + Second.Value == 10;
		}

		public bool isStrike()
		{
			return First.Value == 10;
		}
	}
}
