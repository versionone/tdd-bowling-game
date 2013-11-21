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

	public class spare_followed_by_all_ones : concerns<BowlingGame>
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
}