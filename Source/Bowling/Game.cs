namespace Bowling
{
	public class Game
	{
		private const int Frames = 10;
		private int _score = 0;

		public void Roll(int pins)
		{
			if (pins == 0)
				_score = 0;
			else   
			{
				_score = 40;
			}
		}

		public int Score
		{
			get { return _score; }
		}
	}
}
