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

	public class all_gutterballs : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();
			20.times(() => game.Roll(0));
			_score = game.Score;
		}

		[Specification]
		public void score_is_0()
		{
			_score.should_equal(0);
		}
	}

	public class one_pin_per_roll : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();
			20.times(() => game.Roll(1));
			_score = game.Score;
		}

		[Specification]
		public void score_is_20()
		{
			_score.should_equal(20);
		}
	}

	public class spare_followed_by_all_twos : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();
			game.Roll(9);
			game.Roll(1);
			18.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Specification]
		public void score_is_48()
		{
			_score.should_equal(48);
		}
	}


	public class two_spares_followed_by_all_twos : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();
			game.Roll(2);
			game.Roll(8);
			game.Roll(2);
			game.Roll(8);
			16.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Specification]
		public void score_is_56()
		{
			_score.should_equal(56);
		}
	}

	public class spares_followed_by_twos_followed_by_spare_then_all_twos : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();

			game.Roll(2);
			game.Roll(8);

			game.Roll(2);
			game.Roll(2);

			game.Roll(2);
			game.Roll(8);

			14.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Specification]
		public void score_is_56()
		{
			_score.should_equal(56);
		}
	}

	public class game_that_has_ten_completed_frames : concerns<BowlingGame>
	{
		protected override void context()
		{
			var game = build_up();
			20.times(() => game.Roll(0));
		}

		[Specification]
		public void should_not_be_able_to_roll_another_roll()
		{
			typeof(GameOverException).should_be_thrown_by(() => build_up().Roll(0));
		}
	}

	public class steeeeeerike : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();
			game.Roll(10);
			18.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Specification]
		public void score_is_50()
		{
			_score.should_equal(50);
		}
	}

	public class two_strikes_followed_by_all_twos_ : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();

			game.Roll(10);

			game.Roll(10);

			16.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Specification]
		public void score_is_68()
		{
			_score.should_equal(68);
		}
	}

	public class perfect_game : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();

			12.times(() => game.Roll(10));
			_score = game.Score;
		}

		[Specification]
		public void score_is_300()
		{
			_score.should_equal(300);
		}
	}

	public class alternating_strikes_and_spares : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();

			5.times(()=>
			{
				game.Roll(10);

				game.Roll(1);
				game.Roll(9);
			});

			game.Roll(10);

			_score = game.Score;
		}

		[Specification]
		public void score_is_200()
		{
			_score.should_equal(200);
		}
	}

	public class alternating_spares_and_strikes : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();

			5.times(() =>
			{
				game.Roll(1);
				game.Roll(9);

				game.Roll(10);
			});

			game.Roll(1);
			game.Roll(9);

			_score = game.Score;
		}

		[Specification]
		public void score_is_200()
		{
			_score.should_equal(200);
		}
	}
}