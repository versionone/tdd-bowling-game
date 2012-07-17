using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_you_throw_all_gutters : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			20.times(()=> _game.Roll(0));
		}

		[Specification]
		public void the_score_should_be_zero()
		{
			_game.Score().should_equal(0);
		}
	}

	public class Game
	{
		public int Score()
		{
			return 0;
		}

		public void Roll(int numberOfPinsKnockedDown)
		{
		}
	}
}