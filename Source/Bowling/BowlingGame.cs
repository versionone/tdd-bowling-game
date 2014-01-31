using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private int score = 0;
		private int roll_count = 0;
		private bool last_frame_was_spare = false;
		private int frame_count = 0;

		private int first_roll;

		public int Score
		{
			get { return score; }
		}

		public void Roll(int value)
		{
			if (frame_count >= 10)
			{
				throw new BowlingFrameException();
			}

			if (last_frame_was_spare )
			{
				last_frame_was_spare = false;
				score += value;
			}
			score += value;
			if (roll_count == 1)
			{
				if ((first_roll+value) == 10)
				{
					last_frame_was_spare = true;
				}
				
				roll_count = 0;
				frame_count++;
			}
			else
			{
				first_roll = value;
				roll_count++;
			}
			
		}

	}

	public class BowlingFrameException : Exception {}
}
