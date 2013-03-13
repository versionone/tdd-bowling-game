namespace Bowling
{
	public class Frame
	{
		public int? FirstRoll { get; private set; }
		public int? SecondRoll { get; private set; }

		public bool IsSpare()
		{
			return FirstRoll != null && SecondRoll != null && (FirstRoll + SecondRoll == 10);
		}

		public bool IsOpen()
		{
			return FirstRoll != null && SecondRoll != null && !IsSpare();
		}

		public bool IsStrike()
		{
			return FirstRoll == 10;
		}

		public bool IsFrameComplete()
		{
			return IsOpen() || IsSpare() || IsStrike();
		}

		public void AddPins(int pins)
		{
			if (FirstRoll == null)
			{
				FirstRoll = pins;
			}
			else
			{
				SecondRoll = pins;
			}
		}
	}
}