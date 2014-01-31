using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private List<Frame> frames = new List<Frame>();

		public int Score
		{

			get
			{

				int score = 0;

				for (int i = 0; i < frames.Count(); i++)
				{

					score += frames[i].Get_First_Roll() + frames[i].Get_Second_Roll();
					if (frames[i].is_Spare() )
					{
						score += frames[i + 1].Get_First_Roll();
					}
					else if (frames[i].is_Strike())
					{
						score += frames[i+1].Get_First_Roll() + frames[i+1].Get_Second_Roll();
					}


				}
					return score;
			}
		}

		public void Roll(int value)
		{
			Frame currentFrame;

			if (frames.Count(x => x.is_Closed()) >= 10)
			{
				throw new BowlingFrameException();
			}
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
