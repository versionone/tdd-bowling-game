using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_rolling_all_gutter_balls : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			20.times(() => _game.Roll(0));
		}

		[Specification]
		public void score_is_zero()
		{
			_game.Score().should_equal(0);
		}
	}

	public class when_rolling_all_open_frames : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(3);
			_game.Roll(2);
			_game.Roll(1);
			_game.Roll(3); //2 frames worth

			16.times(() => _game.Roll(0));
		}

		[Specification]
		public void score_is_9()
		{
			_game.Score().should_equal(9);
		}
	}
}