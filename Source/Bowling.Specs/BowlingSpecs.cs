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
			20.times(() => _game.Roll(0));
		}

		[Specification]
		public void score_is_zero()
		{
			_game.Score().should_equal(0);
		}
	}

	public class when_rolling_all_open_frames : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(3);
			_game.Roll(2);

			_game.Roll(1);
			_game.Roll(3); //2 frames worth

			16.times(() => _game.Roll(0));
		}

		[Specification]
		public void score_is_9()
		{
			_game.Score().should_equal(9);
		}
	}

	public class when_rolling_a_spare : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(3);
			_game.Roll(7); //spare
			
			_game.Roll(4); //spare bonus
			_game.Roll(3); 

			16.times(() => _game.Roll(0));
		}

		[Specification]
		public void score_is_21()
		{
			_game.Score().should_equal(21);
		}
	}

	public class when_rolling_a_spare_frame : concerns
	{
		private BowlingFrame _frame;
		private BowlingFrame _nextFrame;

		protected override void context()
		{
			_frame = new BowlingFrame();
			_frame.Roll1 = 3;
			_frame.Roll2 = 7;

			_nextFrame = new BowlingFrame();
			_nextFrame.Roll1 = 1;
		}

		[Specification]
		public void score_is_11()
		{
			_frame.CalculateScore(_nextFrame).should_equal(11);
		}

		[Specification]
		public void frame_is_spare()
		{
			_frame.IsSpare().should_be_true();
		}

		[Specification]
		public void frame_is_not_strike()
		{
			_frame.IsStrike().should_be_false();	
		}

		[Specification]
		public void frame_is_complete()
		{
			_frame.IsComplete().should_be_true();
		}
	}

	public class when_rolling_a_strike_frame : concerns
	{
		private BowlingFrame _frame;

		protected override void context()
		{
			_frame = new BowlingFrame();
			_frame.Roll1 = 10;
		}

		[Specification]
		public void frame_is_strike()
		{
			_frame.IsStrike().should_be_true();
		}

		[Specification]
		public void frame_is_not_spare()
		{
			_frame.IsSpare().should_be_false();
		}

		[Specification]
		public void frame_is_complete()
		{
			_frame.IsComplete().should_be_true();
		}
	}

	public class when_rolling_an_open_frame : concerns
	{
		private BowlingFrame _frame;

		protected override void context()
		{
			_frame = new BowlingFrame();
			_frame.Roll1 = 3;
			_frame.Roll2 = 5;
		}

		[Specification]
		public void score_is_8()
		{
			_frame.CalculateScore(null).should_equal(8);
		}

		[Specification]
		public void frame_is_not_a_strike()
		{
			_frame.IsStrike().should_be_false();
		}

		[Specification]
		public void frame_is_not_a_spare()
		{
			_frame.IsSpare().should_be_false();
		}

		[Specification]
		public void frame_is_complete()
		{
			_frame.IsComplete().should_be_true();
		}
	}

	public class when_rolling_an_incomplete_frame : concerns
	{
		private BowlingFrame _frame;

		protected override void context()
		{
			_frame = new BowlingFrame();
			_frame.Roll1 = 3;
		}

		[Specification]
		public void score_is_3()
		{
			_frame.CalculateScore(null).should_equal(3);
		}

		[Specification]
		public void frame_is_not_a_strike()
		{
			_frame.IsStrike().should_be_false();
		}

		[Specification]
		public void frame_is_not_a_spare()
		{
			_frame.IsSpare().should_be_false();
		}

		[Specification]
		public void frame_is_not_complete()
		{
			_frame.IsComplete().should_be_false();
		}
	}

	public class when_rolling_two_spare : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(3);
			_game.Roll(7); //spare 10+4 (14)

			_game.Roll(4); //spare bonus
			_game.Roll(6); //spare 10+3 (27)

			_game.Roll(3); //(30)
			
			15.times(() => _game.Roll(0));
		}

		[Specification]
		public void score_is_30()
		{
			_game.Score().should_equal(30);
		}
	}

}