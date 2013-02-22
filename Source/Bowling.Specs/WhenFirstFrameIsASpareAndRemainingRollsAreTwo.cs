using Bowling.Specs.Infrastructure;

namespace Bowling.Specs
{
	public class WhenFirstFrameIsASpareAndRemainingRollsAreTwo : concerns
	{
		private BowlingEngine _engine;

		protected override void context()
		{
			_engine = new BowlingEngine();
			_engine.AddRoll(9);
			_engine.AddRoll(1);
			18.times(() => _engine.AddRoll(2));
		}

		[Specification]
		public void ScoreShouldBeFortyEight()
		{
			_engine.Score().should_equal(48);
		}
	}
}