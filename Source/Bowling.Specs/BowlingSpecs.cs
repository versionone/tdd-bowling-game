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
		Game _game = new Game();

		[SetUp]
		public void context()
		{
			for (var i = 0; i < 20; i++)
				_game.Roll(0);
		}

		[Test]
		public void the_score_is_zero()
		{
			_game.GetScore().ShouldEqual(0);
		}
	}

	public class when_rolling_all_twos
	{
		Game _game = new Game();

		[SetUp]
		public void context()
		{
			for (var i = 0; i < 20; i++)
				_game.Roll(2);
		}

		[Test]
		public void the_score_is_40()
		{
			_game.GetScore().ShouldEqual(40);
		}
	}

	public class when_rolling_2_twos_followed_by_all_threes
	{
		Game _game = new Game();

		[SetUp]
		public void context()
		{
			for (var i = 0; i < 2; i++)
				_game.Roll(2);
			for (var i = 0; i < 18; i++)
				_game.Roll(3);
		}

		[Test]
		public void the_score_is_58()
		{
			_game.GetScore().ShouldEqual(58);
		}
	}

	public class when_rolling_alternating_2s_and_5s
	{
		Game _game = new Game();

		[SetUp]
		public void context()
		{
			for (var i = 0; i < 10; i++)
			{
				_game.Roll(2);
				_game.Roll(5);
			}
/*
			for (var i = 0; i < 20; i++)
				_game.Roll(i % 2 == 0 ? 2 : 5);
*/
/*
			for (var i = 0; i < 20; i++)
				if (i % 2 == 0)
				{
					_game.Roll(2);
				}
				else
				{
					_game.Roll(5);
				}
*/
				
		}

		[Test]
		public void the_score_is_70()
		{
			_game.GetScore().ShouldEqual(70);
		}
	}

	public class when_rolling_a_spare_followed_by_all_2s
	{
		Game _game = new Game();

		[SetUp]
		public void context()
		{
			_game.Roll(9);
			_game.Roll(1);
			for (var i = 0; i < 18; i++)
				_game.Roll(2);
		}

		[Test]
		public void the_score_is_48()
		{
			_game.GetScore().ShouldEqual(48);
		}
	}

}