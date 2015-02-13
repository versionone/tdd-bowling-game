using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private int _frame = 1;
		private int _throw = 1;
		private int _ballsToAdd;
		private int _lastRoll;

		public int Score
		{
			get { return _score; }
		}

		public void Roll(int numberOfPins)
		{
			CheckIfGameOver();
			_score += numberOfPins;
			if (_ballsToAdd > 0)
			{
				_score += numberOfPins;
				_ballsToAdd--;
			}

			if (IsStrike(numberOfPins))
			{
				_ballsToAdd = 2;
			}
			else if (IsSpare(numberOfPins))
			{
				_ballsToAdd = 1;
			}
			if (_throw == 2)
			{
				_throw = 1;
				_frame++;
			}
			else
			{
				_throw++;
			}
			_lastRoll = numberOfPins;
		}

		private void CheckIfGameOver()
		{
			if(_frame > 10)
				throw new Exception("Game Over");
		}

		private bool IsSpare(int numberOfPins)
		{
			return numberOfPins + _lastRoll == 10 && _throw == 2;
		}

		private bool IsStrike(int numberOfPins)
		{
			return numberOfPins == 10 && _throw == 1;
		}
	}
}
