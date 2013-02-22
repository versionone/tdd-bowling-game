namespace Bowling
{
	public class Frame : IFrame
	{
		public Frame NextFrame;
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

		public int Score()
		{
			int score = 0;
			if (FirstRoll == 10 && NextFrame != null)
			{
				score += NextFrame.FirstRoll + NextFrame.SecondRoll;
			}
			else if (FirstRoll + SecondRoll == 10 && NextFrame != null)
			{
				score += NextFrame.FirstRoll;
			}

			return FirstRoll + SecondRoll + score;
		}
	}
}