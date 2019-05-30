namespace Bowling
{
	public class Game
	{
		private int _score;

		public void Roll(int pins)
		{
			_score += pins;
		}

		public int Score
		{
			get { return _score; }
		}
	}
}
