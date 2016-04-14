using System;
using System.Runtime.Versioning;
using System.Security.Policy;

namespace Bowling
{

	public class Scoreboard
	{
		private int _framesBowled = 0;
		private int _score;

		private Frame _lastLastFrame;
		private Frame _lastFrame;
		private Frame _currentFrame = new Frame();

		public void Record(int pins)
		{
			if (_framesBowled >= 10)
			{
				throw new Exception("Can't bowl more than ten frames");
			}

			_currentFrame.Record(pins);
			if (_currentFrame.IsDone)
			{
				CloseFrame();
			}
		}

		private void CloseFrame()
		{
			if (_lastLastFrame != null && _lastFrame != null && _currentFrame != null)
			{
				_score += _lastLastFrame.Score(_lastFrame, _currentFrame);
			}
			_lastLastFrame = _lastFrame;
			_lastFrame = _currentFrame;

			_framesBowled++;
			_currentFrame = _framesBowled == 9 ? new TenthFrame() : new Frame();

			if (_framesBowled == 10)
			{
				// Game is complete
				// Score the ninth frame
				_score += _lastLastFrame.Score(_lastFrame, new Frame());
				// Score the tenth frame
				_score += _lastFrame.Score(new Frame(), new Frame());
			}
		}

		public int Score
		{
			get { return _score; }
		}
	}

	class TenthFrame : Frame
	{
		public int? bonus1;
		public int? bonus2;

		public override bool IsDone
		{
			get
			{
				if (IsStrike)
				{
					return bonus1.HasValue && bonus2.HasValue;
				}
				return base.IsDone;
			}
		}

		public override void Record(int pins)
		{
			if (_currentBox == 0)
			{
				pins1 = pins;
			}
			else if (_currentBox == 1)
			{
				if (IsStrike)
				{
					bonus1 = pins;
				}
				else
				{
					pins2 = pins;
				}
			}
			else if (_currentBox == 2 && IsStrike)
			{
				bonus2 = pins;
			}
			else
			{
				throw new Exception("Recorded too many rolls");
			}

			_currentBox++;
		}

		public override int Score(Frame nextFrame, Frame nextNextFrame)
		{
			var baseScore = base.Score(nextFrame, nextNextFrame);
			if (IsStrike)
			{
				baseScore += bonus1 ?? 0 + bonus2 ?? 0;
			}
			return baseScore;
		}
	}

	class Frame
	{
		public int pins1;
		public int pins2;

		protected int _currentBox = 0;

		public virtual bool IsDone
		{
			get
			{
				return IsStrike || _currentBox == 2;
			}
		}

		public bool IsStrike
		{
			get { return pins1 == 10; }
		}

		public bool IsSpare
		{
			get { return pins1 + pins2 == 10 && pins1 < 10; }
		}

		public virtual void Record(int pins)
		{
			if (_currentBox == 0)
			{
				pins1 = pins;
			}
			else
			{
				pins2 = pins;
			}
			_currentBox++;
		}

		public virtual int Score(Frame nextFrame, Frame nextNextFrame)
		{
			var total = pins1 + pins2;
			if (IsStrike)
			{
				// Add the next two roll values as bonus
				if (nextFrame.IsStrike)
				{
					total += 10 + nextNextFrame.pins1;
				}
				else
				{
					total += nextFrame.pins1 + nextFrame.pins2;
				}
			}
			else if (IsSpare)
			{
				total += nextFrame.pins1;
			}
			return total;
		}
	}
}