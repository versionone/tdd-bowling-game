using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Bowling
{
	public class Bowl
	{
		public int Score { get; set; }

		public int Roll()
		{
			return 0;
		}

		public void PlayGame()
		{
			for (var i = 0; i < 10; i++)
				Roll();

		}
	}
}
