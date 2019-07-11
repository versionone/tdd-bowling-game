namespace Bowling
{
	public class Game
	{
		private int _score;

		public void Roll(int pins)
		{
			_score += pins;
		}

		public int GetScore()
		{
			return _score;
		}
	}
}
