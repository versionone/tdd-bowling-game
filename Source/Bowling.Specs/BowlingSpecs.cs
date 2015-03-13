using System;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;
using Bowling;

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

	public class when_rolling_alternate_2s_and_5s : concerns
	{
		private BowlingGame _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new BowlingGame();
			for (var i = 0; i < 10; i++)
			{
				_bowlingGame.Roll(2);
				_bowlingGame.Roll(5);
			}
		}

		[Specification]
		public void score_is_70()
		{
			var score = _bowlingGame.GetScore();
			score.ShouldEqual(70);
		}
	}

	public class when_rolling_a_spare_and_then_all_2s : concerns
	{
		private BowlingGame _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new BowlingGame();
			_bowlingGame.Roll(5);
			_bowlingGame.Roll(5);
			for (var i = 0; i < 18; i++)
			{
				_bowlingGame.Roll(2);
			}
		}

		[Specification]
		public void score_is_48()
		{
			var score = _bowlingGame.GetScore();
			score.ShouldEqual(48);
		}
	}

	public class when_rolling_two_2_8_spares_and_then_all_2s : concerns
	{
		private BowlingGame _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new BowlingGame();
			_bowlingGame.Roll(2);
			_bowlingGame.Roll(8);
			_bowlingGame.Roll(2);
			_bowlingGame.Roll(8);
			for (var i = 0; i < 16; i++)
			{
				_bowlingGame.Roll(2);
			}
		}

		[Specification]
		public void score_is_56()
		{
			var score = _bowlingGame.GetScore();
			score.ShouldEqual(56);
		}
	}

	public class when_10_frames_bowled_allow_no_more_rolls : concerns
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
		public void throws_exception()
		{
			typeof (ApplicationException).ShouldBeThrownBy(() => _bowlingGame.Roll(2)).Message.ShouldEqual("game over");
		}
	}
}