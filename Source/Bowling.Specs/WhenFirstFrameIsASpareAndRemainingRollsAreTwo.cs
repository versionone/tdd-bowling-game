using Bowling.Specs.Infrastructure;

namespace Bowling.Specs
{
	public class WhenFirstFrameIsASpareAndRemainingRollsAreTwo : concerns
	{
		private BowlingEngine _engine;

		protected override void context()
		{
			_engine = new BowlingEngine();
			_engine.AddFrame(9, 1);
			9.times(() => _engine.AddFrame(2, 2));
		}

		[Specification]
		public void ScoreShouldBeFortyEight()
		{
			_engine.Score().should_equal(48);
		}
	}
}