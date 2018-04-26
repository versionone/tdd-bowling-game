using System;

namespace Bowling
{
	public class Game
	{
		private Frame _currentFrame;
		private Frame _lastFrame;
		private int _frameCount = 1;
		public int Score { get; private set; }

		public Game()
		{
			_currentFrame = new Frame();
		}

		public void Roll(int pins)
		{
			if (_currentFrame.IsComplete)
			{
				if (_frameCount == 10)
					throw new InvalidOperationException("Game is already finished");

				_lastFrame = _currentFrame;
				_currentFrame = new Frame();
				_frameCount ++;
			}

			_currentFrame.TrackPins(pins);

			if (_lastFrame != null && _lastFrame.NeedsBonus())
			{
				Score += pins;
			}

			Score += pins;
		}
	}

	public class Frame
	{
		private int? _firstRoll;
		public bool IsSpare { get; private set; }
		public bool IsStrike { get; set; }
		public bool IsComplete { get; private set; }
		private int _bonusBalls;

		public void TrackPins(int pins)
		{
			if (_firstRoll == null )
			{
				if (pins == 10)
				{
					IsStrike = true;
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
					IsSpare = true;
					_bonusBalls = 1;
				}
			}
		}


		public bool NeedsBonus()
		{
			if (_bonusBalls > 0)
			{
				_bonusBalls--;
				return true;
			}
			return false;
		}
	}
}
