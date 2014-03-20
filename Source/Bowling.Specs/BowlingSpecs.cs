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
}