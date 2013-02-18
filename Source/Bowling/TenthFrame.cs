namespace Bowling
{
	internal class TenthFrame : Frame
	{
		private int? _third;

		public TenthFrame() {}

		public override bool IsComplete()
		{
			if (IsStrike() || IsSpare())
			{
				return (_third != null);
			}
			else
			{
				return (_second != null);
			}
		}

		public override void Add(int number)
		{
			if (_first == null)
			{
				_first = number;
			}
			else if (_second == null)
			{
				_second = number;
			}
			else if (!IsComplete())
			{
				_third = number;
			}
		}

		public override int GetScore()
		{
			return _first.Value + _second.Value + (_third ?? 0);
		}

		public override int GetStrikeBonus()
		{
			return _first.Value + _second.Value;
		}
	}
}