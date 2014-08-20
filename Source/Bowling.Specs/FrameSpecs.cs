using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_frames
{
	public class when_the_first_roll_has_occurred : concerns
	{
		private Frame _frame;

		protected override void context()
		{
			_frame = new Frame(5);
		}

		[Specification]
		public void the_frame_is_not_finished()
		{
			_frame.IsFinished().ShouldBeFalse();
		}
	}

	public class when_the_second_roll_has_occurred : concerns
	{
		private Frame _frame;

		protected override void context()
		{
			_frame = new Frame(5);
			_frame.AddRoll(1);
		}

		[Specification]
		public void the_frame_is_finished()
		{
			_frame.IsFinished().ShouldBeTrue();
		}
	}

	public class when_the_frames_score_is_10: concerns
	{
		private Frame _frame;

		protected override void context()
		{
			_frame = new Frame(5);
			_frame.AddRoll(5);
		}

		[Specification]
		public void the_frame_is_a_spare()
		{
			_frame.IsSpare().ShouldBeTrue();
		}
	}
}