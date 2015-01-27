using Bowling.Specs.Infrastructure;
using Bowling;

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
		private int _score;

		protected override void context()
		{
			var game = new BowlingGame();
			20.times(() => game.Roll(0));
			_score = game.Score;
		}

		[Specification]
		public void the_score_is_0()
		{
			_score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_twos : concerns
	{
		private int _score;

		protected override void context()
		{
			var _game = new BowlingGame();
			20.times(() => _game.Roll(2));
			_score = _game.Score;
		}

		[Specification]
		public void the_score_is_40()
		{
			_score.ShouldEqual(40);
		}
	}

	public class when_the_first_2_rolls_are_2_and_the_rest_are_3 : concerns
	{
		private int _score;

		protected override void context()
		{
			var _game = new BowlingGame();
			2.times(() => _game.Roll(2));
			18.times(() => _game.Roll(3));
			_score = _game.Score;
		}

		[Specification]
		public void the_score_is_58()
		{
			_score.ShouldEqual(58);
		}
	}
}