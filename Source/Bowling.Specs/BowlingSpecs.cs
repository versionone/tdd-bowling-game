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

	public class when_rolling_all_gutter_balls : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			20.times(() => _game.Roll(0));
		}

		[Specification]
		public void the_score_should_be_0()
		{
			_game.Score().ShouldEqual(0);
		}
	}

	public class when_always_getting_2 : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_should_be_40()
		{
			_game.Score().ShouldEqual(40);
		}
	}

	public class when_rolling_two_2s_and_then_all_3s : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(2);
			_game.Roll(2);
			18.times(() => _game.Roll(3));
		}

		[Specification]
		public void the_score_should_be_58()
		{
			_game.Score().ShouldEqual(58);
		}
	}

	public class when_rolling_alternating_2s_and_5s : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			10.times(() =>
				{
					_game.Roll(2);
					_game.Roll(5);
				});
		}

		[Specification]
		public void the_score_should_be()
		{
			_game.Score().ShouldEqual(70);
		}
	}

	public class when_rolling_a_spare_followed_by_2s : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();

			_game.Roll(7);
			_game.Roll(3);
	
			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_should_be()
		{
			_game.Score().ShouldEqual(48);
		}
	}

	public class when_rolling_two_spares_followed_by_2s : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();

			_game.Roll(2);
			_game.Roll(8);
			_game.Roll(2);
			_game.Roll(8);

			16.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_should_be()
		{
			_game.Score().ShouldEqual(56);
		}
	}
}