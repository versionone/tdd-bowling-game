using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Bowling
{
	public class BowlingGame
	{
		public int Score
		{
			get { return _frames.Sum(frame => frame.Score); }
		}

		readonly Frame[] _frames =  new Frame[10];

		public BowlingGame()
		{
			for(int i = 0; i < 10; ++i)
				_frames[i] = new Frame();
		}

		public void Roll(int pins)
		{
			Frame currentFrame = _getCurrentFrame();
			currentFrame.Rolls.Add(pins);

		}

		private Frame _getCurrentFrame()
		{
			for (int i = 0; i < 10; ++i)
			{
				if (!_frames[i].HasCompleteScore)
				{
					return _frames[i];
				}
			}
			return null;

		}
	}

	class Frame {
		public List<int> Rolls { get; private set;}
		public int Score { get; private set; }
		public bool HasCompleteScore = true;

	}
}