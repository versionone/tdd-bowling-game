using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Frame
	{
		public int? FirstRoll { get; set; }
		public int? SecondRoll { get; set; }

		public int GetTotalScore()
		{
			return FirstRoll.GetValueOrDefault() + SecondRoll.GetValueOrDefault();
		}
	}
}
