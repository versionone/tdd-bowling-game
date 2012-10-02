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
	public class when_rolling_all_gutter_balls : concerns
	{
		private BowlingGame SUT;

		protected override void context()
		{
			SUT = new BowlingGame();
		}

		[Specification]
		public void score_is_zero()
		{
			SUT.Score.should_equal(0);
		}
	}
}