using Bowling.Specs.Infrastructure;

namespace Bowling.Specs
{
	public class WhenFirstTwoFramesAreStrikesAndRemainingRollsAreTwo : concerns
	{
		private BowlingEngine _engine;

		protected override void context()
		{
			_engine = new BowlingEngine();
			2.times(() =>_engine.AddRoll(10));
			16.times(() => _engine.AddRoll(2));
		}

		[Specification]
		public void ScoreShouldBeSixtyEight()
		{
			_engine.Score().should_equal(68);
		}		
	}
}