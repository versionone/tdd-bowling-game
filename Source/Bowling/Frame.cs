using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class Frame
	{
		public List<int> Rolls = new List<int>();

		public int FirstRoll { get { return Rolls[0]; } }

		public bool Closed;

		public Frame() {}

		public void Add(int roll)
		{
			if (!Closed)
			{
				Rolls.Add(roll);
				if (Rolls.Count == 3 || (Rolls.Count == 2 && Rolls.Sum() < 10))
				{
					Closed = true;
				}
			}
		}

		public int FrameTotal()
		{
			return Rolls.Sum();
		}

		public Frame(int firstRoll, int secondRoll)
		{
			Add(firstRoll);
			Add(secondRoll);
		}
	}
}