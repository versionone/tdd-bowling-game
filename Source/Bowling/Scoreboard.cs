using System;
using System.Runtime.Versioning;

namespace Bowling
{

	public class Scoreboard
	{
		private int _framesBowled = 0;
		private int _score;

		private Frame _lastFrame;
		private Frame _currentFrame;
		private int _currentBox = 0;

		public void Record(int pins)
		{
			if (_framesBowled >= 10)
			{
				throw new Exception("You already bowled 10 frames");
			}

			if (_currentBox == 0)
			{
				// First box in the frame
				_currentBox = 1;
				_currentFrame.pins1 = pins;
			}
			else
			{
				// Second box in the frame
				_currentBox = 0;
				_currentFrame.pins2 = pins;
				var frameScore = _currentFrame.pins1 + _currentFrame.pins2;
				_score += frameScore;
				if (_lastFrame.pins1 + _lastFrame.pins2 == 10)
				{
					_score += _currentFrame.pins1;
				}
				_lastFrame = _currentFrame;
				_currentFrame = new Frame();
				_framesBowled++;
			}
		}

		public int Score
		{
			get { return _score; }
		}
	}

	struct Frame
	{
		public int pins1;
		public int pins2;
	}
}