using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_rolling_all_gutter_balls : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			
			20.times(()=> _game.Roll(0));
		}

		[Specification]
		public void the_score_is_0()
		{
			_game.Score.should_equal(0);
		}
	}

	public class when_rolling_all_score_of_two: concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();

			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_0()
		{
			_game.Score.should_equal(40);
		}
	}

	public class when_rolling_a_spare_then_all_gutters : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();

			_game.Roll(3);
			_game.Roll(7); //spare

			18.times(()=> _game.Roll(0));
		}

		[Specification]
		public void the_score_is_10()
		{
			_game.Score.should_equal(10);
		}
	}

	public class when_rolling_a_spare_then_with_a_bonus : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();

			_game.Roll(3);
			_game.Roll(7); //spare

			_game.Roll(2); //bonus

			17.times(() => _game.Roll(0));
		}

		[Specification]
		public void the_score_is_14()
		{
			_game.Score.should_equal(14);
		}
	}
}