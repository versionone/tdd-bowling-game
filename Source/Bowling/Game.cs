using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private List<Frame> frames = new List<Frame> { new Frame()}; 
		
		public void Roll(int pins)
		{
			if (frames.Last().finished)
			{
				frames.Add(new Frame());
			}

			frames.Last().Roll(pins);

			if (frames.Count == 10)
			{
				CalculateBonuses();
			}


		}

		public void CalculateBonuses()
		{
			for (int i = 0; i < frames.Count; i++)
			{
				if (frames[i].ftype == Frame.FrameType.Spare)
				{
					int toAdd = frames[i + 1]._roll1;
					frames[i]._bonus1 = toAdd;
				}
				else if (frames[i].ftype == Frame.FrameType.Strike)
				{
					if (frames[i + 1].ftype == Frame.FrameType.Strike)
					{
						frames[i]._bonus1 = frames[i + 1]._roll1;
						frames[i]._bonus2 = frames[i + 2]._roll1;
					}
					else
					{
						frames[i]._bonus1 = frames[i + 1]._roll1;
						frames[i]._bonus2 = frames[i + 1]._roll2;
					}
				}

			}

		}

		public int Score()
		{
			return frames.Sum((f) => f.TotalScore());
		}

	}

	public class Frame
	{
		public int _roll1;
		public int _roll2;
		public int _bonus1;
		public int _bonus2;
		public bool finished = false;
		public int roll;
		public FrameType ftype;
		public enum FrameType
		{
			Open,
			Spare,
			Strike
		}


		public void Roll(int pins)
		{

			roll++;
			if (roll == 1)
			{
				_roll1 = pins;
			}
			else
			{
				_roll2 = pins;
			}

			if (pins == 10)
			{
				finished = true;
				ftype=FrameType.Strike;
			}
			if (roll == 2 && (_roll1 + _roll2) != 10)
			{
				finished = true;
				ftype = FrameType.Open;
			}
			else if (roll == 2 && (_roll1 + _roll2) == 10)
			{
				finished = true;
				ftype = FrameType.Spare;
			}
		}

		public int TotalScore()
		{
			return (_roll1 + _roll2) + _bonus1 + _bonus2;
		}
	}

}
