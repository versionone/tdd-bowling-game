using Bowling;
using Bowling.Specs.Infrastructure;
using specs_for_bowling;

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
			_game.Score().should_equal(0);
		}
	}

	public class when_rolling_all_two_balls : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_40()
		{
			_game.Score().should_equal(40);
		}
	}

	public class when_rolling_a_spare_followed_by_all_2s : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			_game.Roll(8);
			_game.Roll(2);

			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_48()
		{
			_game.Score().should_equal(48);
		}
	}

	public class when_rolling_two_balls_spanning_two_frames_that_would_have_equaled_a_spare : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			_game.Roll(1);
			_game.Roll(8);

			_game.Roll(2);
			_game.Roll(2);

			16.times(() => _game.Roll(0));
		}

		[Specification]
		public void the_score_is_13()
		{
			_game.Score().should_equal(13);
		}
	}

	public class when_rolling_two_spares_followed_by_all_2s : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			_game.Roll(8);
			_game.Roll(2); // 18

			_game.Roll(8);
			_game.Roll(2); // 12

			16.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_62()
		{
			_game.Score().should_equal(62);
		}
	}

	public class when_rolling_a_strike_followed_by_all_2s : concerns
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
			_game.Score().should_equal(50);
		}
	}

	public class when_rolling_two_strikes_followed_by_all_2s : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			_game.Roll(10); // 22
			_game.Roll(10); // 14

			16.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_68()
		{
			_game.Score().should_equal(68);
		}
	}

	public class when_rolling_a_perfect_game : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			12.times(() => _game.Roll(10));
		}

		[Specification]
		public void the_score_is_300()
		{
			_game.Score().should_equal(300);
		}
	}

	public class when_rolling_a_dutch_game : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			5.times(() =>
			        	{
			        		_game.Roll(10);

			        		_game.Roll(2);
			        		_game.Roll(8);
			        	});
			_game.Roll(10);
		}

		[Specification]
		public void the_score_is_200()
		{
			_game.Score().should_equal(200);
		}
	}

	public class when_ending_with_a_spare : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			9.times(() =>
			{
				_game.Roll(0);
				_game.Roll(0);
			});

			_game.Roll(8);
			_game.Roll(2);
			_game.Roll(2);
		}

		[Specification]
		public void the_score_is_12()
		{
			_game.Score().should_equal(12);
		}
	}

}

namespace specs_for_frames
{
	public class when_the_sum_of_firstRoll_and_secondRoll_equals_ten : concerns
	{
		private readonly Frame _frame = new Frame();

		protected override void context()
		{
			_frame.AddPins(8);
			_frame.AddPins(2);
		}

		[Specification]
		public void frame_is_spare()
		{
			_frame.IsSpare().should_equal(true);
		}

		[Specification]
		public void frame_is_not_open()
		{
			_frame.IsOpen().should_equal(false);
		}
	}

	public class when_the_sum_of_firstRoll_and_secondRoll_is_less_than_ten : concerns
	{
		private readonly Frame _frame = new Frame();

		protected override void context()
		{
			_frame.AddPins(8);
			_frame.AddPins(1);
		}

		[Specification]
		public void frame_is_open()
		{
			_frame.IsOpen().should_equal(true);
		}

		[Specification]
		public void frame_is_not_spare()
		{
			_frame.IsSpare().should_equal(false);
		}
	}

	public class when_the_first_roll_is_a_ten : concerns
	{
		private readonly Frame _frame = new Frame();

		protected override void context()
		{
			_frame.AddPins(10);
		}

		[Specification]
		public void frame_is_strike()
		{
			_frame.IsStrike().should_equal(true);
		}

		[Specification]
		public void frame_is_complete()
		{
			_frame.IsFrameComplete().should_equal(true);
		}

		[Specification]
		public void frame_is_not_open()
		{
			_frame.IsOpen().should_equal(false);
		}

		[Specification]
		public void frame_is_not_spare()
		{
			_frame.IsSpare().should_equal(false);
		}
	}
}