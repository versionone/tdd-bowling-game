using Bowling.Specs.Infrastructure;

namespace Bowling.Specs
{
	public class WhenFirstTwoFramesAreSparesAndRemainingRollsAreTwo : concerns
	{
		private BowlingEngine _engine;

		protected override void context()
		{
			_engine = new BowlingEngine();
			_engine.AddFrame(9, 1);
			_engine.AddFrame(2, 8);
			8.times(() => _engine.AddFrame(2, 2));
		}

		[Specification]
		public void ScoreShouldBeFiftySix()
		{
			_engine.Score().should_equal(56);
		}
	}
}