using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Versioning;
using NUnit.Framework;

namespace Bowling
{
	public class BowlingGame
	{
		private int _framesCompleted;
		private int _rolls;
		private readonly IList<Frame> _frames = new List<Frame>();

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
			_frames.Add(new Frame()
			{
				Score = pins
			});
			if (pins == 10)
			{
				_framesCompleted++;
			}
		}

		private bool IsPreviousFrameASpare()
		{
			return IsNotFirstFrame && IsSpare(_frames[_framesCompleted - 1].Score);
		}

		private void AddBonusToPreviousFrame(int pins)
		{
			_frames[_framesCompleted - 1].Score += pins;
		}

		private static bool IsSpare(int previousFrame)
		{
			var isSpare = previousFrame == 10;
			return isSpare;
		}

		private void CheckGameOver()
		{
			if (_frames.Count == 10)
			{
				throw new ApplicationException("game over");
			}
		}

		private void ScoreSecondRoll(int pins)
		{
			_frames[_framesCompleted].Score += pins;
			_framesCompleted++;
		}

		public int GetScore()
		{
			return _frames.Sum(x => x.Score);
		}
	}

	public class Frame
	{
		public int Score { get; set; }
	}
}
