using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private enum FrameType
		{
			Normal,
			Spare,
			Strike
		};
		public int Score { get; set; }
		private readonly Queue<FrameType> _previousFrameTypes = new Queue<FrameType>(new [] { FrameType.Normal, FrameType.Normal });
		private int _firstBallPins = -1;
		private int _rollCount = 0;

		public void Roll(int pins)
		{
			// Check to make sure we only allow 20 rolls
			_rollCount++;
			if (_rollCount > 20)
				throw new InvalidOperationException("Game Over");

			// Check for spare/strike - add current pins to score and decrement number of future balls to add variable
			var multiplier = 1;
			var previousFrameTypesArray = _previousFrameTypes.ToArray();
			if (previousFrameTypesArray[1] == FrameType.Spare && _firstBallPins == -1 || previousFrameTypesArray[1] == FrameType.Strike)
			{
				multiplier++;
			}
			if (previousFrameTypesArray[0] == FrameType.Strike && previousFrameTypesArray[1] == FrameType.Strike && _firstBallPins == -1)
			{
				multiplier++;
			}

			// Always add current pins to score
			Score += multiplier * pins;

			if (_firstBallPins == -1 && pins == 10) // Strike
				EnqueueFrame(FrameType.Strike);
			else if (_firstBallPins + pins == 10) // Spare
				EnqueueFrame(FrameType.Spare);
			else if (_firstBallPins != -1)
				EnqueueFrame(FrameType.Normal);

			// Save the number of pins if this is the first ball
			_firstBallPins = (_firstBallPins == -1 && pins != 10) ? pins : -1;
		}

		private void EnqueueFrame(FrameType frameType)
		{
			_previousFrameTypes.Dequeue();
			_previousFrameTypes.Enqueue(frameType);
		}
	}
}
