using System;
using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_you_throw_all_gutters : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			10.times(() => _game.RollFrame(0, 0));
		}

		[Specification]
		public void the_score_should_be_zero()
		{
			_game.Score().should_equal(0);
		}
	}

	public class when_you_throw_open_frames_only_scores_should_be_cumulative_of_frames : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			_game.RollFrame(2, 3);

			9.times(() => _game.RollFrame(0, 0));
		}

		[Specification]
		public void the_score_should_equal_five()
		{
			_game.Score().should_equal(5);
		}
	}

	public class when_you_throw_a_spare : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			_game.RollFrame(5, 5);

			_game.RollFrame(3, 0);

			8.times(() => _game.RollFrame(0, 0));
		}

		[Specification]
		public void the_score_is_16()
		{
			_game.Score().should_equal(16);
		}
	}

	public class when_ten_frames_have_been_rolled_game_is_complete : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			10.times(() => _game.RollFrame(0, 0));

		}

		[Specification]
		public void game_is_complete()
		{
			_game.IsComplete.should_be_true();
		}
	}

	public class when_less_than_ten_frames_have_been_rolled : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			9.times(() => _game.RollFrame(0, 0));

		}

		[Specification]
		public void the_game_is_not_complete()
		{
			_game.IsComplete.should_be_false();
		}
	}

	public class when_two_spares_are_rolled : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			_game.RollFrame(5, 5);
			_game.RollFrame(5, 5);
			_game.RollFrame(3, 0);
			7.times(() => _game.RollFrame(0, 0));
		}

		[Specification]
		public void score_should_equal_31()
		{
			_game.Score().should_equal(31);
		}
	}

	public class when_you_a_roll_a_strike_then_an_open_frame_then_gutters : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			_game.RollFrame(10, 0);
			_game.RollFrame(2, 6);

			8.times(() => _game.RollFrame(0, 0));
		}

		[Specification]
		public void the_score_is_26()
		{
			_game.Score().should_equal(26);
		}
	}

	public class when_roll_one_is_rolled_illegally : concerns
	{
		private Game _game;
		Exception _exception = null;

		protected override void context()
		{
			_game = new Game();

			try
			{
				_game.RollFrame(11, 0);
			}
			catch (Exception ex)
			{
				_exception = ex;
			}
		}

		[Specification]
		public void Exception_should_be_thrown()
		{
			_exception.should_not_be_null();
		}

	}

	public class when_roll_two_is_rolled_illegally : concerns
	{
		private Game _game;
		Exception _exception = null;

		protected override void context()
		{
			_game = new Game();

			try
			{
				_game.RollFrame(0, -1);
			}
			catch (Exception ex)
			{
				_exception = ex;
			}
		}

		[Specification]
		public void Exception_should_be_thrown()
		{
			_exception.should_not_be_null();
		}

	}
}