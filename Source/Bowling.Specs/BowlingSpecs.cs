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
			
			20.times(()=> _game.Roll(0));
		}

		[Specification]
		public void the_score_is_0()
		{
			_game.Score.should_equal(0);
		}
	}

	public class when_rolling_all_score_of_two: concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();

			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_0()
		{
			_game.Score.should_equal(40);
		}
	}
}