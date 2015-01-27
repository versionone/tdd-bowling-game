using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class BowlingGame
	{
		public int Score
		{
			get { return _frames.Sum(f => f.Score); }
		}

		public bool MoreRollsAvailable
		{
			get { return _frames.Count < 10; }
		}

		private readonly List<Frame> _frames = new List<Frame>();
		
		public void Roll(int pins)
		{
			if (_frames.Count == 0)
				_frames.Add(new Frame(pins));
			else
			{
				var currentFrame = _frames[_frames.Count - 1];
				var previousFrame = _frames.Count > 1 ? _frames[_frames.Count - 2] : null;

				if (currentFrame.IsComplete)
					_frames.Add(new Frame(pins));

				if (currentFrame.NeedsAnotherRoll)
				{
					currentFrame.AddRoll(pins);
				}

				if (previousFrame != null && previousFrame.NeedsAnotherRoll)
				{
					previousFrame.AddRoll(pins);
				}
			}
		}

		internal class Frame
		{
			private readonly int FirstRollPins;
			private int? SecondRollPins;
			private int? ThirdRollPins;

			public Frame(int firstRollPins)
			{
				FirstRollPins = firstRollPins;
			}

			public int Score { get { return FirstRollPins + (SecondRollPins ?? 0) + (ThirdRollPins ?? 0); }}

			private bool IsStrike { get { return FirstRollPins == 10; }}
			private bool IsSpare { get { return (FirstRollPins + (SecondRollPins ?? 0)) == 10; }}

			public bool NeedsAnotherRoll
			{
				get
				{
					if (IsStrike) return !(SecondRollPins.HasValue && ThirdRollPins.HasValue);
					if (IsSpare) return !ThirdRollPins.HasValue;
					return !SecondRollPins.HasValue;
				}
			}

			public bool IsComplete
			{
				get { return IsStrike || SecondRollPins.HasValue; }
			}

			public void AddRoll(int pins)
			{
				if (SecondRollPins.HasValue)
					ThirdRollPins = pins;
				else
					SecondRollPins = pins;
			}
		}
	}
}