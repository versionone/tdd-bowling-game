using System.Collections.Generic;
using System.Linq;
using Bowling;

namespace specs_for_bowling
{
	public class Game
	{
		private readonly List<Frame> _frames = new List<Frame>();

		public Game()
		{
			_frames.Add(new Frame());
		}

		public void Roll(int pins)
		{
			Frame frame = _frames.Last();
			if (frame.IsFrameComplete())
			{
				frame = new Frame();
				_frames.Add(frame);
			}

			frame.AddPins(pins);
		}

		public int Score()
		{
			int score = 0;

			for (int index = 0; index < _frames.Count; index++)
			{
				var frame = _frames[index];
				if (frame.IsStrike())
				{
					score += frame.FirstRoll.Value;
					Frame nextFrame = _frames[index + 1];
					if (nextFrame.IsStrike())
					{
						Frame secondFrame = _frames[index + 2];
						score += nextFrame.FirstRoll.Value + secondFrame.FirstRoll.Value;
					}
					else
					{
						score += nextFrame.FirstRoll.Value + nextFrame.SecondRoll.Value;
					}
				}
				else if (frame.IsSpare())
				{
					score += (frame.FirstRoll.Value + frame.SecondRoll.Value);
					Frame nextFrame = _frames[index + 1];
					score += nextFrame.FirstRoll.Value;
				}
				else
				{
					score += (frame.FirstRoll.Value + frame.SecondRoll.Value);
				}
			}

			return score;
		}
	}
}