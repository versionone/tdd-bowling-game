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

		public void Roll(int pins)
		{
			if (_framesBowled == 10)
			{
				throw new InvalidOperationException("out of frames");
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
				_firstRoll = pins;
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
