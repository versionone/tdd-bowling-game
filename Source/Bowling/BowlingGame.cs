using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		public int Score
		{
			get
			{
				int score = 0;
				int frame = 1;
				int ball = 1;
				for(int i = 0; i < _rolls.Count; i++)
				{
					score += _rolls[i];

					if(ball == 1 && _rolls[i] == 10 && frame < 10) // Strike
					{
						score += _rolls[i + 1] + _rolls[i + 2];
					}
					else if (ball == 2 && (_rolls[i - 1] + _rolls[i]) == 10) // Spare
					{
						score += _rolls[i + 1];
					}

					ball++;
					if(ball == 2 && _rolls[i] == 10 || frame < 10 && ball > 2)
					{
						ball = 1;
						frame++;
					}
				}
				return score;
			}
		}

		private List<int> _rolls = new List<int>();

		public void Roll(int pins)
		{
			CheckGameOver();
			UpdateRollsArray(pins);
		}

		private void UpdateRollsArray(int pins)
		{
			_rolls.Add(pins);
		}

		private void CheckGameOver()
		{
			if(_rolls.Count > 19)
				throw new InvalidOperationException("Game Over");
		}
	}
}
