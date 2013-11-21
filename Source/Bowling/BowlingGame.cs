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

			if (Rolls == 2 && Score == 10)
				Score += pinsKnockedDown;

			Score += pinsKnockedDown;

			Rolls += 1;
		}

		public int Score { get; set; }

		public int Rolls { get; set; }
	}
}
