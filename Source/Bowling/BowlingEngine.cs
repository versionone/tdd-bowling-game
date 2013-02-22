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

			foreach (var frame in _frames)
			{
				total += frame.FrameTotal();
			}
			return total;
		}

		public void AddRoll(int roll)
		{
			var lastFrame = _frames.LastOrDefault();

			var wasClosed = false;
			if (lastFrame != null)
			{
				wasClosed = lastFrame.Closed;
			}

			foreach (Frame frame in _frames.Where(f => !f.Closed))
			{
				frame.Add(roll);
			}

			if ((lastFrame != null && lastFrame.Closed != wasClosed)|| lastFrame == null)
			{
				var newFrame = new Frame();
				newFrame.Add(roll);
				_frames.Add(newFrame);
			}
		}
	}
}