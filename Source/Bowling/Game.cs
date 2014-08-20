using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private IList<IFrame> _frames = new List<IFrame>();

		private IFrame CurrentFrame
		{
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
				Frame frame = new Frame(pins);
				if (_frames.Count == 9)
				{
					_frames.Add(new TenthFrame(frame));
				}
				else
				{
					_frames.Add(frame);
				}
			}
			else
			{
				CurrentFrame.AddRoll(pins);
			}

			//if (lastFinishedFrame != null && CurrentFrame.IsFinished())
			//{
			//    if (lastFinishedFrame.IsSpare())
			//    {
			//        _score += CurrentFrame.FirstRoll;
			//    }
			//    else if(lastFinishedFrame.IsStrike())
			//    {
			//        _score += CurrentFrame.FirstRoll + CurrentFrame.SecondRoll;
			//    }
			//}

			//_score += pins;
		}

		public bool IsOver
		{
			get
			{
				return _frames.Count(f => f.IsFinished()) == 10;
			}
		}


		public int Score
		{
			get
			{
				var score = 0;
				for (var frameIndex = 0; frameIndex < _frames.Count; frameIndex++)
				{
					var frame = _frames[frameIndex];
					score += frame.Score(_frames.Skip(frameIndex + 1).Take(2));

//					score += frame.FirstRoll + frame.SecondRoll + frame.Bonus;
//
//
//
//					if (frameIndex )
//						continue;
//
//					var isStrike = frame.IsStrike();
//					if (frame.IsSpare() || isStrike)
//					{
//						var nextFrame = _frames[frameIndex + 1];
//						score += nextFrame.FirstRoll;
//
//						if (isStrike)
//						{
//							if (nextFrame.IsStrike())
//							{
//								var nextNextFrame = _frames[frameIndex + 2];
//								score += nextNextFrame.FirstRoll;
//							}
//							else
//								score += nextFrame.SecondRoll;
//						}
//					}
				}
				return score;
			}
		}
	}

	public class TenthFrame : IFrame
	{
		private readonly Frame _frame;

		public TenthFrame(Frame frame)
		{
			_frame = frame;
		}

		public int FirstRoll { get { return _frame.FirstRoll; } }
		public int SecondRoll { get { return _frame.SecondRoll; } }
		public int? FirstBonusRole { get; private set; }
		private int? _secondBonusRole;
		private int rollCount = 1;

		public bool IsSpare()
		{
			return _frame.IsSpare();
		}

		public bool IsStrike()
		{
			return _frame.IsStrike();
		}

		public bool IsFinished()
		{
			var finished = !(IsSpare() || IsStrike()) && _frame.IsFinished();
			return finished || (IsSpare() && FirstBonusRole.HasValue) || (IsStrike() && _secondBonusRole.HasValue);
		}

		public void AddRoll(int pins)
		{
			if (_frame.IsStrike())
			{
				if (rollCount == 1)
					FirstBonusRole = pins;
				else
					_secondBonusRole = pins;
			}
			else if (_frame.IsSpare())
			{
				FirstBonusRole = pins;
			}
			else if (rollCount == 1)
			{
				_frame.AddRoll(pins);
			}
			rollCount++;
		}

		public int Score(IEnumerable<IFrame> extraFrames)
		{
			return FirstRoll + SecondRoll + FirstBonusRole.GetValueOrDefault() + _secondBonusRole.GetValueOrDefault();
		}
	}

	public interface IFrame
	{
		int FirstRoll { get; }
		int SecondRoll { get; }
		bool IsSpare();
		bool IsStrike();
		bool IsFinished();
		void AddRoll(int pins);
		int Score(IEnumerable<IFrame> extraFrames);
	}

	public class Frame : IFrame
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

		public int Score(IEnumerable<IFrame> extraFrames)
		{
			var score = FirstRoll + SecondRoll;
			var nextRoll = extraFrames.First();

			if (IsSpare())
			{
				score += nextRoll.FirstRoll;
			}
			else if (IsStrike())
			{
				score += nextRoll.FirstRoll;

				if (nextRoll.IsStrike())
				{
					if (nextRoll is TenthFrame)
						score += ((TenthFrame)nextRoll).FirstBonusRole.Value;
					else
						score += extraFrames.ElementAt(1).FirstRoll;
				}
				else score += nextRoll.SecondRoll;
			}

			return score;
		}

		public bool IsStrike()
		{
			return FirstRoll == 10;
		}
	}
}
