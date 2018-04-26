using System;

namespace Bowling
{
	public class Game
	{
		private Frame _currentFrame;
		private int _frameCount = 1;
		public int Score { get; private set; }

		public Game()
		{
			_currentFrame = new Frame(null);
		}

		public void Roll(int pins)
		{
			if (_currentFrame.IsComplete)
			{
				if (_frameCount == 10)
					throw new InvalidOperationException("Game is already finished");

				_frameCount++;
				_currentFrame = _frameCount == 10 ?
					new TenthFrame(_currentFrame) :
					new Frame(_currentFrame);
			}

			_currentFrame.TrackPins(pins);

			Score += CalculateBonus(pins);

			Score += pins;
		}

		private int CalculateBonus(int pins)
		{
			return pins*_currentFrame.GetBonusCount();
		}
	}

	public class Frame
	{
		protected int? _firstRoll;
		public bool IsComplete { get; protected set; }

		private int _bonusBallsNeeded;
		private readonly Frame _previousFrame;

		public Frame(Frame frame)
		{
			_previousFrame = frame;
		}

		public virtual void TrackPins(int pins)
		{
			if (_firstRoll == null )
			{
				if (IsStrikeBowled(pins))
				{
					_bonusBallsNeeded = 2;
					IsComplete = true;
				}
				_firstRoll = pins;
			}
			else
			{
				IsComplete = true;
				if (IsSpareBowled(pins))
				{
					_bonusBallsNeeded = 1;
				}
			}
		}

		protected bool IsSpareBowled(int pins)
		{
			return _firstRoll + pins == 10;
		}

		protected static bool IsStrikeBowled(int pins)
		{
			return pins == 10;
		}


		private bool NeedsBonus()
		{
			if (_bonusBallsNeeded > 0)
			{
				_bonusBallsNeeded--;
				return true;
			}
			return false;
		}

		public int GetBonusCount()
		{
			var bonusCount = 0;
			if (_previousFrame != null)
			{
				if (_previousFrame.NeedsBonus())
					bonusCount++;
				bonusCount += _previousFrame.GetBonusCount();
			}
			return bonusCount;

		}
	}

	public class TenthFrame : Frame
	{
		private int _needRolls = 2;

		public TenthFrame(Frame frame) : base(frame)
		{
		}

		public override void TrackPins(int pins)
		{
			if (!_firstRoll.HasValue)
			{
				_firstRoll = pins;
				if (IsStrikeBowled(pins))
					_needRolls++;
			}
			else if (IsSpareBowled(pins))
				_needRolls++;

			if (--_needRolls == 0)
				IsComplete = true;
		}
	}
}
