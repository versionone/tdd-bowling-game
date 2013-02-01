using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		public int Score { get; set; }

		public int Roll(int pins)
		{
			Score += pins;
			return pins;
		}
	}
}
