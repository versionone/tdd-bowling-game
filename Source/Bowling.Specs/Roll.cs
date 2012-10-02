using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Specs
{
	public class Roll
	{
		private readonly int _pins;

		public Roll(int pins)
		{
			_pins = pins;
		}

		public int Pins
		{
			get { return _pins; }
		}
	}
}
