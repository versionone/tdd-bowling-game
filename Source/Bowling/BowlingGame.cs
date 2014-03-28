using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class BowlingGame
	{
		private readonly List<int> _rolls = new List<int>();

		private bool _isFirstRoll = true;
		private int _frameCount = 0;
		private int _allowedBonus = 0;

		public void Roll(int pins)
		{
			if (_isFirstRoll)
			{
				_frameCount++;
				if (pins != 10)
				{
					_isFirstRoll = false;
				}
			}
			else
			{
				_isFirstRoll = true;
			}

			if (_frameCount > 10)
			{
				if (_allowedBonus == 0)
					throw new Exception("Too many frames");

				_allowedBonus--;
			}

			_rolls.Add(pins);

			if (_frameCount == 10)
				_allowedBonus = _rolls.Last() == 10 ? 2 : _rolls.Skip(_rolls.Count() - 2).Sum() == 10 ? 1 : 0;
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
