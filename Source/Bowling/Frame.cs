using System.Collections.Generic;

namespace Bowling
{
	public class Frame
	{
		public List<int> Rolls = new List<int>();

		public int FirstRoll { get { return Rolls[0]; } }
		public int SecondRoll { get { return Rolls[1]; } }
		public int ThirdRoll { get { return Rolls[2]; } }

		public FrameStatus Status
		{
			get
			{
				if (FirstRoll == 10)
					return FrameStatus.Strike;
				if (FirstRoll + SecondRoll == 10)
					return FrameStatus.Spare;
				return FrameStatus.Simple;
			}
		}

		public Frame() {}

		public void Add(int roll)
		{
			Rolls.Add(roll);
		}

		public Frame(int firstRoll, int secondRoll)
		{
			Add(firstRoll);
			Add(secondRoll);
		}
	}
}