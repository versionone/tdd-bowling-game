using Bowling;
using Bowling.Specs.Infrastructure;
using Gallio.Framework.Assertions;
using NUnit.Framework;

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
		private Game game;
		protected override void context()
		{
			game = new Game();

			for (int i = 0; i < 20; i++)
			{
				game.roll(0);
			}
		}

		[Specification]
		public void the_score_is_0()
		{
			// assert that the score is 0
			game.GetScore().ShouldEqual(0);
		}
	}

	public class when_rolling_all_2s : concerns
	{
		private Game game;
		protected override void context()
		{
			game = new Game();

			for (int i = 0; i < 20; i++)
			{
				game.roll(2);	
			}
		}

		[Specification]
		public void the_score_is_40()
		{
			game.GetScore().ShouldEqual(40);
		}
	}

	public class when_the_first_2_rolls_are_2_and_the_rest_are_3 : concerns
	{
		private Game game;
		protected override void context()
		{
			game = new Game();

			game.roll(2);
			game.roll(2);
			for (int i = 0; i < 18; i++)
			{
				game.roll(3);
			}
		}

		[Specification]
		public void the_score_is_58()
		{
			game.GetScore().ShouldEqual(58);
		}
	}

	public class when_rolling_alternating_2s_and_5s : concerns
	{
		private Game game;
		protected override void context()
		{
			game = new Game();

			for (int i = 0; i < 10; i++)
			{
				game.roll(2);
				game.roll(5);
			}
		}

		[Specification]
		public void the_score_is_70()
		{
			game.GetScore().ShouldEqual(70);
		}
	}

	public class when_the_first_frame_is_a_spare_and_the_remaining_rolls_are_all_2 : concerns
	{
		private Game game;
		protected override void context()
		{
			game = new Game();

			game.roll(5);
			game.roll(5);

			for (int i = 0; i < 18; i++)
			{
				game.roll(2);
			}
		}

		[Specification]
		public void the_score_is_48()
		{
			game.GetScore().ShouldEqual(48);
		}
	}

	public class when_the_first_2_frames_are_spare_and_the_rest_score_2 : concerns
	{
		private Game game;
		protected override void context()
		{
			game = new Game();

			game.roll(2);
			game.roll(8);
			game.roll(2);
			game.roll(8);

			for (int i = 0; i < 16; i++)
			{
				game.roll(2);
			}
		}

		[Specification]
		public void the_score_is_56()
		{
			game.GetScore().ShouldEqual(56);
		}
		
	}

	public class when_10_frames_have_been_bowled : concerns
	{
		private Game game;
		protected override void context()
		{
			game = new Game();

			game.roll(2);
			game.roll(8);
			game.roll(2);
			game.roll(8);

			for (int i = 0; i < 16; i++)
			{
				game.roll(2);
			}
		}

		[Specification]
		[ExpectedException]
		public void dont_allow_any_more_to_be_bowled()
		{
			game.roll(3);
		}

	}

	/*
*_when_the_first_2_frames_are_spare_(as_28)_and_the_rest_score_2_the_score_is_56.
*_when_10_frames_have_been_bowled_don't_allow_any_more_to_be_bowled.
*_when_the_first_frame_is_a_strike_and_the_rest_score_2_the_score_is_50.
*_when_the_first_2_frames_are_strikes_and_the_rest_score_2_the_score_is_68.
*_when_rolling_a_perfect_game_the_score_is_300.
*_when_rolling_alternate_strikes_and_spares_the_score_is_200._
	 */
}