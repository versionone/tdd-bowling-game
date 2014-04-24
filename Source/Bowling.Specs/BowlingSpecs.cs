using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_rolling_all_gutter_balls : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			20.times(index => _game.Roll(0));
		}

		[Specification]
		public void the_score_should_be_zero()
		{
			_game.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_twos : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			20.times(index => _game.Roll(2));
		}

		[Specification]
		public void the_score_should_be_fourty()
		{
			_game.Score.ShouldEqual(40);
		}
	}
}