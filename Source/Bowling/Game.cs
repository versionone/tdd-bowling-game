namespace Bowling
{
	public class Game
	{
		private const int Frames = 10;
		private int _score = 0;

		public void Roll(int pins)
		{
			/*if (pins == 0)
				_score = 0;
			else if()
			{
				  _score = 40;
			}*/
			_score += pins;
		}

		public int Score
		{
			get { return _score; }
		}
	}
}
