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
			20.times(()=>currentGame.roll(0));
		}

		[Specification]
		public void then_the_score_is_zero()
		{
			currentGame.calculateScore().should_equal(0);
		}
	}
}