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
			_itWorked.should_be_true("we're ready to roll!");
		}
	}

	public class when_rolling_all_gutter_balls : concerns
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

	public class when_rolling_twos : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_for_twos()
		{
			_game.Score.should_equal(40);
		}
	}

	public class when_rolling_2s_and_5s : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			10.times(() => { _game.Roll(2); _game.Roll(5); });
		}

		[Specification]
		public void the_score_is_70()
		{
			_game.Score.should_equal(70);
		}
	}
	public class when_spare_and_twos : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			2.times(() => { _game.Roll(5); });
			18.times(() => { _game.Roll(2); });
		}

		[Specification]
		public void the_score_is_48()
		{
			_game.Score.should_equal(48);
		}
	}
	public class when_twos_then_threes : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			2.times(() => { _game.Roll(2); });
			18.times(() => { _game.Roll(3); });
		}

		[Specification]
		public void the_score_is_58()
		{
			_game.Score.should_equal(58);
		}
	}
	public class when_first_two_are_spare_then_twos : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			2.times(() => { _game.Roll(2); _game.Roll(8); });
			16.times(() => { _game.Roll(2); });
		}

		[Specification]
		public void the_score_is_56()
		{
			_game.Score.should_equal(56);
		}
	}

	public class when_10_frames_have_been_rolled : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			20.times(() => { _game.Roll(2); });
		}

		[Specification]
		public void no_more_frames_can_be_bowled()
		{
			typeof(BowlingFrameException).should_be_thrown_by(() => _game.Roll(2));
		}
	}
//
//	public class when_rolling_a_strike_followed_by_all_2s : concerns
//	{
//		private BowlingGame _game;
//
//		protected override void context()
//		{
//			_game = new BowlingGame();
//			_game.Roll(10);
//			18.times(() => { _game.Roll(2); });
//		}
//
//		[Specification]
//		public void the_score_is_50()
//		{
//			_game.Score.should_equal(50);
//		}
//	}
//
//	public class when_rolling_2_strikes_followed_by_all_2s : concerns
//	{
//		private BowlingGame _game;
//
//		protected override void context()
//		{
//			_game = new BowlingGame();
//			_game.Roll(10);
//			_game.Roll(10);
//			16.times(() => { _game.Roll(2); });
//		}
//
//		[Specification]
//		public void the_score_is_68()
//		{
//			_game.Score.should_equal(68);
//		}
//	}
}