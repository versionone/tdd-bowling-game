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
			Score += pinsKnockedDown;
		}

		public int Score { get; private set; }
	}
}
