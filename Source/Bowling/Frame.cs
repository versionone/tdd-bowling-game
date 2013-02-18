namespace Bowling
{
	internal class Frame
	{
		protected int? _first;
		protected int? _second;
		protected Frame _nextFrame;

		public Frame(Frame nextFrame)
		{
			_nextFrame = nextFrame;
		}

		protected Frame(){}

		public bool IsStrike()
		{
			return (_first == 10);
		}

		public bool IsSpare()
		{
			return (_first + _second == 10) && (_first != 10);
		}

		public virtual bool IsComplete()
		{
			if (IsStrike())
				return true;
			else
				return (_second != null);
		}

		public virtual void Add(int number)
		{
			if (_first == null)
			{
				_first = number;
			}
			else if (!IsComplete())
			{
				_second = number;
			}
		}

		public virtual int GetScore()
		{
			if (IsSpare())
			{
				return 10 + _nextFrame.GetSpareBonus();
			}
			else if (IsStrike())
			{
				return 10 + _nextFrame.GetStrikeBonus();
			}
			else
			{
				return _first.Value + _second.Value;
			}
		}

		public int GetSpareBonus()
		{
			return _first.Value;
		}

		public virtual int GetStrikeBonus()
		{
			if (IsStrike())
			{
				return 10 + _nextFrame.GetSpareBonus();
			}
			else
			{
				return _first.Value + _second.Value;
			}
		}

	}
}