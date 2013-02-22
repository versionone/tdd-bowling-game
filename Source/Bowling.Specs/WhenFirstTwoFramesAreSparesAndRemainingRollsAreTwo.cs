using Bowling.Specs.Infrastructure;

namespace Bowling.Specs
{
	public class WhenFirstTwoFramesAreSparesAndRemainingRollsAreTwo : concerns
	{
		private BowlingEngine _engine;

		protected override void context()
		{
			_engine = new BowlingEngine();
			_engine.AddRoll(9);
			_engine.AddRoll(1);
			_engine.AddRoll(2);
			_engine.AddRoll(8);
			16.times(() => _engine.AddRoll(2));
		}

		[Specification]
		public void ScoreShouldBeFiftySix()
		{
			_engine.Score().should_equal(56);
		}
	}
}