using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Specs
{
	public class BowlingGame
	{
		public BowlingGame()
		{
				_rolls = new List<Roll>();
		}
		private int? _score = null;
		private List<Roll> _rolls; 
		public int? Score 
		{ 
			get { return _score; }
		}
		
		public void Roll(int pins)
		{
			if (!_score.HasValue)
				_score = 0;

			Roll roll;

			if(_rolls.Count==0)
				roll = new Roll(pins, null);
			else
				roll = new Roll(pins, _rolls.Last());

			if (_rolls.Count > 0 && _rolls.Last().IsSpare)
			{
				_score += pins;
			}

			_rolls.Add(roll);

			_score += pins;
		}

	}
}
