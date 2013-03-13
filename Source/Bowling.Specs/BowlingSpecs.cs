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
			_itWorked.should_be_true("we're ready to roll!");
		}
	}

	public class when_rolling_all_gutter_balls : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			20.times(() => _game.Roll(0));
		}

		[Specification]
		public void the_score_is_zero()
		{
			_game.Score().should_equal(0);
		}
	}

	public class when_rolling_all_two_balls : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_40()
		{
			_game.Score().should_equal(40);
		}
	}

	public class when_rolling_a_spare_followed_by_2s : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			_game.Roll(8);
			_game.Roll(2);

			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_48()
		{
			_game.Score().should_equal(48);
		}
	}
}