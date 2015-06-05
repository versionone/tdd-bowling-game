using System;
using System.Security.Policy;
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

	public class when_rolling_all_gutter_ball : concerns
	{
		Game game = new Game();
		
		protected override void context()
		{
			for (int i = 0; i < 20; i++)
			{
				game.Roll(0);
			}
		}

		[Specification]
		public void then_the_score_is_0()
		{
			game.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_twos : concerns
	{
		Game game = new Game();

		protected override void context()
		{
			for (int i = 0; i < 20; i++)
			{
				game.Roll(2);
			}
		}

		[Specification]
		public void then_the_score_is_40()
		{
			game.Score.ShouldEqual(40);
		}
	}

	public class when_the_first_two_are_2_and_the_rest_are_3 : concerns
	{
		Game game = new Game();

		protected override void context()
		{
			for (int i = 0; i < 20; i++)
			{
				game.Roll((i < 2 ? 2 : 3));
			}
		}

		[Specification]
		public void then_the_score_is_58()
		{
			game.Score.ShouldEqual(58);
		}
	}

	public class when_alternating_twos_and_fives : concerns
	{
		Game game = new Game();

		protected override void context()
		{
			for (int i = 0; i < 20; i++)
			{
				game.Roll((i % 2 == 0 ? 2 : 5));
			}
		}

		[Specification]
		public void then_the_score_is_70()
		{
			game.Score.ShouldEqual(70);
		}
	}

	public class when_The_first_frame_is_a_spare_and_the_remaining_frames_are_twos : concerns
	{
		Game game = new Game();

		protected override void context()
		{
			game.Roll(5);
			game.Roll(5);
			for (int i = 0; i < 18; i++)
			{
				game.Roll(2);
			}
		}

		[Specification]
		public void then_the_score_is_48()
		{
			game.Score.ShouldEqual(48);
		}
	}

	public class when_The_first_two_frames_are_spares_and_the_remaining_frames_are_twos : concerns
	{
		Game game = new Game();

		protected override void context()
		{
			game.Roll(2);
			game.Roll(8);
			game.Roll(2);
			game.Roll(8);
			for (int i = 0; i < 16; i++)
			{
				game.Roll(2);
			}
		}

		[Specification]
		public void then_the_score_is_56()
		{
			game.Score.ShouldEqual(56);
		}
	}

	public class when_rolling_more_frames_than_allowed : concerns
	{
		Game game = new Game();

		protected override void context()
		{
			for (int i = 0; i < 20; i++)
			{
				game.Roll(2);
			}
		}

		[Specification]
		public void then_the_an_exception_is_thrown()
		{
			typeof (Exception).ShouldBeThrownBy(()=>game.Roll(2));
		}
	}

	public class when_The_first_frame_is_a_strike_and_the_remaining_frames_are_twos : concerns
	{
		Game game = new Game();

		protected override void context()
		{
			game.Roll(10);
			for (int i = 0; i < 18; i++)
			{
				game.Roll(2);
			}
		}

		[Specification]
		public void then_the_score_is_50()
		{
			game.Score.ShouldEqual(50);
		}
	}



	/*
* when rolling all gutter balls, the score is 0.
* when rolling all 2s, the score is 40.
* when the first 2 rolls are 2 and the rest are 3, the score is 58.
* when rolling alternating 2s and 5s, the score 70.
* when the first frame is a spare and the remaining rolls are all 2, the score is 48.
* when the first 2 frames are spare (as 2,8) and the rest score 2, the score is 56.
* when 10 frames have been bowled, don't allow any more to be bowled.
* when the first frame is a strike and the rest score 2, the score is 50.
* when the first 2 frames are strikes and the rest score 2, the score is 68.
* when rolling a perfect game, the score is 300.
* when rolling alternate strikes and spares, the score is 200.
	 */
}