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
			20.times(() => _game.Roll(0));
		}

		[Specification]
		public void the_score_is_zero()
		{
			_game.GetScore().ShouldEqual(0);
		}
	}

	public class when_rolling_all_2s : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_40()
		{
			_game.GetScore().ShouldEqual(40);
		}
	}
}