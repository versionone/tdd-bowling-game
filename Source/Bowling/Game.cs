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

				_currentFrame = new Frame(_currentFrame);
				_frameCount ++;
			}

			_currentFrame.TrackPins(pins);

			Score += pins*_currentFrame.GetBonusCount();

			Score += pins;
		}
	}

	public class Frame
	{
		private int? _firstRoll;
		public bool IsComplete { get; private set; }

		private int _bonusBalls;
		private readonly Frame _previousFrame;

		public Frame(Frame frame)
		{
			_previousFrame = frame;
		}

		public void TrackPins(int pins)
		{
			if (_firstRoll == null )
			{
				if (pins == 10)
				{
					_bonusBalls = 2;
					IsComplete = true;
				}
				_firstRoll = pins;
			}
			else
			{
				IsComplete = true;
				if (_firstRoll + pins == 10)
				{
					_bonusBalls = 1;
				}
			}
		}


		private bool NeedsBonus()
		{
			if (_bonusBalls > 0)
			{
				_bonusBalls--;
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
}
