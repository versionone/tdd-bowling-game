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
		private readonly Game _game = new Game();

		protected override void context()
		{
			20.times(() => _game.Roll(0));
		}

		[Specification]
		public void the_score_is_zero()
		{
			_game.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_twos: concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_40()
		{
			_game.Score.ShouldEqual(40);
		}
	}

	public class when_rolling_two_twos_followed_by_threes : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			2.times(() => _game.Roll(2));
			18.times(()=> _game.Roll(3));
		}

		[Specification]
		public void the_score_is_58()
		{
			_game.Score.ShouldEqual(58);
		}
	}

	public class when_rolling_alternating_2s_and_5s : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			10.times(() =>
				{
					_game.Roll(2);
					_game.Roll(5);
				});
		}

		[Specification]
		public void the_score_is_70()
		{
			_game.Score.ShouldEqual(70);
		}
	}

	public class when_the_first_frame_is_a_spare_and_the_remaining_rolls_are_all_2s : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			_game.Roll(7);
			_game.Roll(3);

			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_48()
		{
			_game.Score.ShouldEqual(48);
		}
	}

	// when the first 2 frames are spare (as 2,8) and the rest score 2, the score is 56
	public class when_the_first_two_frames_are_spares_followed_by_all_2s : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			_game.Roll(2);
			_game.Roll(8);

			_game.Roll(2);
			_game.Roll(8);

			16.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_56()
		{
			_game.Score.ShouldEqual(56);
		}
	}

	// when 10 frames have been bowled, don't allow any more to be bowled
	public class when_10_frames_have_been_bowled : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_game_is_over()
		{
			typeof (Exception).ShouldBeThrownBy(() => _game.Roll(2));
		}
	}

	//when the first frame is a strike and the rest score 2, the score is 50.
	public class when_the_first_roll_is_a_strike_and_the_remaining_rolls_are_2s : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			_game.Roll(10);
			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_50()
		{
			_game.Score.ShouldEqual(50);
		}
	}

	//when the first two frames are strikes and the rest score 2, the score is 68.
	public class when_the_first_two_rolls_are_strikes_and_the_remaining_rolls_are_2s : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			_game.Roll(10);
			_game.Roll(10);

			16.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_68()
		{
			_game.Score.ShouldEqual(68);
		}
	}
}