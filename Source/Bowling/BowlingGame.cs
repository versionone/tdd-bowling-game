namespace Bowling
{
	public class BowlingGame
	{
		private int _totalPins;

		public void Roll(int pins)
		{
			_totalPins += pins;
		}

		public int GetScore()
		{
			return _totalPins;
		}
	}
}
