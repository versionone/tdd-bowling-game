using System;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;

namespace Bowling.Specs
{
	public class when_everything_is_wired_up
	{
		private bool _itWorked;

		[SetUp]
		public void context()
		{
			_itWorked = true;
		}

		[Test]
		public void it_works()
		{
			_itWorked.ShouldBeTrue();
		}
	}

	public class when_rolling_all_gutter_balls
	{
		private int _score;

		[SetUp]
		public void context()
		{
			var game = new Game();
			for (var i =0; i<20; i++)
				game.Roll(0);
			_score = game.Score;
		}

		[Test]
		public void score_is_0()
		{
			_score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_2s
	{
		private int _score;

		[SetUp]
		public void context()
		{
			var game = new Game();
			for (var i =0; i<20; i++)
				game.Roll(2);
			_score = game.Score;
		}

		[Test]
		public void score_is_40()
		{
			_score.ShouldEqual(40);
		}
	}

	public class when_rolling_twos_and_threes
	{
		private int _score;

		[SetUp]
		public void context()
		{
			var game = new Game();
			2.times(() => game.Roll(2));
			18.times(() => game.Roll(3));
			_score = game.Score;
		}

		[Test]
		public void score_is_58()
		{
			_score.ShouldEqual(58);
		}
	}

	public class when_rolling_alternating_twos_and_fives
	{
		private int _score;

		[SetUp]
		public void context()
		{
			var game = new Game();
			10.times(() =>
			{
				game.Roll(2);
				game.Roll(5);
			});
			_score = game.Score;
		}

		[Test]
		public void score_is_70()
		{
			_score.ShouldEqual(70);
		}
	}

	public class when_rolling_a_spare_then_all_2s
	{
		private int _score;

		[SetUp]
		public void context()
		{
			var game = new Game();
			2.times(() => game.Roll(5));
			18.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Test]
		public void score_is_48()
		{
			_score.ShouldEqual(48);
		}
	}

	public class when_rolling_two_spares_then_all_2s
	{
		private int _score;

		[SetUp]
		public void context()
		{
			var game = new Game();
			2.times(() =>
			{
				game.Roll(2);
				game.Roll(8);
			});
			16.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Test]
		public void score_is_56()
		{
			_score.ShouldEqual(56);
		}
	}

	public class when_bowling_more_than_10_frames
	{
		private int _score;
		private bool _error;

		[SetUp]
		public void context()
		{
			var game = new Game();
			20.times(() => game.Roll(2));
			try
			{
				game.Roll(2);
			}
			catch (Exception e)
			{
				_error = true;
			}
			_score = game.Score;
		}

		[Test]
		public void score_not_altered()
		{
			_score.ShouldEqual(40);
		}

		[Test]
		public void roll_not_allowed()
		{
			_error.ShouldBeTrue();
		}
	}
	public class when_rolling_a_strike_then_all_2s
	{
		private int _score;

		[SetUp]
		public void context()
		{
			var game = new Game();
			game.Roll(10);
			18.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Test]
		public void score_is_50()
		{
			_score.ShouldEqual(50);
		}
	}

	public class when_rolling_two_strikes_then_all_2s
	{
		private int _score;

		[SetUp]
		public void context()
		{
			var game = new Game();
			2.times(() => game.Roll(10));
			16.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Test]
		public void score_is_68()
		{
			_score.ShouldEqual(68);
		}
	}

	/*public class when_rolling_the_perfect_game
	{
		private int _score;

		[SetUp]
		public void context()
		{
			var game = new Game();
			12.times(() => game.Roll(10));
			_score = game.Score;
		}

		[Test]
		public void score_is_300()
		{
			_score.ShouldEqual(300);
		}
	}*/

}