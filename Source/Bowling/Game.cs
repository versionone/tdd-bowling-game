using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private int _frameCount = 0;
		private readonly Frame[] _frames = new Frame[10];

		public Game()
		{
			_frames[9] = new TenthFrame();
			for (int i = 8; i >= 0; i--)
			{
				_frames[i] = new Frame(_frames[i+1]);
			}
		}

		public bool IsComplete()
		{
			return _frames.All(f => f.IsComplete());
		}

		public void Roll(int number)
		{
			if (IsComplete()) throw new Exceptions();

			var currentFrame = _frames[_frameCount];

			if (currentFrame.IsComplete())
			{
				_frameCount++;
				currentFrame = _frames[_frameCount];
			}

			currentFrame.Add(number);
		}

		public int Score()
		{
			if(!IsComplete()) throw new GameIncompleteException();

			return _frames.Sum((frame) => frame.GetScore());
		}
	}
}
