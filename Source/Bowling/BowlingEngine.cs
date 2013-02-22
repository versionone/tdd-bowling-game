using System.Collections.Generic;

namespace Bowling
{
	public class BowlingEngine : IBowlingEngine
	{
		readonly List<Frame> _frames = new List<Frame>();

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
			if (_frames.Count == 10) throw new TooManyFramesException();
			_frames.Add(new Frame {FirstRoll = firstRoll, SecondRoll = secondRoll});
			return Score();
		}
	}
}