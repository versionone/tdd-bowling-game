using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_frames
{

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

	public class when_rolling_a_strike_and_open_frame : concerns
	{
		private BowlingFrame _frame;
		private BowlingFrame _nextFrame;

		protected override void context()
		{
			_frame = new BowlingFrame();
			_frame.Roll1 = 10;

			_nextFrame = new BowlingFrame();
			_nextFrame.Roll1 = 1;
			_nextFrame.Roll2 = 2;
		}

		[Specification]
		public void score_is_13()
		{
			_frame.CalculateScore(_nextFrame).should_equal(13);
		}
	}

	public class when_rolling_three_strike_frames : concerns
	{
		private BowlingFrame _frame1;
		private BowlingFrame _frame2;
		private BowlingFrame _frame3;

		protected override void context()
		{
			_frame1 = new BowlingFrame() { Roll1 = 10 };
			_frame2 = new BowlingFrame() { Roll1 = 10 };
			_frame3 = new BowlingFrame() { Roll1 = 10 };
		}

		[Specification]
		public void score_is_30()
		{
			_frame1.CalculateScore(_frame2, _frame3);
		}
	}


}