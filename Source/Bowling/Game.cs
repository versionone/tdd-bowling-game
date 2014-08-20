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

		public void Roll(int pins)
		{
			_score += pins;
			if (_isSpare)
			{
				_score += pins;
			}
			_isSpare = _previousScore + pins == 10;
			_previousScore = pins;
		}

		public int Score
		{
			get { return _score; }
		}
	}
}
