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
			for (int i = 0; i < 20; ++i)
				_game.Roll(0);
		}

		[Test]
		public void the_score_is_0()
		{
			_game.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_twos
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();
			for (int i = 0; i < 20; ++i)
				_game.Roll(2);
		}

		[Test]
		public void the_score_is_40()
		{
			_game.Score.ShouldEqual(40);
		}
	}

}