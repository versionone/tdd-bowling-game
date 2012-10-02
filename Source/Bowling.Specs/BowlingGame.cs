using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Specs
{
	public class BowlingGame
	{
		private int? _score = null;
		public int? Score 
		{ get { return _score; }
		}
		public void Roll(int pins)
		{
			if (!_score.HasValue)
				_score = 0;

			_score += pins;
		}
	}
}
