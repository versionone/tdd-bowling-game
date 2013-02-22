using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class BowlingEngine : IBowlingEngine
	{
		readonly List<Frame> _frames = new List<Frame>();

		public int Score()
		{
			int total = 0;

			Frame previousFrame = new Frame();
			Frame previousPreviousFrame = new Frame();

			foreach (var frame in _frames)
			{
				if (previousPreviousFrame.Status == FrameStatus.Strike &&
					previousFrame.Status == FrameStatus.Strike)
				{
					total += frame.FirstRoll;
				}

				if (previousFrame.Status == FrameStatus.Strike)
				{
					total += frame.FrameTotal();
				}
				else if (previousFrame.Status == FrameStatus.Spare)
				{
					total += frame.FirstRoll;
				}

				total += frame.FrameTotal();

				previousPreviousFrame = previousFrame;
				previousFrame = frame;
			}
			return total;
		}

		public void AddRoll(int roll)
		{
			Frame lastFrame = _frames.LastOrDefault();

			if (lastFrame != null && (lastFrame.Status == FrameStatus.Open || _frames.Count == 10))
			{
				lastFrame.Add(roll);
			}
			else
			{
				var frame = new Frame();
				frame.Add(roll);
				_frames.Add(frame);
			}


		}

		public void AddFrame(int firstRoll, int secondRoll)
		{
			if (_frames.Count == 10) throw new TooManyFramesException();
			_frames.Add(new Frame(firstRoll, secondRoll));
		}
	}
}