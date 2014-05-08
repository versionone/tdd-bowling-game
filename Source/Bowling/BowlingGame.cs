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
		private readonly Queue<FrameType> _previousFrameTypes = new Queue<FrameType>();
		private int? _firstRollPins = null;

		public void Roll(int pins)
		{
			UpdateScore(pins);
			UpdatePreviousFrameTypes(pins);
			UpdateFirstRollPins(pins);
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
			else if (_previousFrameTypes.Count == 10) // Check to make sure we only allow ten frames
				throw new InvalidOperationException("Game Over");
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
			var frameCount = _previousFrameTypes.Count;

			var lastFrameType = frameCount > 0 ? previousFrameTypesArray[frameCount - 1] : FrameType.Normal;
			var secondToLastFrameType = frameCount > 1 ? previousFrameTypesArray[frameCount - 2] : FrameType.Normal;

			if (lastFrameType == FrameType.Spare && IsFirstRoll || lastFrameType == FrameType.Strike)
			{
				multiplier++;
			}
			if (secondToLastFrameType == FrameType.Strike && lastFrameType == FrameType.Strike && IsFirstRoll)
			{
				multiplier++;
			}

			// Always add current pins to score
			Score += multiplier*pins;
		}

		private void EnqueueFrame(FrameType frameType)
		{
			_previousFrameTypes.Enqueue(frameType);
		}
	}
}
