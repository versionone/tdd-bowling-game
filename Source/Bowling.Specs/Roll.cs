using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Specs
{
	public class Roll
	{
		private readonly int _pins;
		private readonly Roll _previousRoll;

		public Roll(int pins, Roll previousRoll)
		{
			_pins = pins;
			_previousRoll = previousRoll;
		}

		public bool IsSpare
		{
			get { return _previousRoll != null && _pins + _previousRoll.Pins == 10; }
		}

		protected int Pins
		{
			get { return _pins; }
		}
	}
}
