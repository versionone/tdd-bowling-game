using System;
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
			_itWorked.ShouldBeTrue();
		}
	}

	public class when_rolling_all_gutter_balls : concerns
	{
		private Game _game;
		protected override void context()
		{
			_game = new Game();
			for (int i = 1; i <= 20; i++)
			{
				_game.Roll(0);
			}
		}

		[Specification]
		public void the_score_is_zero()
		{
			_game.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_2s : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			for (int i = 1; i <= 20; i++)
			{
				_game.Roll(2);
			}
		}

		[Specification]
		public void the_score_is_40()
		{
			_game.Score.ShouldEqual(40);
		}
	}


	public class when_first_two_rolls_are_twos_and_the_rest_are_threes : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			_game.Roll(2);
			_game.Roll(2);
			for (int i = 1; i <= 18; i++)
			{
				_game.Roll(3);
			}
		}

		[Specification]
		public void the_score_is_58()
		{
			_game.Score.ShouldEqual(58);
		}
	}

	public class when_rolling_alternating_2s_and_5s : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			for (int i = 1; i <= 10; i++)
			{
				_game.Roll(2);
				_game.Roll(5);
			}
		}	

		[Specification]
		public void the_score_is_70()
		{
			_game.Score.ShouldEqual(70);
		}
	}

	public class when_first_frame_is_spare_and_remaining_are_all_2s : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			_game.Roll(5);
			_game.Roll(5);
			for (int i = 1; i <= 18; i++)
			{
				_game.Roll(2);
			}
		}	

		[Specification]
		public void the_score_is_48()
		{
			_game.Score.ShouldEqual(48);
		}
	}

	public class when_first_two_frame_are_spare_two_and_eight_and_remaining_are_all_2s : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			_game.Roll(2);
			_game.Roll(8);
			_game.Roll(2);
			_game.Roll(8);
			for (int i = 1; i <= 16; i++)
			{
				_game.Roll(2);
			}
		}	

		[Specification]
		public void the_score_is_56()
		{
			_game.Score.ShouldEqual(56);
		}
	}

	public class when_ten_frames_have_been_bowled : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			for (int i = 1; i <= 20; i++)
			{
				_game.Roll(2);
			}
		}	

		[Specification]
		public void dont_allow_any_more_to_be_bowled()
		{
			typeof (Exception).ShouldBeThrownBy(() => _game.Roll(2))
				.Message.ShouldEqual("Game Over");
		}
	}

	public class when_first_frame_is_stike_and_rest_are_2s : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			_game.Roll(10);
			for (int i = 1; i <= 18; i++)
			{
				_game.Roll(2);
			}
		}	

		[Specification]
		public void the_score_is_50()
		{
			_game.Score.ShouldEqual(50);
		}
	}

}