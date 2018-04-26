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
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();
			for (int i = 0; i < 20; i++)
			{
				_game.Roll(0);
			}
		}

		[Test]
		public void the_score_is_zero()
		{
			_game.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_rolling_twos
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();
			for (int i = 0; i < 20; i++)
			{
				_game.Roll(2);
			}
		}

		[Test]
		public void the_score_is_forty()
		{
			_game.Score.ShouldEqual(40);
		}
	}

	public class when_rolling_rolling_twos_for_first_two_then_threes
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();

			2.times(() => _game.Roll(2));
			18.times(() => _game.Roll(3));
		}

		[Test]
		public void the_score_is_fifty_eight()
		{
			_game.Score.ShouldEqual(58);
		}
	}

	public class when_rolling_rolling_alternating_twos_and_fives
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();

			10.times(() =>
			{
				_game.Roll(2);
				_game.Roll(5);
			});
		}

		[Test]
		public void the_score_is_seventy()
		{
			_game.Score.ShouldEqual(70);
		}
	}

	public class when_rolling_a_spare_followed_by_all_twos
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();

			_game.Roll(2);
			_game.Roll(8);
			18.times(() =>
			{
				_game.Roll(2);
			});
		}

		[Test]
		public void the_score_is_fourty_eight()
		{
			_game.Score.ShouldEqual(48);
		}
	}

	public class when_rolling_a_two_spares_followed_by_all_twos
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();

			2.times(() =>
			{
				_game.Roll(2);
				_game.Roll(8);
			});

			16.times(() =>
			{
				_game.Roll(2);
			});
		}

		[Test]
		public void the_score_is_fifty_six()
		{
			_game.Score.ShouldEqual(56);
		}
	}

	public class when_ten_frames_have_been_bowled
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();

			20.times(() =>
			{
				_game.Roll(2);
			});
		}

		[Test]
		public void dont_allow_more()
		{
			Assert.Throws<InvalidOperationException>(() => _game.Roll(2));
		}
	}

	public class when_first_frame_is_strike_followed_by_twos
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();

			_game.Roll(10);

			18.times(() =>
			{
				_game.Roll(2);
			});
		}

		[Test]
		public void the_sore_is_50()
		{
			_game.Score.ShouldEqual(50);
		}
	}

	public class when_first_two_frames_is_strike_followed_by_twos
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();

			_game.Roll(10);

			_game.Roll(10);

			16.times(() =>
			{
				_game.Roll(2);
			});
		}

		[Test]
		public void the_sore_is_68()
		{
			_game.Score.ShouldEqual(68);
		}
	}

	public class when_bowling_a_perfect_game
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();

			12.times(() =>
			{
				_game.Roll(10);
			});
		}

		[Test]
		public void the_sore_is_300()
		{
			_game.Score.ShouldEqual(300);
		}
	}
}