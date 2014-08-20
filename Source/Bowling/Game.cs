using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private bool _isSpare;
		private int _previousScore;
		private bool _isFirstRoll = true;

		public void Roll(int pins)
		{
			_score += pins;

			if (_isSpare)
			{
				_score += pins;
			}

			_isSpare = !_isFirstRoll && (_previousScore + pins == 10);
			_previousScore = pins;
			_isFirstRoll = !_isFirstRoll;
		}

		public int Score
		{
			get { return _score; }
		}
	}
}
