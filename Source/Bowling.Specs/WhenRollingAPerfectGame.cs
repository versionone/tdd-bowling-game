using Bowling.Specs.Infrastructure;

namespace Bowling.Specs
{
	public class WhenRollingAPerfectGame : concerns
	{
		private BowlingEngine _engine;

		protected override void context()
		{
			_engine = new BowlingEngine();
			12.times(() => _engine.AddRoll(10));
		}
		
		[Specification]
		public void ScoreShouldBeThreeHundred()
		{
			_engine.Score().should_equal(300);
		}
	}
}