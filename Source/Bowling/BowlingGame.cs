using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		public int Score { get; set; }
		private int _numberOfFutureBallsToAdd = 0;
		private int _firstBallPins = -1;
		private int _rollCount = 0;

		public void Roll(int pins)
		{
			_rollCount++;
			if (_rollCount > 20)
				throw new InvalidOperationException("Game Over");

			// Check for spare/strike - add current pins to score and decrement number of future balls to add variable
			if (_numberOfFutureBallsToAdd > 0)
			{
				Score += pins;
				_numberOfFutureBallsToAdd--;
			}

			// Always add current pins to score
			Score += pins;

			if (_firstBallPins == -1 && pins == 10) // Strike
				_numberOfFutureBallsToAdd = 2;
			else if (_firstBallPins + pins == 10) // Spare
				_numberOfFutureBallsToAdd = 1;

			// Save the number of pins if this is the first ball
			_firstBallPins = (_firstBallPins == -1 && pins != 10) ? pins : -1;
		}
	}
}
