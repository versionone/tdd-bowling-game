using System;
using Bowling;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;

namespace specs_for_bowling
{
	public class when_i_roll_all_gutter_balls : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();
			20.times(() => game.Roll(0));
			_score = game.Score;
		}

		[Specification]
		public void score_should_be_zero()
		{
			_score.ShouldEqual(0);
		}
	}

	public class when_i_only_can_hit_two_pins_each_ball : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();
			20.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Specification]
		public void score_should_be_fourty()
		{
			_score.ShouldEqual(40);
		}
	}

	public class when_i_alternately_hit_two_then_five : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();
			10.times(() =>
				{
					game.Roll(2);
					game.Roll(5);
				});
			_score = game.Score;
		}

		[Specification]
		public void score_should_be_seventy()
		{
			_score.ShouldEqual(70);
		}
	}

	public class when_the_first_frame_is_spare_and_the_rest_are_two : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();
			game.Roll(9);
			game.Roll(1);
			18.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Specification]
		public void score_should_be_fourtyeight()
		{
			_score.ShouldEqual(48);
		}
	}

	public class when_the_first_two_rolls_are_two_and_the_rest_are_three : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();
			game.Roll(2);
			game.Roll(2);
			18.times(() => game.Roll(3));
			_score = game.Score;
		}

		[Specification]
		public void score_should_be_fiftyeight()
		{
			_score.ShouldEqual(58);
		}
	}

	public class when_the_first_two_frames_are_spare_and_the_rest_are_two : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();
			game.Roll(2);
			game.Roll(8);
			game.Roll(2);
			game.Roll(8);
			16.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Specification]
		public void score_should_be_fiftysix()
		{
			_score.ShouldEqual(56);
		}
	}

	public class cross_frame_balls_equal_ten_should_not_be_spare : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();

			// Frame 1 
			game.Roll(0);
			game.Roll(0);

			// Frame 2
			game.Roll(0);
			game.Roll(2);

			// Frame 3
			game.Roll(8);
			game.Roll(1);
			
			14.times(() => game.Roll(0));
			_score = game.Score;
		}

		[Specification]
		public void score_should_be_eleven()
		{
			_score.ShouldEqual(11);
		}
	}

	public class bowling_over_ten_frames : concerns<BowlingGame>
	{
		protected override void context()
		{
			var game = build_up();
			20.times(() => game.Roll(0));
		}

		[Specification, ExpectedException(typeof(InvalidOperationException))]
		public void ist_verbotten()
		{
			build_up().Roll(0);
		}
	}

	public class first_frame_strike_followed_by_all_twos : concerns<BowlingGame>
	{
		private int _score;

		protected override void context()
		{
			var game = build_up();

			game.Roll(10);

			18.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Specification]
		public void score_should_be_fifty()
		{
			_score.ShouldEqual(50);
		}
	}

	public class open_frame : concerns<Frame>
	{
		protected override void context()
		{
			var frame = build_up();
			frame.Roll(0);
			frame.Roll(5);
		}

		[Specification]
		public void score_should_be_5()
		{
			build_up().Score.ShouldEqual(5);
		}

		[Specification]
		public void frame_should_be_full()
		{
			build_up().IsFull.ShouldBeTrue();
		}

		[Specification]
		public void frame_should_be_scorable()
		{
			build_up().IsScorable.ShouldBeTrue();
		}
	}

	public class open_frame_reversed : concerns<Frame>
	{
		protected override void context()
		{
			var frame = build_up();
			frame.Roll(5);
			frame.Roll(0);
		}

		[Specification]
		public void score_should_be_5()
		{
			build_up().Score.ShouldEqual(5);
		}

		[Specification]
		public void frame_should_be_full()
		{
			build_up().IsFull.ShouldBeTrue();
		}

		[Specification]
		public void frame_should_be_scorable()
		{
			build_up().IsScorable.ShouldBeTrue();
		}
	}

	public class incomplete_frame : concerns<Frame>
	{
		protected override void context()
		{
			var frame = build_up();
			frame.Roll(7);
		}

		[Specification]
		public void it_is_not_scorable()
		{
			build_up().IsScorable.ShouldBeFalse();
		}

		[Specification]
		public void frame_should_be_full()
		{
			build_up().IsFull.ShouldBeFalse();
		}
	}

	public class spare_frame_unfinished : concerns<Frame>
	{
		protected override void context()
		{
			var frame = build_up();
			frame.Roll(7);
			frame.Roll(3);
		}

		[Specification, ExpectedException(typeof(InvalidOperationException))]
		public void score_should_throw_exception()
		{
			var score = build_up().Score;
		}

		[Specification]
		public void score_should_be_marked_spare()
		{
			build_up().IsSpare.ShouldBeTrue();
		}

		[Specification]
		public void frame_should_be_full()
		{
			build_up().IsFull.ShouldBeTrue();
		}

		[Specification]
		public void frame_should_be_scorable()
		{
			build_up().IsScorable.ShouldBeFalse();
		}
	}

	public class spare_frame_finished : concerns<Frame>
	{
		protected override void context()
		{
			var frame = build_up();
			frame.Roll(7);
			frame.Roll(3);
			frame.Roll(4);
		}

		[Specification]
		public void score_should_be_14()
		{
			build_up().Score.ShouldEqual(14);
		}

		[Specification]
		public void score_should_be_marked_spare()
		{
			build_up().IsSpare.ShouldBeTrue();
		}

		[Specification]
		public void frame_should_be_full()
		{
			build_up().IsFull.ShouldBeTrue();
		}

		[Specification]
		public void frame_should_be_scorable()
		{
			build_up().IsScorable.ShouldBeTrue();
		}
	}

	public class unfinished_strike_with_no_bonus : concerns<Frame>
	{
		protected override void context()
		{
			var frame = build_up();
			frame.Roll(10);
		}

		[Specification, ExpectedException(typeof(InvalidOperationException))]
		public void score_should_throw_exception()
		{
			var score = build_up().Score;
		}

		[Specification]
		public void should_not_be_marked_spare()
		{
			build_up().IsSpare.ShouldBeFalse();
		}

		[Specification]
		public void should_be_marked_strike()
		{
			build_up().IsStrike.ShouldBeTrue();
		}

		[Specification]
		public void frame_should_be_full()
		{
			build_up().IsFull.ShouldBeTrue();
		}

		[Specification]
		public void frame_should_not_be_scorable()
		{
			build_up().IsScorable.ShouldBeFalse();
		}
	}

	public class unfinished_strike_with_one_bonus : concerns<Frame>
	{
		protected override void context()
		{
			var frame = build_up();
			frame.Roll(10);
			frame.Roll(10);
		}

		[Specification, ExpectedException(typeof(InvalidOperationException))]
		public void score_should_throw_exception()
		{
			var score = build_up().Score;
		}

		[Specification]
		public void should_not_be_marked_spare()
		{
			build_up().IsSpare.ShouldBeFalse();
		}

		[Specification]
		public void should_be_marked_strike()
		{
			build_up().IsStrike.ShouldBeTrue();
		}

		[Specification]
		public void frame_should_be_full()
		{
			build_up().IsFull.ShouldBeTrue();
		}

		[Specification]
		public void frame_should_not_be_scorable()
		{
			build_up().IsScorable.ShouldBeFalse();
		}
	}

	public class unfinished_strike_with_two_bonuses : concerns<Frame>
	{
		protected override void context()
		{
			var frame = build_up();
			frame.Roll(10);
			frame.Roll(10);
			frame.Roll(10);
		}

		[Specification]
		public void score_should_be_30()
		{
			build_up().Score.ShouldEqual(30);
		}

		[Specification]
		public void should_not_be_marked_spare()
		{
			build_up().IsSpare.ShouldBeFalse();
		}

		[Specification]
		public void should_be_marked_strike()
		{
			build_up().IsStrike.ShouldBeTrue();
		}

		[Specification]
		public void frame_should_be_full()
		{
			build_up().IsFull.ShouldBeTrue();
		}

		[Specification]
		public void frame_should_be_scorable()
		{
			build_up().IsScorable.ShouldBeTrue();
		}
	}
}
