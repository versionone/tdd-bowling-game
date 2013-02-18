using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	internal class when_rolling_all_gutters : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			
			20.times(() => _game.Roll(0));
		}

		[Specification]
		private void the_score_is_zero()
		{
			_game.Score().should_equal(0);
		}
	}

	internal class when_rolling_all_open_threes : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			20.times(() => _game.Roll(3));
		}

		[Specification]
		private void the_score_is_sixty()
		{
			_game.Score().should_equal(60);
		}
	}
}