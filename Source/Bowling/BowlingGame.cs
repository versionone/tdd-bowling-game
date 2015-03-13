namespace Bowling
{
	class BowlingGame
	{
		private int _totalPins;

		internal void Roll(int pins)
		{
			_totalPins += pins;
		}

		internal int GetScore()
		{
			return _totalPins;
		}
	}
}
