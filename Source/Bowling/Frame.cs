using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Frame
	{
		public Frame()
		{
			Rolls = new List<int>();
		}
		public List<int> Rolls { get; set; }
		public bool IsSpare
		{
			get { return Rolls.Count == 2 && Rolls.Sum()== 10; }
		}

		public bool IsComplete
		{
			get { return Rolls.Count >= 2; }
		}
	}
}
