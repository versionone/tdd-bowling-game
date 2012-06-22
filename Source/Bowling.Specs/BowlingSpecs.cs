using Bowling;
using Bowling.Specs.Infrastructure;
using MbUnit.Framework;

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

	public class when_the_game_starts : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
		}

		[Specification]
		public void the_score_is_zero()
		{
			_game.Score.should_equal(0);
		}
	}

	public class when_i_roll_two_gutter_balls : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(0);
			_game.Roll(0);
		}

		[Specification]
		public void the_score_is_zero()
		{
			_game.Score.should_equal(0);
		}
	}

	public class when_i_knock_down_5_pins : concerns
	{
		private BowlingGame _game;

		private const int pins = 5;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(pins);
		}

		[Specification]
		public void the_score_is_5()
		{
			_game.Score.should_equal(pins);
		}
	}

	public class when_i_knock_down_a_5_and_a_4 : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(5);
			_game.Roll(4);
		}

		[Specification]
		public void the_score_is_9()
		{
			_game.Score.should_equal(9);
		}
	}

	public class when_i_knock_down_a_5_and_a_4_and_a_9 : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(5);
			_game.Roll(4);
			_game.Roll(9);
		}

		[Specification]
		public void the_score_is_18()
		{
			_game.Score.should_equal(18);
		}
	}

	public class when_i_knock_down_a_5_and_a_5_and_a_9 : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(5);
			_game.Roll(5); // 19
			_game.Roll(9); // 9 = 28
		}

		[Specification]
		public void the_score_is_28()
		{
			_game.Score.should_equal(28);
		}
	}

	public class when_first_frame_is_spare_and_all_subsequent_frames_are_4 : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(5);
			_game.Roll(5);
			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_48()
		{
			_game.Score.should_equal(48);
		}
	}

	public class when_first_two_frames_are_spares_and_all_subsequent_frames_are_4 : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			4.times(() => _game.Roll(5));
			16.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_59()
		{
			_game.Score.should_equal(59);
		}
	}

	public class when_the_first_fame_is_a_strike_and_all_subsequent_rolls_are_2 : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(10);
			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_50()
		{
			_game.Score.should_equal(50);
		}


		[Specification]
		[ExpectedException(typeof(GameOverException))]
		public void cannot_roll_any_more()
		{
			_game.Roll(8);
		}
	}

	public class when_rolling_all_strikes : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			12.times(() => _game.Roll(10));
		}

		[Specification]
		public void the_score_is_300()
		{
			_game.Score.should_equal(300);
		}

		[Specification]
		[ExpectedException(typeof(GameOverException))]
		public void cannot_roll_any_more()
		{
			_game.Roll(8);
		}
	}

	public class when_ten_frames_are_bowled : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();

			20.times(() => _game.Roll(4));
		}

		[Specification]
		public void game_is_over()
		{
			_game.IsOver.should_be_true();
		}

		[Specification]
		[ExpectedException(typeof(GameOverException))]
		public void cannot_roll_any_more()
		{
			_game.Roll(8);
		}
	}
}