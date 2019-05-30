using System;
using System.Diagnostics;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private int? _firstRoll;
		private int? _secondRoll;
		private int _framesBowled;
		private bool _isStrike;

		public void Roll(int pins)
		{
			if (_framesBowled == 10)
			{
				throw new InvalidOperationException("out of frames");
			}

			if (_isStrike && _firstRoll.HasValue && _secondRoll.HasValue)
			{
				_score += _firstRoll.Value + _secondRoll.Value;
				_isStrike = false;
			}

			if (_firstRoll.HasValue && _secondRoll.HasValue)
			{
				if (_firstRoll + _secondRoll == 10)
				{
					_score += pins;
				}

				_firstRoll = null;
				_secondRoll = null;
			}

			if (!_firstRoll.HasValue)
			{
				if (pins == 10)
				{
					_isStrike = true;
					_framesBowled++;
				}
				else
				{
					_firstRoll = pins;
				}
			}
			else
			{
				_secondRoll = pins;
				_framesBowled++;
			}

			_score += pins;
		}

		public int Score
		{
			get { return _score; }
		}
	}
}
