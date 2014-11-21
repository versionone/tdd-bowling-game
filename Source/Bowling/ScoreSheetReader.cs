using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Bowling
{
	public class Frame
	{			
		public int FirstRoll { get; set; }
		public int SecondRoll { get; set; }

		public enum FrameType
		{
			Spare,
			Strike,
			Normal
		}

		public FrameType GetFrameType()
		{
			var type = FrameType.Normal;
			if (this.FirstRoll == 10)
			{
				type = FrameType.Strike;
			}
			else if (this.FirstRoll + this.SecondRoll == 10)
			{
				type = FrameType.Spare;
			}
			return type;
		}

	}

	public class TooManyFramesException : Exception
	{

	}

	public class ScoreSheet
	{
		public List<Frame> Frames { get; set; }

		public ScoreSheet()
		{
			Frames = new List<Frame>();
		}

		public void AddFrame(Frame frame)
		{
			Frames.Add(frame);
		}

		public int CalculateScore()
		{
			int result = 0;
			/*foreach (var frame in Frames)
			{
				result += CalculateScore(frame);
			}*/

			for (var i = 0; i < Frames.Count; i++)
			{
				var type = Frames[i].GetFrameType();
				switch (type)
				{
					case Frame.FrameType.Normal:
						result += CalculateScore(Frames[i]);
						break;
					case Frame.FrameType.Spare:
						//TODO what happens if spare is in last frame?
						result += (CalculateScore(Frames[i]) + Frames[i + 1].FirstRoll);
						break;
				}

			}

			return result;
		}

		public int CalculateScore(Frame frame)
		{
			return frame.FirstRoll + frame.SecondRoll;
		}
	}
}
