using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private int _frameNumber;
		private List<Frame> _frames = new List<Frame>();

		private class Frame
		{
			public int? _firstRoll;
			public int? _secondRoll;

			public bool IsStrike
			{
				get { return _firstRoll.HasValue && _firstRoll.Value == 10; }
			}

			public bool IsSpare
			{
				get { return _firstRoll.HasValue && _secondRoll.HasValue && (_firstRoll.Value + _secondRoll.Value == 10); }
			}

			public bool IsComplete
			{
				get { return IsStrike || (_firstRoll.HasValue && _secondRoll.HasValue); }
			}
		}

		public void Roll(int pins)
		{
			if (_frames.Count == 10 && _frames[9].IsComplete)
			{
				throw new InvalidOperationException("out of frames");
			}

			if (_frames.Count == 0)
			{
				var frame = new Frame();
				_frames.Add(frame);
			}

			var currentFrame = _frames[_frames.Count - 1];

			if (currentFrame.IsComplete)
			{
				var frame = new Frame();
				_frames.Add(frame);
				currentFrame = frame;
			}

			if (!currentFrame._firstRoll.HasValue)
			{
				currentFrame._firstRoll = pins;
			}
			else
			{
				currentFrame._secondRoll = pins;
			}

			_score += pins;
		}

		public int Score
		{
			get
			{

				for (var i = 0; i < _frames.Count; i++)
				{
					var currentFrame = _frames[i];

					if (currentFrame.IsSpare)
					{
						_score += _frames[i + 1]._firstRoll.Value;
					}

					if (currentFrame.IsStrike)
					{
						_score += _frames[i + 1]._firstRoll.Value;

						if (_frames[i + 1].IsStrike)
						{
							_score += _frames[i + 2]._firstRoll.Value;
						}
						else
						{
							_score += _frames[i + 1]._secondRoll.Value;
						}
					}
				}

				return _score;
			}
		}
	}
}
