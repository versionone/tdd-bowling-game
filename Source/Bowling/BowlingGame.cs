using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		public int Score { get; set; }
		private bool _spare = false;
		private int _firstBallPins = -1;

		public void Roll(int pins)
		{
			// Check for spare - add current pins to score and reset spare flag
			if (_spare)
			{
				Score += pins;
				_spare = false;
			}

			// Always add current pins to score
			Score += pins;

			// If this is a spare, set the flag for the next frame
			if(_firstBallPins + pins == 10)
				_spare = true;

			// Save the number of pins if this is the first ball
			_firstBallPins = (_firstBallPins == -1) ? pins : -1;
		}
	}
}
