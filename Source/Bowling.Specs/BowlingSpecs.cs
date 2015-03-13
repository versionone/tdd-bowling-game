using Bowling.Specs.Infrastructure;
using NUnit.Framework;
using Bowling.Specs;

namespace specs_for_bowling
{
	public class when_everything_is_wired_up : concerns
	{
		private bool _itWorked;

		protected override void context()
		{
			_itWorked = true;
		}

		[Specification]
		public void it_works()
		{
			_itWorked.ShouldBeTrue();
		}
	}

	public class when_rolling_all_gutter_balls : concerns
	{
		private BowlingGame _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new BowlingGame();
			for (var i = 0; i < 20; i++)
			{
				_bowlingGame.Roll(0);
			}
		}

		[Specification]
		public void score_is_0()
		{
			var score = _bowlingGame.GetScore();
			score.ShouldEqual(0);
		}
	}
}