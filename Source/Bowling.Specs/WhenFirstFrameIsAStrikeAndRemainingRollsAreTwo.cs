using Bowling.Specs.Infrastructure;

namespace Bowling.Specs
{
	public class WhenFirstFrameIsAStrikeAndRemainingRollsAreTwo : concerns
	{
		private BowlingEngine _engine;

		protected override void context()
		{
			_engine = new BowlingEngine();
			_engine.AddRoll(10);
			18.times(() => _engine.AddRoll(2));
		}

		[Specification]
		public void ScoreShouldBeFifty()
		{
			_engine.Score().should_equal(50);
		}		
	}
}