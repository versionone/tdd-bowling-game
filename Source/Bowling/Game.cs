using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private List<List<int>> _frames = new List<List<int>>();
		private int _currentFrameIndex = 0;
		private int _currentRoll = 1;
		private int _score = 0;

		public Game()
		{
			_frames.Add(new List<int>());
		}

		public int Score
		{
			get
			{
				var score = 0;
				for (int i = 0; i < _frames.Count; i++)
					for (int j = 0; j < _frames[i].Count; j++)
						score += _frames[i][j];
				return score;
			}
		}

		public bool IsGameOver
		{
			get { return _frames.Count == 10; }
		}

		public void Roll(int pins)
		{
			_score += pins;
			_frames[_currentFrameIndex].Add(pins);

			if (_currentRoll == 1 && _currentFrameIndex > 0)
			{
				if (_frames[_currentFrameIndex - 1][0] == 10 || 
					((_frames[_currentFrameIndex - 1][0] + _frames[_currentFrameIndex - 1][1]) == 10)
					)
				{
					_frames[_currentFrameIndex - 1].Add(pins);
					if (_frames[_currentFrameIndex - 1][0] == 10)
						if ((_currentFrameIndex - 2) >= 0)
						{
							if (_frames[_currentFrameIndex - 2][0] == 10)
								_frames[_currentFrameIndex - 2].Add(pins);
						}
				}
			}
			else if (_currentRoll == 2 && _currentFrameIndex > 0)
			{
				if (_frames[_currentFrameIndex - 1][0] == 10)
				{
					if ((_currentFrameIndex - 2) >= 0 && _frames.Count == 10 && pins == 10)
						if (_frames[_currentFrameIndex - 2].Sum() < 30 && _frames[_currentFrameIndex - 1][0] == 10)
							_frames[_currentFrameIndex - 2].Add(pins);
					int sum = 0;
					for (int i1 = 0; i1 < _frames[_currentFrameIndex - 1].Count; i1++)
					{
						int i = _frames[_currentFrameIndex - 1][i1];
						sum += i;
					}
					if (sum < 30)
						_frames[_currentFrameIndex - 1].Add(pins);
				}
			}
			
			if ((_currentRoll == 2 || pins == 10) && _frames.Count != 10) //max number of valid rolls for each frame
			{
				_score = 0;
				_currentRoll = 1;
				if (!IsGameOver)
					_frames.Add(new List<int>());
				_currentFrameIndex = _frames.Count - 1;
			}
			else
				_currentRoll++;
		}
	}
}
