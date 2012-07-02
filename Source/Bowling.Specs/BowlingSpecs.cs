using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	class when_rolling_all_gutter_balls : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			20.times(() => _game.Roll(0) );
		}

		[Specification]
		public void the_score_should_be_zero()
		{
			_game.Score.should_equal(0);
		}
	}

	class when_rolling_all_ones : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			20.times(() => _game.Roll(1));
		}

		[Specification]
		public void the_score_should_be_twenty()
		{
			_game.Score.should_equal(20);
		}
	}

	class when_rolling_a_spare_then_all_twos : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(8);
			_game.Roll(2); //end of frame 1

			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_should_be_48()
		{
			_game.Score.should_equal(48);
		}
	}

	class when_rolling_two_spares_in_a_row_then_all_twos : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(8);
			_game.Roll(2); //end of frame 1

			_game.Roll(6);
			_game.Roll(4); //end of frame 2

			16.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_should_be_sixty()
		{
			_game.Score.should_equal(60);
		}
	}

	class when_you_have_bowled_10_frames : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();

			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_game_is_complete()
		{
			_game.IsGameComplete.should_be_true();
		}
	}

	class when_you_have_not_bowled_10_frames :concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(1);
			_game.Roll(1);
		
		}

		[Specification]
		public void it_should_not_be_over()
		{
			_game.IsGameComplete.should_be_false();
		}
	}

	class when_the_first_frame_is_a_strike_and_the_rest_are_two : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(10);

			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_should_be_fifty()
		{
			_game.Score.should_equal(50);
		}

		[Specification]
		public void the_game_should_be_complete()
		{
			_game.IsGameComplete.should_be_true();
		}
	}
}