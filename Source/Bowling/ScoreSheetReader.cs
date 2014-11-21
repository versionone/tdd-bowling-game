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
			foreach (var frame in Frames)
			{
				result += CalculateScore(frame);
			}
			return result;
		}

		public int CalculateScore(Frame frame)
		{
			return frame.FirstRoll + frame.SecondRoll;
		}
	}
}
