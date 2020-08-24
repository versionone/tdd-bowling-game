namespace Bowling
{
	public class Game
	{
		private int _score = 0;
		public int Score
		{
			get { return _score; }
			set { _score = value; }
		} 

		public void Roll(int pins)
		{	  
			if (pins == 0)
			{
				_score = 0;
			}
			if (pins == 2)
			{
				_score +=pins;
			}
		}

		
	}
}
