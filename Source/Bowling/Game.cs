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
			_currentFrame = new Frame();
		}

		public void Roll(int pins)
		{


			if (_currentFrame.IsComplete)
			{
				if (_currentFrame.IsSpare)
				{
					Score += pins;
				}

				if (_frameCount == 10)
					throw new InvalidOperationException("Game is already finished");

				_currentFrame = new Frame();
				_frameCount ++;
			}

			_currentFrame.TrackPins(pins);

			Score += pins;
		}
	}

	public class Frame
	{
		private int? _firstRoll;
		public bool IsSpare { get; private set; }
		public bool IsComplete { get; private set; }

		public void TrackPins(int pins)
		{
			if (_firstRoll == null )
			{
				_firstRoll = pins;
			}
			else
			{
				IsComplete = true;
				if (_firstRoll + pins == 10)
				{
					IsSpare = true;
				}
			}
		}
	}
}
