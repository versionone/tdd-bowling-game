using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public enum FrameType { Normal, Spare, Strike }

	public class Frame
	{
		public int First { get; set; }
		public int? Second { get; set; }

		public int Sum
		{
			get { return First + Second.GetValueOrDefault(0); }
		}
		public FrameType Type
		{
			get
			{
				if (First == 10) return FrameType.Strike;
				if (Sum == 10) return FrameType.Spare;
				return FrameType.Normal;
			}
		}
	}

	public class BowlingGame
	{
		private readonly List<Frame> _frames = new List<Frame>();

		private bool _isFirstRoll = true;
		private int _allowedBonus = 0;

		public void Roll(int pins)
		{
			Frame frame;

			if (_isFirstRoll)
			{
				frame = new Frame();
				_frames.Add(frame);

				frame.First = pins;

				if (frame.Type != FrameType.Strike)
					_isFirstRoll = false;
			}
			else
			{
				frame = _frames.Last();
				frame.Second = pins;

				_isFirstRoll = true;
			}

			if (_frames.Count > 10)
			{
				if (_allowedBonus == 0)
					throw new Exception("Too many frames");

				_allowedBonus--;
			}

			if (_frames.Count == 10)
				_allowedBonus = _frames.Last().Type == FrameType.Strike ? 2 : _frames.Last().Type == FrameType.Spare ? 1 : 0;
		}

		public int Score()
		{
			int score = 0;

			for (int i = 0; i < _frames.Count && i < 10; i++)
			{
				var frame = _frames[i];
				score += frame.Sum;

				switch (frame.Type)
				{
					case FrameType.Normal:
						// Do nothing
						break;
					case FrameType.Spare:
						score += _frames[i + 1].First;
						break;
					case FrameType.Strike:
						score += _frames[i + 1].Sum;
						if (_frames[i + 1].Type == FrameType.Strike)
						{
							score += _frames[i + 2].First;
						}
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			return score;
		}
	}
}
