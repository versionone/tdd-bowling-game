using System;
using Bowling.Specs.Infrastructure;

namespace Bowling.Specs
{
	public class WhenRollingElevenGutterBalls : concerns
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
			Exception tooManyFramesException = null;
			try
			{
				_engine.AddRoll(0);
			}
			catch (Exception exception)
			{
				tooManyFramesException = exception;
			}
			tooManyFramesException.should_be_a<TooManyFramesException>();
		}
	}
}