using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Bowling
{
	public class Frame
	{
		private int _ball1, _ball2;
		private int? _ball3;

		public Frame(int ball1, int ball2)
		{
			_ball1 = ball1;
			_ball2 = ball2;
		}

		public void ThirdBall(int ball3)
		{
			_ball3 = ball3;
		}

		public int GetFrameScore()
		{
			if (IsSpare || IsStrike)
			{
				return FrameScore + _ball3.Value;
			}
			return FrameScore;
		}

		private int FrameScore
		{
			get { return _ball1 + _ball2; }
		}

		public bool IsSpare
		{
			get { return FrameScore == 10; }
		}

		public bool IsStrike
		{
			get { return (_ball1 == 10); }
		}
	}
	public class BowlingGame
	{
		private List<int> _rolls = new List<int>();

		public void Roll(int pins)
		{
			_rolls.Add(pins);
		}

		public int GetScore()
		{
			var score = 0;
			var frames = new List<Frame>();
			for(var i = 0; i < _rolls.Count; i +=2 )
			{
				if (IsGameOver(frames))
					break;

				var frame = new Frame(_rolls[i], _rolls[i + 1]);
				if (frame.IsSpare || frame.IsStrike)
				{
					frame.ThirdBall(_rolls[i + 2]);
					if(frame.IsStrike) i--;

				}
				frames.Add(frame);

				score += frame.GetFrameScore();
			}
			return score;
		}

		private static bool IsGameOver(List<Frame> frames)
		{
			return frames.Count >= 10;
		}
	}
}