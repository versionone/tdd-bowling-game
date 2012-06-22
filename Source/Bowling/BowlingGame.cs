using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class BowlingGame
	{
		public BowlingGame()
		{
			AdvanceFrame();
		}

		private readonly List<Frame> _frames = new List<Frame>();

		private Frame _previousFrame;
		private Frame _currentFrame;

		private void AdvanceFrame()
		{
			_previousFrame = _currentFrame;

			if (_frames.Count < 10)
			{
				_currentFrame = new Frame();
				_frames.Add(_currentFrame);
			}
		}

		public int Score
		{
			get
			{
				return _frames.Sum(frame => frame.Score);
			}
		}

		public bool IsOver
		{
			get { return _frames.Count == 10 && _frames.All(x => x.IsClosed); }
		}

		public void Roll(int pinsDown)
		{
			if (IsOver)
			{
				throw new GameOverException();
			}

			AddFrameScore(pinsDown);
			AdvanceFrameIfCurrentFrameClosed();
		}

		private void AddFrameScore(int pinsDown)
		{
			_currentFrame.AddRoll(pinsDown);
			ApplyBonusToPreviousFrames(pinsDown);
		}

		private void ApplyBonusToPreviousFrames(int pinsDown)
		{
			Frame prevFrame = null, prevPrevFrame = null;
			var currentFrameIndex = _frames.Count - 1;

			if (currentFrameIndex >= 2)
				prevPrevFrame = _frames[currentFrameIndex - 2];
			if (currentFrameIndex >= 1)
				prevFrame = _frames[currentFrameIndex - 1];

			ApplyBonusForStrike(prevPrevFrame, pinsDown);
			ApplyBonusForPrevious(prevFrame, pinsDown);
		}

		private void ApplyBonusForStrike(Frame frame, int pinsDown)
		{
			if (frame != null && frame.Type == Frame.FrameType.Strike)
			{
				frame.AddBonus(pinsDown);
			}
		}

		private void ApplyBonusForPrevious(Frame frame, int pinsDown)
		{
			if (frame != null)
			{
				frame.AddBonus(pinsDown);
			}
		}

		private void AdvanceFrameIfCurrentFrameClosed()
		{
			if (_currentFrame.IsClosed)
			{
				AdvanceFrame();
			}
		}
	}

		public enum FrameType
		{
		Regular,
		Spare,
		Strike
		}

	public class Frame
	{
		protected const int MarkCount = 10;


		public Frame()
		{
			Type = FrameType.Regular;
		}

		public FrameType Type { get; set; }

		private int _numberOfRolls = 0;

		public void AddRoll(int pinsDown)
		{
			if (!IsClosed)
			{
				_rollScore += pinsDown;
				IncrementRolls();
				SetType();
			}
		}

		protected int RollCount
		{
			get { return _numberOfRolls; }
		}

		protected void IncrementRolls()
		{
			_numberOfRolls++;
		}

		private void SetType()
		{
			if (_rollScore == MarkCount)
			{
				Type = _numberOfRolls == 1 ? FrameType.Strike : FrameType.Spare;
			}
		}

		private int _rollScore;

		public int Score
		{
			get { return _rollScore + _bonus; }
		}

		private int _bonus = 0;
		private int _bonusAppliedCount = 0;

		public bool IsClosed
		{
			get { return _numberOfRolls == 2 || _rollScore == 10; }
		}

		public void AddBonus(int pinsDown)
		{
			//_bonus += pinsDown;

			if (Type == FrameType.Spare && _bonus == 0)
			{
				_bonus = pinsDown;
			}
			else if (Type == FrameType.Strike && _bonusAppliedCount < 2)
			{
				_bonus += pinsDown;
				_bonusAppliedCount++;
			}
		}
	}


	public class TenthFrame : Frame
	{
		public void AddRoll(int pinsDown)
		{
			if (!IsClosed)
			{
				_rollScore += pinsDown;
				_numberOfRolls++;
				SetType();
			}
		}

		private void SetType()
		{
			if (_rollScore == MarkCount)
			{
				Type = _numberOfRolls == 1 ? FrameType.Strike : FrameType.Spare;
			}
		}

		private int _rollScore;

		public int Score
		{
			get { return _rollScore + _bonus; }
		}

		private int _bonus = 0;
		private int _bonusAppliedCount = 0;

		public bool IsClosed
		{
			get { return _numberOfRolls == 2 || _rollScore == 10; }
		}

		public void AddBonus(int pinsDown)
		{
			//_bonus += pinsDown;

			if (Type == FrameType.Spare && _bonus == 0)
			{
				_bonus = pinsDown;
			}
			else if (Type == FrameType.Strike && _bonusAppliedCount < 2)
			{
				_bonus += pinsDown;
				_bonusAppliedCount++;
			}
		}
	}


}