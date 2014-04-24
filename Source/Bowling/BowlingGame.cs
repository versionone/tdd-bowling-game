using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class BowlingGame
	{
		private List<Frame> Frames { get; set; }

		public int Score
		{
			get
			{
				int total = 0;
				foreach (var frame in Frames)
				{
					total += frame.FrameScore;
				}
				return total;
			}
		}

		public BowlingGame()
		{
			Frames = new List<Frame>();
		}

		public void Roll(int pins)
		{

			if (Frames.Count == 0)
			{
				Frames.Add(new Frame(pins));
			}
			else
			{
				var currentFrame = Frames.Last();
				if (!currentFrame.FrameIsDoneRolling())
				{
					currentFrame.Roll(pins);
				}
				else
				{
					var previousFrame = Frames.LastOrDefault(frame => frame != currentFrame);
					if (previousFrame != null && !previousFrame.FrameIsDoneScoring())
					{
						previousFrame.Roll(pins);
					}

					if (Frames.Count == 10)
					{
						if (!currentFrame.FrameIsDoneScoring())
							currentFrame.Roll(pins);
						else
							throw new GameOverException();
					}
					else
					{
						if (!currentFrame.FrameIsDoneScoring())
							currentFrame.Roll(pins);

						Frames.Add(new Frame(pins));
					}

/*
					if (!currentFrame.FrameIsDoneScoring())
					{
						currentFrame.Roll(pins);

						if (Frames.Count == 10)
							return;
					}

					if (Frames.Count == 10)
					{
						throw new GameOverException();
					}

					Frames.Add(new Frame(pins));
*/
				}
			}
		}
	}

	public class Frame
	{
		private int RollOne { get; set; }
		private int? RollTwo { get; set; }
		private int? RollThree { get; set; }

		public Frame(int pins)
		{
			RollOne = pins;
		}

		private bool IsSpare()
		{
			return FrameScore == 10 && RollTwo != null;
		}

		private bool IsStrike()
		{
			return RollOne == 10;
		}

		private bool IsNormalFrame()
		{
			return !IsStrike() && !IsSpare();
		}

		public bool FrameIsDoneRolling()
		{
			return IsStrike() || RollTwo != null;
		}

		public bool FrameIsDoneScoring()
		{
			return ((IsStrike() || IsSpare()) && RollThree != null)
				   || (IsNormalFrame() && RollTwo != null);
		}

		public int FrameScore
		{
			get { return RollOne + (RollTwo ?? 0) + (RollThree ?? 0); }
		}

		public void Roll(int pins)
		{
			if(RollTwo == null)
			{
				RollTwo = pins;
			}
			else
			{
				RollThree = pins;
			}
		}
	}

	public class GameOverException : Exception { }
}
