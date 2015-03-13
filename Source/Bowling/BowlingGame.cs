using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Bowling
{
	public class BowlingGame
	{
		private int _framesCompleted;
		private int _rolls;
		private readonly IList<int> _frameScores = new List<int>() ;

		private bool IsNotFirstFrame
		{
			get { return _framesCompleted != 0; }
		}

		public void Roll(int pins)
		{
			_rolls += 1;
			var isFirstRoll= _rolls%2 != 0;

			if (isFirstRoll)
			{
				ScoreFirstRoll(pins);
			}
			else
			{
				ScoreSecondRoll(pins);
			}
		}

		private void ScoreFirstRoll(int pins)
		{
			CheckGameOver();
			StartNewFrame(pins);
			if (IsPreviousFrameASpare())
			{
				AddBonusToPreviousFrame(pins);
			}
		}

		private void StartNewFrame(int pins)
		{
			_frameScores.Add(pins);
		}

		private bool IsPreviousFrameASpare()
		{
			return IsNotFirstFrame && IsSpare(_frameScores[_framesCompleted - 1]);
		}

		private void AddBonusToPreviousFrame(int pins)
		{
			_frameScores[_framesCompleted - 1] += pins;
		}

		private static bool IsSpare(int previousFrame)
		{
			var isSpare = previousFrame == 10;
			return isSpare;
		}

		private void CheckGameOver()
		{
			if (_frameScores.Count == 10)
			{
				throw new ApplicationException("game over");
			}
		}

		private void ScoreSecondRoll(int pins)
		{
			_frameScores[_framesCompleted] += pins;
			_framesCompleted++;
		}

		public int GetScore()
		{
			return _frameScores.Sum();
		}
	}
}
