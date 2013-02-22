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
			Frame previousPreviousFrame = null;

			foreach (var frame in _frames)
			{
				if (previousPreviousFrame != null && 
					previousPreviousFrame.Status == FrameStatus.Strike && 
					previousFrame.Status == FrameStatus.Strike)
				{
					total += frame.FirstRoll;
				}

				if (previousFrame != null)
				{
					if (previousFrame.Status == FrameStatus.Strike)
					{
						if (frame.Status == FrameStatus.Strike)
						{
							total += frame.FirstRoll;
						}
						else
						{
							total += frame.FirstRoll + frame.SecondRoll;
						}
					} 
					else if (previousFrame.Status == FrameStatus.Spare)
					{
						total += frame.FirstRoll;
					}
				}

				total += frame.FirstRoll + frame.SecondRoll;

				previousPreviousFrame = previousFrame;
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