using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private IList<Frame> _frames = new List<Frame>();

		private Frame CurrentFrame {
			get { return _frames.LastOrDefault(); }
		}

		public void Roll(int pins)
		{
			if (IsOver)
			{
				throw new Exception("Game is over.");
			}
			var lastFinishedFrame = _frames.LastOrDefault(f => f.IsFinished());

			if (CurrentFrame == null || CurrentFrame.IsFinished())
			{
				_frames.Add(new Frame(pins));
			}
			else
			{
				CurrentFrame.AddRoll(pins);
			}

			if (lastFinishedFrame != null && CurrentFrame.IsFinished())
			{
				if (lastFinishedFrame.IsSpare())
				{
					_score += CurrentFrame.FirstRoll;
				}
				else if(lastFinishedFrame.IsStrike())
				{
					_score += CurrentFrame.FirstRoll + CurrentFrame.SecondRoll;
				}
			}

			_score += pins;
		}

		public bool IsOver
		{
			get { return _frames.Count(f=>f.IsFinished()) == 10; }
		}


		public int Score
		{
			get { return _score; }
		}
	}

	public class Frame
	{
		private bool _isFirstRoll = true;

		public int FirstRoll { get; private set; }
		public int SecondRoll { get; private set; }

		public Frame(int pins)
		{
			FirstRoll = pins;
		}

		public bool IsSpare()
		{
			return !IsStrike() && FirstRoll + SecondRoll == 10;
		}

		public bool IsFinished()
		{
			return IsStrike() || !_isFirstRoll;
		}

		public void AddRoll(int pins)
		{
			_isFirstRoll = false;
			SecondRoll = pins;
		}

		public bool IsStrike()
		{
			return FirstRoll == 10;
		}
	}
}
