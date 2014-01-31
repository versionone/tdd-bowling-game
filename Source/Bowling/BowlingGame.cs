using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private int score = 0;
//		private int roll_count = 0;
//		private bool last_frame_was_spare = false;
//		private int last_frame_was_strike = 0;
//		private int frame_count = 0;
//
//		private int first_roll;

		private List<Frame> frames = new List<Frame>();

		public int Score
		{

			get
			{
				for (int i = 0; i < frames.Count(); i++)
				{
					score += frames[i].Get_First_Roll() + frames[i].Get_Second_Roll();
				}
					return score;
			}
		}

//		public void OldRoll(int value)
//		{
//			if (frame_count >= 10)
//			{
//				throw new BowlingFrameException();
//			}
//
//			if (last_frame_was_spare )
//			{
//				last_frame_was_spare = false;
//				score += value;
//			}
//			score += value;
//			if (roll_count == 1)
//			{
//				if (last_frame_was_strike > 0)
//				{
//					score += value;
//					last_frame_was_strike--;
//				}
//
//				if ((first_roll+value) == 10)
//				{
//					last_frame_was_spare = true;
//				}
//
//				roll_count = 0;
//				frame_count++;
//			}
//			else
//			{
//				if (last_frame_was_strike > 0)
//				{
//					score+=value;
//				}
//				if (value == 10)
//				{
//					last_frame_was_strike++;
//
//				}
//				else
//				{
//					roll_count++;
//				}
//				first_roll = value;
//
//			}
//
//		}

		public void Roll(int value)
		{
			Frame currentFrame;

			if (frames.Count > 0 && !frames.Last().is_Closed())
				currentFrame = frames.Last();
			else
			{
				currentFrame = new Frame();
				frames.Add(currentFrame);
			}

			currentFrame.Add_Roll(value);

		}
	}

	public class BowlingFrameException : Exception {}

	public class Frame
	{
		private int? First_Roll;
		private int? Second_Roll;

		public bool is_Strike()
		{
			return (First_Roll == 10);
		}

		public bool is_Spare()
		{
			return (First_Roll + Second_Roll == 10);
		}

		public bool is_Closed()
		{
			return ((is_Strike()) || (Second_Roll!=null));
		}

		public void Add_Roll(int value)
		{
			if (First_Roll == null)
			{
				First_Roll = value;
			}
			else if (Second_Roll == null)
			{
				Second_Roll = value;
			}
			else
			{
				throw new BowlingFrameException();
			}
		}

		public int Get_First_Roll()
		{
			return (First_Roll) ?? 0;
		}

		public int Get_Second_Roll()
		{
			return (Second_Roll) ?? 0;
		}

	}
}
