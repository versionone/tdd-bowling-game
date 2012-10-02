using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Specs
{
	public class BowlingGame
	{
		public BowlingGame()
		{
			_frames = new List<Frame>();
		}
		private readonly List<Frame> _frames;
		
		public int Score()
		{
			var score=0;

			Frame lastFrame = null;
			foreach (var frame in _frames)
			{
				if (lastFrame != null && lastFrame.IsSpare)
				{
					score += frame.Rolls.First().Pins;
				}

				score +=frame.Rolls.Sum(r => r.Pins);
				lastFrame = frame;
			}
			return score;
		}

		public void Roll(int pins)
		{
			CurrentFrame.AddRoll(new Roll(pins));
		}

		private Frame CurrentFrame
		{
			get
			{
				if (_frames.Count == 0 || _frames.Last().IsComplete)
					AddNewFrame();

				return _frames.Last();
			}
		}

		private void AddNewFrame()
		{
			if (_frames.Count == 10)
				throw new InvalidOperationException();

			_frames.Add(new Frame());
		}
	}
}
