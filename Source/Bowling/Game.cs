using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private int _score;

		private int _roll_count = 0;
		private int _frame_count = 0;

		private readonly int[][] _rolls = new int[10][];

		public void Roll(int number)
		{
			if (_frame_count > 9) throw new GameCompleteException();

			_score += number;

			if(_roll_count == 0)
				_rolls[_frame_count] = new int[2]; //initialize frame

			var current_frame = _rolls[_frame_count];
			current_frame[_roll_count] = number;

			if (_frame_count > 0) //bonus check 
			{
				var previousFrame = _rolls[_frame_count - 1];
				if (_roll_count == 1 && previousFrame[0] == 10) //strike
				{
					_score += current_frame[0] + current_frame[1];
				}
				else if (_roll_count == 0 && 
					previousFrame[0] != 10 &&
					previousFrame[0] + previousFrame[1] == 10) //spare 
				{
					_score += number;
				}
			}


			if (_roll_count == 1) //end of frame
			{
				_frame_count ++;
				_roll_count = 0;
			} 
			else if (_roll_count == 0 && number == 10) //end of strike
			{
				_frame_count++;
				_roll_count = 0;
			}
			else //middle of the frame
			{
				_roll_count ++;
			}

		}

		public int Score()
		{
			return _score;
		}
	}
}
