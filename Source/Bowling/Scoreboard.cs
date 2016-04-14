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

			if (_currentBox == 0 && pins == 10)
			{
				// strike!
				_currentFrame.pins1 = pins;
				CloseFrame();
			}
			else if (_currentBox == 0)
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
				CloseFrame();
			}
		}

		private void CloseFrame()
		{
			_score += _lastFrame.Score(_currentFrame);
			_lastFrame = _currentFrame;
			_currentFrame = new Frame();
			_framesBowled++;
			if (_framesBowled == 10)
			{
				// Game is complete
				_score += _lastFrame.Score(_currentFrame);
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

		public int Score(Frame nextFrame)
		{
			var total = pins1 + pins2;
			if (pins1 == 10)
			{
				total += nextFrame.pins1 + nextFrame.pins2;
			}
			else if (pins1 + pins2 == 10)
			{
				total += nextFrame.pins1;
			}
			return total;
		}
	}
}