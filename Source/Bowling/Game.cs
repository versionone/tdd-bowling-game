using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		public int Score { get; private set; }

		public void Roll(int pinsPerRoll)
		{
			Score += pinsPerRoll;
		}
	}
}
