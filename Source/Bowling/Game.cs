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


		}

		public int Score()
		{
			return frames.Sum((f) => f.TotalScore());
		}

	}

	public class Frame
	{
		public int _baseScore;
		public int _bonus1;
		public int _bonus2;
		public bool finished = false;
		public int roll;
		private FrameType ftype;
		public enum FrameType
		{
			Open,
			Spare,
			Strike
		}


		public void Roll(int pins)
		{
			_baseScore += pins;
			roll++;
			if (pins == 10)
			{
				finished = true;
				ftype=FrameType.Strike;
			}
			if (roll == 2 && _baseScore != 10)
			{
				finished = true;
				ftype = FrameType.Open;
			}
			else if (roll == 2 && _baseScore == 10)
			{
				finished = true;
				ftype = FrameType.Spare;
			}
		}

		public int TotalScore()
		{
			return _baseScore + _bonus1 + _bonus2;
		}
	}

}
