using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public enum FrameType { Normal, Spare, Strike }

	public class BowlingFrame
	{
		public FrameType Type { get; set; }
		public int firstRoll = 0;
		public int secondRoll = 0;
	}

	public class ClassicBowlingGame
	{
		private int _score = 0;
		private bool _isSecondRoll = false;
		private int _frameCounter = 0;
		private BowlingFrame[] _frames = new BowlingFrame[10];
		private int _bonus = 0;
		private bool _bonusRolls = false;

		public void Roll(int pins)
		{
			if (_bonusRolls)
			{
				if (_bonus > 0)
				{
					_score += pins;
					_bonus--;

					if (_bonus == 1)
					{
						var ninethFrame = _frames[8];
						if (ninethFrame.Type == FrameType.Strike)
						{
							_score += 10;
						}
					}
				}

				return;
			}

			if (_frameCounter == 10)
			{
				throw new Exception("More than 10 frames");
			}

			BowlingFrame frame;
			if (!_isSecondRoll)
			{
				frame = new BowlingFrame();
				_frames[_frameCounter] = frame;

				if (pins == 10)
				{
					frame.Type = FrameType.Strike;
				}

				frame.firstRoll = pins;
			}
			else
			{
				frame = _frames[_frameCounter];

				if (frame.firstRoll + pins == 10)
				{
					frame.Type = FrameType.Spare;
				}
			}

			_score += pins;

			if (_frameCounter > 0)
			{
				BowlingFrame previousFrame = _frames[_frameCounter - 1];

				if ((previousFrame.Type == FrameType.Spare && !_isSecondRoll) || previousFrame.Type == FrameType.Strike)
				{
					_score += pins;
				}

				if (_frameCounter > 1)
				{
					var previousPreviousFrame = _frames[_frameCounter - 2];

					if (previousPreviousFrame.Type == FrameType.Strike && !_isSecondRoll && previousFrame.Type == FrameType.Strike)
					{
						_score += pins;
					}
				}
			}

			if (_frameCounter == 9)
			{
				if (frame.Type == FrameType.Strike && !_bonusRolls)
				{
					_bonus = 2;
					_bonusRolls = true;
				}

				if (frame.Type == FrameType.Spare && !_bonusRolls)
				{
					_bonus = 1;
					_bonusRolls = true;
				}
			}

			if (frame.Type == FrameType.Strike || _isSecondRoll == true)
			{
				_isSecondRoll = false;
				_frameCounter++;
			}
			else
			{
				_isSecondRoll = true;
			}
		}

		public int Score()
		{
			return _score;
		}
	}

	public class BowlingGame
	{
		private readonly List<int> _rolls = new List<int>();

		public void Roll(int pins)
		{
			_rolls.Add(pins);
		}

		public int Score()
		{
			int score = 0;
			bool isFirstRoll = true;
			int frameCount = 0;

			for (int i = 0; i < _rolls.Count && frameCount < 10; i++)
			{
				int first = _rolls[i];
				int? second = null;
				int? third = null;

				score += first;

				if (i < _rolls.Count - 1)
					second = _rolls[i + 1];

				if (i < _rolls.Count - 2)
					third = _rolls[i + 2];

				if (isFirstRoll)
				{
					if (first == 10)
					{
						// Strike
						score += second.GetValueOrDefault(0) + third.GetValueOrDefault(0);
						frameCount++;
					}
					else
					{
						if (first + second == 10)
						{
							// Spare
							score += third.GetValueOrDefault(0);
						}

						isFirstRoll = false;
					}
				}
				else
				{
					isFirstRoll = true;
					frameCount++;
				}
			}

			return score;
		}
	}
}
