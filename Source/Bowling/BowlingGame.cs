using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private const int STRIKE = 10;
		private int _score = 0;
		private int _numberOfRollsInCurrentFrame = 0;
		private int _numberOfFramesBowled = 0;
		private int _previousFrameScore = 0;
		private bool _areInStrikeMode = false;
		private int _numberOfRollsAfterStrike = 0;

		public void Roll(int knockedDownPins)
		{
			//increase the number of rolls in current frame
			_numberOfRollsInCurrentFrame++;

			//add pins to score
			_score += knockedDownPins;

			//track the next two rolls and add to score
			if (_areInStrikeMode && _numberOfRollsAfterStrike < 2)
			{
				_numberOfRollsAfterStrike++;
				_score += knockedDownPins;
			}
			else
			{ //clear the strike tracking
				_areInStrikeMode = false;
				_numberOfRollsAfterStrike = 0;
			}

			if (isNewFrame()) //first roll or they got a strike
			{
				_numberOfFramesBowled++;

				//set to strike mode to track the next to rolls, and reset rolls
				if (knockedDownPins == STRIKE)
				{
					_areInStrikeMode = true;
					_numberOfRollsInCurrentFrame = 0;
				}

				//apply bonus if deserving?
				if (_previousFrameScore == 10 && !_areInStrikeMode)
				{
					_score += knockedDownPins;
				}

				//reset previous frame
				_previousFrameScore = knockedDownPins;
			}
			else //second roll
			{
				_previousFrameScore += knockedDownPins;
				_numberOfRollsInCurrentFrame = 0;
			}
		}

		public int Score { get { return _score; } }

		public bool IsGameComplete
		{
			get { return _numberOfFramesBowled >= 10; }
		}

		private bool isNewFrame()
		{
			//current frame they have bowled two times or it was a strike
			return (_numberOfRollsInCurrentFrame == 1);
		}
	}
}
