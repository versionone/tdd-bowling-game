using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Frame
	{
		public int Score { get; set; }
		public int  Turn { get; set; }
		public bool IsSpare { get; set; }
		public bool IsStrike { get; set; }
		public bool IsClosed { get; set; }



		public int Roll(int pins)
		{
			Score += pins;
			if (Score == 10 && Turn == 1)
			{
				IsStrike = true;
				IsClosed = true;
			}
			else if (Score == 10 && Turn == 2)
			{
				IsSpare = true;
				IsClosed = true;
			}
			else if (Turn == 2)
			{
				IsClosed = true;
			}
			
			return pins;
		}
		
	}
}
