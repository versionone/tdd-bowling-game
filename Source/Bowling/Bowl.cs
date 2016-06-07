using System.Collections.Generic;

namespace Bowling
{
	public class Bowl
	{
		public int Score { get; set; }

		public void Roll(int pins = 0)
		{
			Score += pins;
		}

		public void PlayGame(int pins = 0 )
		{
			for (var i = 0; i < 20; i++)
				Roll(pins);

		}

		public void PlayGame(List<int> pins)
		{
			foreach (var i in pins)
			{
				Roll(i);
			}
		}
	
	}
}
