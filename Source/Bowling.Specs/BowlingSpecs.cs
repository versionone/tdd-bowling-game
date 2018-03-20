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
		public void when_rolling_all_gutter_balls_the_score_is_0()
		{
			var game = new Game();
			for (var i = 0; i < 20; ++i)
				game.Roll(0);
			Assert.AreEqual(0, game.GetScore());
		}

		[Test]
		public void when_rolling_all_2s_the_score_is_40()
		{
			var game = new Game();
			for (var i = 0; i < 20; ++i)
				game.Roll(2);
			Assert.AreEqual(40, game.GetScore());
		}

		[Test]
		public void when_the_first_two_rolls_are_2_and_the_rest_are_3()
		{
			var game = new Game();
			game.Roll(2);
			game.Roll(2);
			for (var i = 0; i < 18; ++i)
				game.Roll(3);
			Assert.AreEqual(58, game.GetScore());
		}

		[Test]
		public void when_rolling_alternating_2s_and_5s()
		{
			var game = new Game();
			for (var i = 0; i < 10; ++i)
			{
				game.Roll(2);
				game.Roll(5);
			}

			Assert.AreEqual(70, game.GetScore());
		}

		[Test]
		public void when_the_first_frame_is_a_spare_and_the_remaining_rolls_are_all_2()
		{
			var game = new Game();
			game.Roll(2);
			game.Roll(8);
			for (var i = 0; i < 18; ++i)
			{
				game.Roll(2);
			}

			Assert.AreEqual(48, game.GetScore());
		}
	}
}