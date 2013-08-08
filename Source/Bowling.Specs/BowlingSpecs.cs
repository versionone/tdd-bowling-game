using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_rolling_all_gutters :	concerns
	{
		private int _score;

		protected override void context()
		{
			var game = new Game();
			20.times(() => {
				               game.Roll(0);
			});

			_score = game.Score();
		}

		[Specification]
		public void the_score_is_zero()
		{
			_score.should_equal(0);
		}
	}

	public class when_rolling_one_seven : concerns
	{
		private int _score;

		protected override void context()
		{
			var game = new Game();
			19.times(() =>
			{
				game.Roll(0);
			});
			game.Roll(7);
			_score = game.Score();
		}

		[Specification]
		public void the_score_is_seven()
		{
			_score.should_equal(7);
		}
	}


	public class when_rolling_20_ones : concerns
	{
		private int _score;

		protected override void context()
		{
			var game = new Game();
			20.times(() =>
			{
				game.Roll(1);
			});
			_score = game.Score();
		}

		[Specification]
		public void the_score_is_20()
		{
			_score.should_equal(20);
		}
	}


	public class when_rolling_5_then_5_then_5_then_gutters : concerns
	{
		private int _score;

		protected override void context()
		{
			var game = new Game();
			game.Roll(5);
			game.Roll(5);
			game.Roll(5);

			17.times(() =>
			{
				game.Roll(0);
			});
			_score = game.Score();
		}

		[Specification]
		public void the_spare_bonus_is_5()
		{
			_score.should_equal(20);
		}
	}

	public class when_rolling_two_spares_in_a_row : concerns
	{
		private int _score;

		protected override void context()
		{
			var game = new Game();
			game.Roll(4);
			game.Roll(6);
			game.Roll(8);
			game.Roll(2);
			game.Roll(3);
			15.times(() =>
			{
				game.Roll(0);
			});
			_score = game.Score();
		}

		[Specification]
		public void the_score_is_34()
		{
			_score.should_equal(34);
		}
	}


}