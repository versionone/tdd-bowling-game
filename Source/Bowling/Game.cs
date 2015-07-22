using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		public List<Frame> Frames { get; set; }

		public void Roll(int pins)
		{
			Score += pins; 
		}

		public int Score { get; private set; }

	}
}
