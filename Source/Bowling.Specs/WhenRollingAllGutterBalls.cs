using Bowling.Specs.Infrastructure;

namespace Bowling.Specs
{
	public class WhenRollingAllGutterBalls : concerns
	{
		private BowlingEngine _engine;

		protected override void context()
		{
			_engine = new BowlingEngine();
			20.times(() => _engine.AddRoll(0));
		}

		[Specification]
		public void ScoreShouldBeZero()
		{
			_engine.Score().should_equal(0);
		}
	}
}