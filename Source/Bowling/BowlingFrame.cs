using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingFrame
	{
		#region Properties
		public int? Roll1 { get; set; }

		public int? Roll2 { get; set; }	
		#endregion

		#region Methods
		public bool IsComplete()
		{
			if (!Roll1.HasValue)
				return false;
			else if (Roll1.Value == 10)
				return true;
			else 
				return Roll2.HasValue;
		}

		public bool IsSpare()
		{
			return Roll1.GetValueOrDefault() != 10 &&
				   Roll1.GetValueOrDefault() + Roll2.GetValueOrDefault() == 10;
		}

		public bool IsStrike()
		{
			return Roll1.GetValueOrDefault() == 10;
		}
		#endregion
	}
}
