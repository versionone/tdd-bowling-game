using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_frames
{
	public class when_new : concerns
	{
		private readonly Frame _frame = new Frame();

		[Specification]
		public void the_score_is_0()
		{
			_frame.Score.should_equal(0);
		}

		[Specification]
		public void is_not_closed()
		{
			_frame.IsClosed.should_be_false();
		}
	}

	public class with_a_single_roll_of_5_pins : concerns
	{
		private readonly Frame _frame = new Frame();

		protected override void context()
		{
			_frame.AddRoll(5);
		}

		[Specification]
		public void the_score_is_5()
		{
			_frame.Score.should_equal(5);
		}

		[Specification]
		public void is_not_closed()
		{
			_frame.IsClosed.should_be_false();
		}
	}

	public class with_two_rolls_of_5_and_5_pins : concerns
	{
		private readonly Frame _frame = new Frame();

		protected override void context()
		{
			_frame.AddRoll(5);
			_frame.AddRoll(5);
		}

		[Specification]
		public void the_score_is_10()
		{
			_frame.Score.should_equal(10);
		}

		[Specification]
		public void the_type_is_spare()
		{
			_frame.Type.should_equal(Frame.FrameType.Spare);
		}

		[Specification]
		public void is_closed()
		{
			_frame.IsClosed.should_be_true();
		}
	}

	public class with_two_rolls_of_5_and_4_pins : concerns
	{
		private readonly Frame _frame = new Frame();

		protected override void context()
		{
			_frame.AddRoll(5);
			_frame.AddRoll(4);
		}

		[Specification]
		public void the_score_is_9()
		{
			_frame.Score.should_equal(9);
		}

		[Specification]
		public void the_type_is_regular()
		{
			_frame.Type.should_equal(Frame.FrameType.Regular);
		}

		[Specification]
		public void is_closed()
		{
			_frame.IsClosed.should_be_true();
		}

	}

	public class when_frame_is_closed : concerns
	{
		private readonly Frame _frame = new Frame();

		protected override void context()
		{
			_frame.AddRoll(1);
			_frame.AddRoll(1);
			_frame.AddRoll(1);
		}

		[Specification]
		public void the_score_is_2()
		{
			_frame.Score.should_equal(2);
		}

		[Specification]
		public void is_closed()
		{
			_frame.IsClosed.should_be_true();
		}
	}

	public class with_a_single_roll_of_10 : concerns
	{
		private readonly Frame _frame = new Frame();

		protected override void context()
		{
			_frame.AddRoll(10);
		}

		[Specification]
		public void the_score_is_10()
		{
			_frame.Score.should_equal(10);
		}

		[Specification]
		public void the_type_is_strike()
		{
			_frame.Type.should_equal(Frame.FrameType.Strike);
		}


		[Specification]
		public void is_closed()
		{
			_frame.IsClosed.should_be_true();
		}
	}
}