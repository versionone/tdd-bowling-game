using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_rolling_all_gutters : concerns
	{
		private BowlingGame currentGame;

		protected override void context()
		{
			currentGame = new BowlingGame();
			20.times(()=>currentGame.Roll(0));
		}

		[Specification]
		public void then_the_score_is_zero()
		{
			currentGame.CalculateScore().should_equal(0);
		}
	}

	public class when_I_knock_down_nine_pins_in_the_first_frame_only : concerns
	{
		private BowlingGame currentGame;

		protected override void context()
		{
			currentGame = new BowlingGame();
			currentGame.Roll(9);
			19.times(() => currentGame.Roll(0));
		}

		[Specification]
		public void then_the_score_is_zero()
		{
			currentGame.CalculateScore().should_equal(9);
		}		
	}
}