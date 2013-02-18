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

		private Frame[] _frames = new Frame[10];

		private class Frame
		{
			private int? first;
			private int? second;

			public bool isStrike()
			{
				return (first == 10);
			}

			public bool isSpare()
			{
				return (first + second == 10) && (first != 10);
			}

			public bool isComplete()
			{

				if (isStrike())
					return true;
				else
					return (second != null);
			}

			public void add(int number)
			{
				if (first == null)
				{
					first = number;
				}
				else if (!isComplete())
				{
					second = number;
				}
			}

			public int getFirst()
			{
				return first ?? 0;
			}

			public int getSecond()
			{
				return second ?? 0;
			}
		}

		public void Roll(int number)
		{
			if (_frames[_frame_count] == null) _frames[_frame_count] = new Frame();

			var currentFrame = _frames[_frame_count];

			if (currentFrame.isComplete())
			{
				_frame_count++;

				if (_frame_count > 9)
					throw new GameCompleteException();

				_frames[_frame_count] = new Frame();
				currentFrame = _frames[_frame_count];
			}

			currentFrame.add(number);
		}

		public int Score()
		{
			var score = 0;
			if (_frame_count < 9)
			{
				throw new GameCompleteException();
			}

			for (var i = 0; i < 10; i++)
			{
				var frame = _frames[i];
				Frame nextFrame;

				if (frame.isStrike())
				{
					nextFrame = _frames[i + 1];

					if (nextFrame.isStrike())
					{
						var nextNextFrame = _frames[i + 2];
						score += 20 + nextNextFrame.getFirst();
					}
					else
					{
						score += 10 + nextFrame.getFirst() + nextFrame.getSecond();
					}
				}
				else if (frame.isSpare())
				{
					nextFrame = _frames[i + 1];
					score += 10 + nextFrame.getFirst();
				}
				else
				{
					score += frame.getFirst() + frame.getSecond();
				}
			}

			return score;
		}
	}
}
