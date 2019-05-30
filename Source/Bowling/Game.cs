using System;
using System.Diagnostics;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private int? _firstRoll;
		private int? _secondRoll;

		public void Roll(int pins)
		{
			if (_firstRoll.HasValue && _secondRoll.HasValue)
			{
				if (_firstRoll + _secondRoll == 10)
				{
					_score += pins;
					_firstRoll = pins;
					_secondRoll = null;
				}
				else
				{
					_firstRoll = pins;
					_secondRoll = null;
				}
			}
			else
			{
				if (!_firstRoll.HasValue)
				{
					_firstRoll = pins;
				}
				else
				{
					_secondRoll = pins;
				}
			}

			_score += pins;
		}

		public int Score
		{
			get { return _score; }
		}
	}
}
