using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Bowling
{
	
	public class BowlingGame
	{
		private List<int> _rolls = new List<int>();
		public void Roll(int pins)
		{
			_rolls.Add(pins);
		}

		public int GetScore()
		{
			return _rolls.Sum();
		}
	}
}