namespace Bowling
{
	public class Frame
	{
		public int FirstRoll;
		public int SecondRoll;

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

		public Frame(int firstRoll, int secondRoll)
		{
			FirstRoll = firstRoll;
			SecondRoll = secondRoll;
		}
	}
}