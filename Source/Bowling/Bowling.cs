
using System;

namespace Bowling
{
	public class BowlingException : Exception
	{
	}

	public class BowlingGame
	{
		private int[] rolls = new int[21];
		private int current;
		int _rollSequenceNumber;


		public void Roll(int pins)
		{
			if (current == 21) {
				throw new ApplicationException("More than 10 frame is not allowed");
			}
			rolls[current++] = pins;
		}

		public int GetScore()
		{
			var score = 0;
			_rollSequenceNumber = 0;

			for (var frame = 0; frame < 10; frame++)
			{
				if (GetRollScore(_rollSequenceNumber) == 10)
				{
					score += 10 + GetRollScore(_rollSequenceNumber + 1) + GetRollScore(_rollSequenceNumber + 2);
					_rollSequenceNumber++;
					continue;
				}
				if (IsSpare()) {
					score += GetSpareBonusScore();
					_rollSequenceNumber += 2;
					continue;
				}

				score += GetRollScore(_rollSequenceNumber) + GetRollScore(_rollSequenceNumber + 1);
				_rollSequenceNumber += 2;
			}
			return score;
		}

		bool IsSpare()
		{
			return GetRollScore(_rollSequenceNumber) + GetRollScore(_rollSequenceNumber + 1) == 10;
		}

		int GetSpareBonusScore()
		{
			return 10 + GetRollScore(_rollSequenceNumber + 2);
		}

		int GetRollScore(int rollSequenceNumber)
		{
			return rolls[rollSequenceNumber];
		}
	}
}


//when 10 frames have been bowled, don't allow any more to be bowled.

//when the first frame is a strike and the rest score 2, the score is 50.

//when the first 2 frames are strikes and the rest score 2, the score is 68.
//when rolling a perfect game, the score is 300.
//when rolling alternate strikes and spares, the score is 200.
