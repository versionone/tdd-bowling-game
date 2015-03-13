using Bowling.Specs.Infrastructure;
using NUnit.Framework;
using Bowling.Specs;

namespace specs_for_bowling
{
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

	public class when_rolling_all_2s : concerns
	{
		private BowlingGame _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new BowlingGame();
			for (var i = 0; i < 20; i++)
			{
				_bowlingGame.Roll(2);
			}
		}

		[Specification]
		public void score_is_40()
		{
			var score = _bowlingGame.GetScore();
			score.ShouldEqual(40);
		}
	}

	public class when_rolling_two_2s_then_all_3s : concerns
	{
		private BowlingGame _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new BowlingGame();
			_bowlingGame.Roll(2);
			_bowlingGame.Roll(2);
			for (var i = 0; i < 18; i++)
			{
				_bowlingGame.Roll(3);
			}
		}

		[Specification]
		public void score_is_58()
		{
			var score = _bowlingGame.GetScore();
			score.ShouldEqual(58);
		}
	}
}