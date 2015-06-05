using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		public int Score { get; private set; }
		private int LastRoll { get; set; }
		private int NumberOfRolls { get; set; }
		private bool PreviousSpare { get; set; }

		public void Roll(int pinsPerRoll)
		{
			Score += (PreviousSpare ? pinsPerRoll * 2 : pinsPerRoll);

			if (NumberOfRolls % 2 == 1 && pinsPerRoll + LastRoll == 10) PreviousSpare = true;
			else PreviousSpare = false;
			LastRoll = pinsPerRoll;
			NumberOfRolls++;
		}
	}
}
