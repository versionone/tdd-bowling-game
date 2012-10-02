using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bowling.Specs;

namespace Bowling
{
	public class Frame
	{
	    private List<Roll> _rolls;
	    public Frame()
	    {
	        _rolls = new List<Roll>();
	    }

		public void AddRoll(Roll roll)
		{
			if(CheckMaxAllowedRollRule())
				_rolls.Add(roll);
			else
				throw new MaxAllowedRollsExceededException();
		}

		public bool IsComplete
		{
			get { return _rolls.Count >= 2; }
		}

		public IEnumerable<Roll> Rolls
		{
			get { return _rolls; }
		}

		private bool CheckMaxAllowedRollRule()
		{
			return _rolls.Count < 2;
		}

		public bool IsSpare
		{
			get { return IsComplete && _rolls.Sum(roll => roll.Pins) == 10; }
		}

	}
}
