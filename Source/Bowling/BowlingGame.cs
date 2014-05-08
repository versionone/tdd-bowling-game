using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		private int? _firstRollPins = null;
		private int _rollCount = 0;

		public void Roll(int pins)
		{
			CheckGameOver();
			UpdateScore(pins);
			UpdatePreviousFrameTypes(pins);
			UpdateFirstRollPins(pins);
		}

		private void CheckGameOver()
		{
			// Check to make sure we only allow 20 rolls
			_rollCount++;
			if (_rollCount > 20)
				throw new InvalidOperationException("Game Over");
		}

		private void UpdateFirstRollPins(int pins)
		{
			// Save the number of pins if this is the first roll
			_firstRollPins = (IsFirstRoll && pins != 10) ? pins : (int?) null;
		}

		private void UpdatePreviousFrameTypes(int pins)
		{
			if (IsFirstRoll && pins == 10) // Strike
				EnqueueFrame(FrameType.Strike);
			else if (_firstRollPins + pins == 10) // Spare
				EnqueueFrame(FrameType.Spare);
			else if (!IsFirstRoll)
				EnqueueFrame(FrameType.Normal);
		}

		private bool IsFirstRoll
		{
			get
			{
				return !_firstRollPins.HasValue;
			}
		}

		private void UpdateScore(int pins)
		{
			var multiplier = 1;
			var previousFrameTypesArray = _previousFrameTypes.ToArray();
			if (previousFrameTypesArray[1] == FrameType.Spare && IsFirstRoll || previousFrameTypesArray[1] == FrameType.Strike)
			{
				multiplier++;
			}
			if (previousFrameTypesArray[0] == FrameType.Strike && previousFrameTypesArray[1] == FrameType.Strike && IsFirstRoll)
			{
				multiplier++;
			}

			// Always add current pins to score
			Score += multiplier*pins;
		}

		private void EnqueueFrame(FrameType frameType)
		{
			_previousFrameTypes.Dequeue();
			_previousFrameTypes.Enqueue(frameType);
		}
	}
}
