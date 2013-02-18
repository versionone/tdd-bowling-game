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

			_frames[9] = new TenthFrame();
			for (int i = 8; i >= 0; i--)
			{
				_frames[i] = new Frame(_frames[i+1]);
			}
		}

		private class Frame
		{
			protected int? first;
			protected int? second;
			protected Frame _nextFrame;

			public Frame(Frame nextFrame)
			{
				_nextFrame = nextFrame;
			}

			protected Frame()
			{

			}

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

			public virtual int getScore()
			{
				if (isSpare())
				{
					return 10 + _nextFrame.getSpareBonus();
				}
				else if (isStrike())
				{
					return 10 + _nextFrame.getStrikeBonus();
				}
				else
				{
					return first.Value + second.Value;
				}
			}

			public int getSpareBonus()
			{
				return first.Value;
			}

			public virtual int getStrikeBonus()
			{
				if (isStrike())
				{
					return 10 + _nextFrame.getSpareBonus();
				}
				else
				{
					return first.Value + second.Value;
				}
			}

		}

		private class TenthFrame : Frame
		{
			private int? third;

			public TenthFrame()
			{

			}

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

			public override int getScore()
			{
				return first.Value + second.Value + (third ?? 0);
			}

			public override int getStrikeBonus()
			{
				return first.Value + second.Value;
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
			if(!isComplete())
				throw new GameIncompleteException();

			return _frames.Sum((frame) => frame.getScore());
		}
	}
}
