using System.Collections.Generic;

namespace Bowling
{
	public class Game
	{
		public int Score { get; set; }
		private bool lastFrameWasSpare = false;
		
		public Game()
		{

		}

		public void RollFrame(int firstRoll, int secondRoll)
		{
			if (lastFrameWasSpare)
			{
				Roll(firstRoll);
			}
			Roll(firstRoll);
			Roll(secondRoll);


			lastFrameWasSpare = this.IsSpare(firstRoll, secondRoll);

		}

		private void Roll(int pinsHit)
		{
			this.Score += pinsHit;
		}

		private bool IsSpare(int firstRoll, int secondRoll)
		{
			return firstRoll + secondRoll == 10;
		}
	}
}
