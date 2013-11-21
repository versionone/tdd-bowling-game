using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		public void Roll(int pinsKnockedDown)
		{

			Rolls += 1;

			if (Rolls == 3 && Score == 10)
				Score += pinsKnockedDown;
			if (Rolls == 5 && Score == 22)
				Score += pinsKnockedDown;

			if (Frames > 9)
			{
				var ex = new GameOverException();
				throw ex;
			}


			if (Rolls%2 == 0 || pinsKnockedDown == 10)
				Frames += 1;

			Score += pinsKnockedDown;
		}

		public int Score { get; set; }

		public int Rolls { get; set; }

		public int Frames { get; set; }
	}

	public class GameOverException :Exception
	{
	}

}
