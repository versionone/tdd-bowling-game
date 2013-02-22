using System.Collections.Generic;

namespace Bowling
{
	public class Frame
	{
		public int FirstRoll;
		public int SecondRoll;
	}

	public class BowlingEngine : IBowlingEngine
	{
		List<Frame> _frames = new List<Frame>();

		public int Score()
		{
			int total = 0;
			Frame previousFrame = null;
			foreach (var frame in _frames)
			{
				//Spare Logic
				if (previousFrame != null && previousFrame.FirstRoll + previousFrame.SecondRoll == 10)
				{
					total += frame.FirstRoll;
				}
				total += frame.FirstRoll + frame.SecondRoll;
				previousFrame = frame;
			}
			return total;
		}
		 
		public int AddFrame(int firstRoll, int secondRoll)
		{
			_frames.Add(new Frame {FirstRoll = firstRoll, SecondRoll = secondRoll});
			return Score();
		}
	}
}