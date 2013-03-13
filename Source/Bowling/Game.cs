namespace specs_for_bowling
{
	public class Game
	{
		private int _score = 0;
		private int _currentRoll = 0;
		private readonly int[] _rolls = new int[21];

		public void Roll(int pins)
		{
			_rolls[_currentRoll++] = pins;
		}

		public int Score()
		{
			for (int i = 0; i < _currentRoll; i++)
			{
				if (_rolls[i] + _rolls[i + 1] == 10)
				{
					_score += 10 + _rolls[i + 2];
					i += 1;
				}
				else
				{
					_score += _rolls[i];
				}
			}

			return _score;
		}
	}
}