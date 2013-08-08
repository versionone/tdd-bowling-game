using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{

		private int _score = 0;
		private int _pinsStanding = 10;
		private int _frameCounter = 1;
		private int _bonuses = 0;

		public void Roll(int pins)
		{
			if (pins == 10)
			{
				_bonuses = 2;
				_frameCounter = 2;

			}

			ScoreRoll(pins);
			ScoreBonus(pins);
			EndOfFrame();
		}

		private void ScoreBonus(int pins)
		{
			if (_bonuses > 0)
			{
				_score += pins;
				_bonuses--;
			}
		}

		private void ScoreRoll(int pins)
		{
			_score += pins;
			_pinsStanding -= pins;
		}

		private void EndOfFrame()
		{
			_frameCounter++;

			if (_frameCounter == 3)
			{
				SetCounters();
			}
		}

		private void SetCounters()
		{
			_frameCounter = 1; //starts the frame
			if (_pinsStanding == 0) //you got them all! you 
			{
				_bonuses = 1;
			}
			_pinsStanding = 10;
		}

		public int Score()
		{
			return _score;
		}

	}
}
