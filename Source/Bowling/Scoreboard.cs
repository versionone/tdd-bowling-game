namespace Bowling
{
	public class Scoreboard
	{
		private int _score;

		public void Record(int pins)
		{
			_score += pins;
		}

		public int Score
		{
			get { return _score; }
		}
	}
}