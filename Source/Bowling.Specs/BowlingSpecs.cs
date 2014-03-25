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
			_itWorked.should_be_true("we're ready to roll!");
		}
	}

	public class when_rolling_all_gutter_balls : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			20.times(() => _game.Roll(0));
		}

		[Specification]
		public void the_score_is_zero()
		{
			_game.Score().should_equal(0);
		}
	}

	public class when_rolling_all_twos : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_forty()
		{
			_game.Score().should_equal(40);
		}
	}

	public class when_rolling_alternating_2s_and_5s : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			10.times(() => { _game.Roll(2); _game.Roll(5);});
		}

		[Specification]
		public void the_score_is_70()
		{
			_game.Score().should_equal(70);
		}
	}

	public class when_rolling_spare_plus_2s : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(7);
			_game.Roll(3);
			18.times(() => _game.Roll(2) );
		}

		[Specification]
		public void the_score_is()
		{
			_game.Score().should_equal(48);
		}
	}

	public class when_rolling_pair_of_2s_then_3s : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			2.times(() => _game.Roll(2));
			18.times(() => _game.Roll(3));
		}

		[Specification]
		public void the_score_is()
		{
			_game.Score().should_equal(58);
		}
	}
}