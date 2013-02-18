using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private int _frame_count = 0;
		private Frame[] _frames = new Frame[10];

		public Game()
		{
			for (int i = 0; i < 9; i++)
			{
				_frames[i] = new Frame();
			}
			_frames[9] = new TenthFrame();
		}

		private class Frame
		{
			protected int? first;
			protected int? second;

			public bool isStrike()
			{
				return (first == 10);
			}

			public bool isSpare()
			{
				return (first + second == 10) && (first != 10);
			}

			public virtual bool isComplete()
			{

				if (isStrike())
					return true;
				else
					return (second != null);
			}

			public virtual void add(int number)
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

		private class TenthFrame : Frame
		{
			private int? third;

			public override bool isComplete()
			{
				if (isStrike() || isSpare())
				{
					return (third != null);
				}
				else
				{
					return (second != null);
				}
			}

			public override void add(int number)
			{
				if (first == null)
				{
					first = number;
				}
				else if (second == null)
				{
					second = number;
				}
				else if (!isComplete())
				{
					third = number;
				}
			}

			public int getScore()
			{
				return first.Value + second.Value + (third ?? 0);
			}
		}

		public bool isComplete()
		{
			return _frames.All(f => f.isComplete());
		}


		public void Roll(int number)
		{
			if (isComplete())
				throw new GameCompleteException();


			var currentFrame = _frames[_frame_count];

			if (currentFrame.isComplete())
			{
				_frame_count++;
				currentFrame = _frames[_frame_count];
			}

			currentFrame.add(number);
		}

		public int Score()
		{
			var score = 0;
			if(!isComplete())
				throw new GameIncompleteException();

			for (var i = 0; i < 9; i++)
			{
				var frame = _frames[i];
				Frame nextFrame;

				if (frame.isStrike())
				{
					
					nextFrame = _frames[i + 1];

					if (nextFrame.isStrike())
					{
						
						if (i < 8)
						{
							var nextNextFrame = _frames[i + 2];
							score += 20 + nextNextFrame.getFirst();
						}
						else
						{
							score += 20 + nextFrame.getSecond();
						}
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

			score += ((TenthFrame)_frames[9]).getScore();

			return score;
		}
	}
}
