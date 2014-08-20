using System;
using System.Collections.Generic;
using Bowling;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;

namespace specs_for_bowling
{
	public class Roll
	{

		public static Roll New(int pins, int times)
		{
			return new Roll { Pins = pins, Times = times };
		}

		public int Pins { get; set; }
		public int Times { get; set; }
	}

	public class GameSpec
	{
		public int Score { get; set; }
		public string Message { get; set; }
		public readonly List<Roll> GameRolls = new List<Roll>();

		public GameSpec(int expectedScore, string message, params Roll[] rolls)
		{
			Score = expectedScore;
			Message = message;
			GameRolls.AddRange(rolls);
		}
	}

	public class BowlingGameTest : concerns<BowlingGame>
	{
		readonly IEnumerable<GameSpec> _cases0 = new[]
		{
			new GameSpec(58, "when rolling all gutter balls, the score is 0",
				Roll.New(0, 20)
			), 
		};

		readonly IEnumerable<GameSpec> _cases1 = new[]
		{
			new GameSpec(0, "Gutter ball test", Roll.New(0, 20)), 
			new GameSpec(58, "when the first 2 rolls are 2 and the rest are 3, the score is 58.",
				Roll.New(2,2),
				Roll.New(3, 18)
			), 
		};

		[Test, TestCaseSource("_cases1")]
		public void should_return_correct_score_for_game_without_mark(GameSpec rolls)
		{
			var game = build_up();
			rolls.GameRolls.ForEach(r => r.Times.times(() => game.Roll(r.Pins)));
			game.GetScore().ShouldEqual(rolls.Score);
		}
	}


	public class when_I_roll_without_a_mark : concerns<BowlingGame>
	{
		[TestCase(20, 0, 0, "Gutter Test")]
		[TestCase(20, 2, 40, "When score 2 on each roll")]
		public void should_return_expected_score(int rolls, int pins, int expected, string testCase)
		{
			var game = build_up();
			rolls.times(() => game.Roll(pins));
			game.GetScore().ShouldEqual(expected, testCase);
		}
	}

	public class when_I_roll_first_two_then_all_three : concerns<BowlingGame>
	{
		private int expected = 70;
		private int actual;

		protected override void context()
		{
			var game = build_up();

			1.times(() => game.Roll(2));
			1.times(() => game.Roll(5));
			1.times(() => game.Roll(2));
			1.times(() => game.Roll(5));
			1.times(() => game.Roll(2));
			1.times(() => game.Roll(5));
			1.times(() => game.Roll(2));
			1.times(() => game.Roll(5));
			1.times(() => game.Roll(2));
			1.times(() => game.Roll(5));
			1.times(() => game.Roll(2));
			1.times(() => game.Roll(5));
			1.times(() => game.Roll(2));
			1.times(() => game.Roll(5));
			1.times(() => game.Roll(2));
			1.times(() => game.Roll(5));
			1.times(() => game.Roll(2));
			1.times(() => game.Roll(5));
			1.times(() => game.Roll(2));
			1.times(() => game.Roll(5));

			actual = game.GetScore();
		}

		[Specification]
		public void then_my_score_is_fivetyeight()
		{
			actual.ShouldEqual(expected);
		}
	}

	public class when_I_roll_alternating_twos_and_fives : concerns<BowlingGame>
	{
		private int expected = 58;
		private int actual;

		protected override void context()
		{
			var game = build_up();
			2.times(() => game.Roll(2));
			18.times(() => game.Roll(3));
			actual = game.GetScore();
		}

		[Specification]
		public void then_my_score_is_fivetyeight()
		{
			actual.ShouldEqual(expected);
		}
	}

	public class when_I_roll_a_spare_and_rest_are_mark : concerns<BowlingGame>
	{
		private int expected = 48;
		private int actual;

		protected override void context()
		{
			var game = build_up();
			2.times(() => game.Roll(5));
			18.times(() => game.Roll(2));
			actual = game.GetScore();
		}

		[Specification]
		public void then_my_score_is_fivetyeight()
		{
			actual.ShouldEqual(expected);
		}
	}

	public class when_I_roll_a_spare_and_rest_score_2 : concerns<BowlingGame>
	{
		private int expected = 56;
		private int actual;

		protected override void context()
		{
			var game = build_up();
			2.times(() =>
			{
				game.Roll(2);
				game.Roll(8);
			});
			16.times(() => game.Roll(2));
			actual = game.GetScore();
		}

		[Specification]
		public void then_my_score_is_fivetyeight()
		{
			actual.ShouldEqual(expected);
		}
	}

	public class when_I_strike_on_first_frame_then_rest_score_two : concerns<BowlingGame>
	{
		private int expected = 50;
		private int actual;

		protected override void context()
		{
			var game = build_up();
			1.times(() => game.Roll(10));
			18.times(() => game.Roll(2));
			actual = game.GetScore();
		}

		[Specification]
		public void then_my_score_is_fifty()
		{
			actual.ShouldEqual(expected);
		}
	}

	public class when_I_strike_on_first_two_frame_then_rest_score_two : concerns<BowlingGame>
	{
		private int expected = 68;
		private int actual;

		protected override void context()
		{
			var game = build_up();
			2.times(() => game.Roll(10) );
			16.times(() => game.Roll(2));
			actual = game.GetScore();
		}

		[Specification]
		public void then_my_score_is_fifty()
		{
			actual.ShouldEqual(expected);
		}
	}

	public class when_I_roll_a_perfect_game : concerns<BowlingGame>
	{
		private int expected = 300;
		private int actual;

		protected override void context()
		{
			var game = build_up();
			12.times(() => game.Roll(10));
			actual = game.GetScore();
		}

		[Specification]
		public void then_my_score_is_300_yeah_yeah_yeah()
		{
			actual.ShouldEqual(expected);
		}
	}

	public class when_I_roll_alternate_strikes_and_spares : concerns<BowlingGame>
	{
		private int expected = 200;
		private int actual;

		protected override void context()
		{
			var game = build_up();
			5.times(() =>
			{
				game.Roll(10);
				game.Roll(5);
				game.Roll(5);
			});
			game.Roll(10);
			actual = game.GetScore();
		}

		[Specification]
		public void then_my_score_is_200()
		{
			actual.ShouldEqual(expected);
		}
	}

}

//public class when_I_roll_more_than_ten_frame : concerns<BowlingGame>
//{
//	private int expected = 56;
//	private int actual;

//	protected override void context()
//	{
//		var game = build_up();
//		10.times(() =>
//		{
//			game.Roll(2);
//			game.Roll(8);
//		});
//		2.times(() => game.Roll(2));
//		actual = game.GetScore();
//	}

//	[Specification]
//	public void then_my_score_is_fivetyeight()
//	{
//		Assert.Throws<ApplicationException>()
//		actual.ShouldEqual(expected);
//	}
//}



//public class when_I_score_without_any_mark : concerns<BowlingGame>
//{

//	TestCaseData testCase1 = new TestCaseData(new List<Roll>()
//	{
//		Roll.Make(2, 2),
//		Roll.Make(3, 18)

//	});



//	[TestCase(20, 0, 0, "Gutter Test")]
//	[TestCase(20, 2, 40, "When score 2 on each roll")]
//	public void should_return_expected_score(int rolls, int pins, int expected, string testCase)
//	{
//		var game = build_up();
//		rolls.times(() => game.Roll(pins));
//		game.GetScore().ShouldEqual(expected, testCase);
//	}

//	[Test, TestCaseSource("testCase1")]
//	public void should_return_diffrential_score(Roll r,  )
//	{

//	}
//}
