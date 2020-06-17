namespace Bowling
{
	public class Game
	{
		public int Score { get; set; }
		public Game()
		{

		}

		public void roll(int pinsHit)
		{
			this.Score += pinsHit;
		}
	}
}
