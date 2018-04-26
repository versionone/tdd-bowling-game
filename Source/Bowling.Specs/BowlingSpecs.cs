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
}