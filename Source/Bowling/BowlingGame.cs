using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	internal class Constants
	{
		public const int CLOSED_FRAME = 10;
		public const int MAX_ROLLS = 2;
	}

	public class BowlingGame
	{
		private readonly List<Frame> _frames = new List<Frame>(10);
		private int _currentFrame = 0;

		public BowlingGame()
		{
			_frames.Add(new Frame());
		}

		public void Roll(int knockedDownPins)
		{
			//increase the number of rolls in current frame
			Frame currentFrame = _frames[_currentFrame];

			currentFrame.NumberOfRolls++;

			//add pins to score
			currentFrame.Score += knockedDownPins;

			if (_frames.Count > 1)
			{
				//apply bonus if deserving?
				if ((currentFrame.PreviousFrame.WasSpare &&
					 currentFrame.NumberOfRolls == 1) || currentFrame.PreviousFrame.WasStrike)
				{
						currentFrame.PreviousFrame.Score += knockedDownPins;

						if (
							(currentFrame.PreviousFrame.PreviousFrame != null &&
							 currentFrame.PreviousFrame.WasStrike &&
							 currentFrame.PreviousFrame.PreviousFrame.WasStrike &&
							 currentFrame.NumberOfRolls == 1) &&
							currentFrame.NumberOfRolls != 2)
						{
							if (!(this.IsLastFrame && currentFrame.NumberOfRolls <= 2))
								currentFrame.PreviousFrame.PreviousFrame.Score += knockedDownPins;
						}
					}
			}

			if (currentFrame.IsComplete && !this.IsLastFrame) //first roll or they got a strike
			{
				_frames.Add(new Frame());
				_currentFrame++;
				_frames[_currentFrame].PreviousFrame = currentFrame;
			}
		}

		public int Score
		{
			get { return _frames.Sum(frame => frame.Score); }
		}

		public bool IsGameComplete
		{
			get { return _frames.Count == 10; }
		}

		public bool IsLastFrame
		{
			get { return _currentFrame == 9; }
		}
	}

	internal class Frame
	{
		public Frame PreviousFrame { get; set; }
		public int Score { get; set; }
		public int NumberOfRolls { get; set; }

		public bool WasStrike
		{
			get { return (this.Score >= Constants.CLOSED_FRAME && this.NumberOfRolls != Constants.MAX_ROLLS); }
		}

		public bool WasSpare
		{
			get { return (this.Score >= Constants.CLOSED_FRAME && this.NumberOfRolls == Constants.MAX_ROLLS); }
		}

		public bool IsComplete
		{
			get { return (this.WasStrike || this.NumberOfRolls == Constants.MAX_ROLLS); }
		}
	}
}
