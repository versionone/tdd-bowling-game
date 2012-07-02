using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private int _score = 0;
		private int _numberOfRolls = 0;
		private int _previousFrameScore = 0;

		public void Roll(int knockedDownPins)
		{
			_numberOfRolls++;
			_score += knockedDownPins;

			if (isNewFrame()) //first roll
			{
				//apply bonus if deserving?
				if (_previousFrameScore == 10)
				{
					_score += knockedDownPins;
				}
				
				//reset previous frame
				_previousFrameScore = knockedDownPins;
			}
			else //second roll
			{
				_previousFrameScore += knockedDownPins;
			}
		}

		public int Score { get { return _score; } }

		private bool isNewFrame()
		{
			return (_numberOfRolls%2 != 0);
		}
	}
}
