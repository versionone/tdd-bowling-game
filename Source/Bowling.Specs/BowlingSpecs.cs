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
			for (int i = 0; i < 10; i++)
			{
				_game.Roll(0);
				_game.Roll(0);
			}
		}

		[Test]
		public void the_score_is_0()
		{
			_game.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_2s
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();
			for (int i = 0; i < 10; i++)
			{
				_game.Roll(2);
				_game.Roll(2);
			}
		}

		[Test]
		public void the_score_is_40()
		{
			_game.Score.ShouldEqual(40);
		}
	}

	public class when_rolling_firat_2_rolls_are_2_and_rest_are_3
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();
			_game.Roll(2);
			_game.Roll(2);
			for (int i = 0; i < 9; i++)
			{
				_game.Roll(3);
				_game.Roll(3);
			}
		}

		[Test]
		public void the_score_is_58()
		{
			_game.Score.ShouldEqual(58);
		}
	}

	public class when_rolling_alternating_2s_and_5s
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();
			for (int i = 0; i < 10; i++)
			{
				_game.Roll(2);
				_game.Roll(5);
			}
		}

		[Test]
		public void the_score_is_70()
		{
			_game.Score.ShouldEqual(70);
		}
	}

	public class when_rolling_a_spare_followed_by_all_2s
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();
			_game.Roll(8);
			_game.Roll(2);
			for (int i = 0; i < 9; i++)
			{
				_game.Roll(2);
				_game.Roll(2);
			}
		}

		[Test]
		public void the_score_is_48()
		{
			_game.Score.ShouldEqual(48);
		}
	}

}