using Bowling.Specs.Infrastructure;
using Bowling.Specs;

/*
 * 
when rolling all gutter balls, the score is 0.
when the first frame is a spare and the rest score 2, the score is 48.
when the first 2 frames are spare and the rest score 2, the score is 56.
when 10 frames have been bowled, don't allow any more to be bowled.
when the first frame is a strike and the rest score 2, the score is 50.
when the first 2 frames are strikes and the rest score 2, the score is 68.
when rolling a perfect game, the score is 300.
when rolling alternate strikes and spares, the score is 200.
 * 
 */

namespace specs_for_bowling
{
	public class empty_game : concerns
	{
		private BowlingGame SUT;

		protected override void context()
		{
			SUT = new BowlingGame();
		}

		[Specification]
		public void has_no_score()
		{
			SUT.Score.should_be_null();
		}
	}

	public class when_rolling_all_gutter_balls : concerns
	{
		private BowlingGame SUT;

		protected override void context()
		{
			SUT = new BowlingGame();
			20.times(() => SUT.Roll(0));
		}

		[Specification]
		public void score_is_zero()
		{
			SUT.Score.should_equal(0);
		}
	}

	public class when_first_frame_is_Spare_followed_by_all_2_rolls : concerns
	{
		private BowlingGame SUT;

		protected override void context()
		{
			SUT = new BowlingGame();
			SUT.Roll(7);
			SUT.Roll(3);
			18.times(() => SUT.Roll(2));
		}

		[Specification]
		public void score_is_48()
		{
			SUT.Score.should_equal(48);
		}
	}
}