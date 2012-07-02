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
				Frame previousFrame = _frames[_currentFrame - 1];

				//apply bonus if deserving?
				if ((previousFrame.WasSpare && currentFrame.NumberOfRolls == 1) || previousFrame.WasStrike)
				{
					previousFrame.Score += knockedDownPins;

					if (_frames.Count > 2 && previousFrame.WasStrike && _frames[_currentFrame - 2].WasStrike && currentFrame.NumberOfRolls == 1)
					{
						_frames[_currentFrame - 2].Score += knockedDownPins;
					}
				} 
			}

			if (currentFrame.IsComplete) //first roll or they got a strike
			{
				_frames.Add(new Frame());
				_currentFrame++;
			}
		}

		public int Score
		{
			get { return _frames.Sum(frame => frame.Score); }
		}

		public bool IsGameComplete
		{
			get { return _frames.Count >= 10; }
		}
	}

	internal class Frame
	{
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
