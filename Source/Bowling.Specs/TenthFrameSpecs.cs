using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_tenth_frames
{
	public class when_the_first_roll_has_occurred : concerns
	{
		private TenthFrame _frame;

		protected override void context()
		{
			_frame = new TenthFrame(5);
		}

		[Specification]
		public void the_frame_is_not_finished()
		{
			_frame.IsFinished().ShouldBeFalse();
		}
	}

	public class when_the_second_roll_has_occurred : concerns
	{
		private TenthFrame _frame;

		protected override void context()
		{
			_frame = new TenthFrame(5);
			_frame.AddRoll(1);
		}

		[Specification]
		public void the_frame_is_finished()
		{
			_frame.IsFinished().ShouldBeTrue();
		}
	}

	public class when_two_rolls_sum_to_10 : concerns
	{
		private TenthFrame _frame;

		protected override void context()
		{
			_frame = new TenthFrame(5);
			_frame.AddRoll(5);
			_frame.AddRoll(2);
		}

		[Specification]
		public void the_frame_is_a_spare()
		{
			_frame.IsSpare().ShouldBeTrue();
		}

		[Specification]
		public void the_frame_is_not_a_strike()
		{
			_frame.IsStrike().ShouldBeFalse();
		}

		[Specification]
		public void the_frame_is_finished()
		{
			_frame.IsFinished().ShouldBeTrue();
		}
	}

	public class when_the_first_roll_is_a_10 : concerns
	{
		private TenthFrame _frame;

		protected override void context()
		{
			_frame = new TenthFrame(10);
			_frame.AddRoll(5);
			_frame.AddRoll(5);
		}

		[Specification]
		public void the_frame_is_a_strike()
		{
			_frame.IsStrike().ShouldBeTrue();
		}

		[Specification]
		public void the_frame_is_not_a_spare()
		{
			_frame.IsSpare().ShouldBeFalse();
		}

		[Specification]
		public void the_frame_is_finished()
		{
			_frame.IsFinished().ShouldBeTrue();
		}
	}
}