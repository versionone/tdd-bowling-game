using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class Frame
	{
		public List<int> Rolls = new List<int>();

		public int FirstRoll { get { return Rolls[0]; } }

		public FrameStatus Status
		{
			get
			{
				if (Rolls.Count == 0 || (FirstRoll < 10 && Rolls.Count == 1))
					return FrameStatus.Open;
				if (FirstRoll == 10)
					return FrameStatus.Strike;
				if (FrameTotal() == 10)
					return FrameStatus.Spare;
				return FrameStatus.Simple;
			}
		}

		public Frame() {}

		public void Add(int roll)
		{
			Rolls.Add(roll);
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