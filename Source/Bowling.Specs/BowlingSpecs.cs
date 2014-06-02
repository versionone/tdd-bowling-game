using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_everything_is_wired_up : concerns
	{
		private bool _itWorked;

		protected override void context()
		{
			_itWorked = true;
		}

		[Specification]
		public void it_works()
		{
			_itWorked.ShouldBeTrue();
		}
	}

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
			_game.Score.ShouldEqual(0);
		}
	}
	public class when_rolling_all_twos : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_forty()
		{
			_game.Score.ShouldEqual(40);
		}
	}

	public class when_rolling_first_two_are_two_rest_are_three : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			2.times(() => _game.Roll(2));
			18.times(()=> _game.Roll(3));
		}

		[Specification]
		public void the_score_is_fifty_eight()
		{
			_game.Score.ShouldEqual(58);
		}
	}
}