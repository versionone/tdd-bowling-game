using Bowling.Specs.Infrastructure;

namespace Bowling.Specs
{
	public class WhenRollingAllGutterBalls : concerns
	{
		private BowlingEngine _engine;

		protected override void context()
		{
			_engine = new BowlingEngine();
			10.times(() => _engine.AddFrame(0, 0));
		}

		[Specification]
		public void ScoreShouldBeZero()
		{
			_engine.Score.should_equal(0);
		}
	}
}