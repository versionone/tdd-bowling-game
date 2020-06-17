using Bowling.Specs.Infrastructure;
using NUnit.Framework;

namespace Bowling.Specs
{
	public class when_rolling_all_gutterballs
	{
		private Game _game;
		[SetUp]
		public void context()
		{
			_game = new Game();
			int gutterball = 0;
			20.times(()=> _game.roll(gutterball));
		}

		[Test]
		public void score_is_zero()
		{
			(_game.Score == 0).ShouldBeTrue();
		}

	}

	public class when_rolling_all_2
	{
		private Game _game;
		[SetUp]
		public void context()
		{
			_game = new Game();
			20.times(() => _game.roll(2));
			
		}

		[Test]
		public void score_is_fourty()
		{
			(_game.Score == 40).ShouldBeTrue();
		}
	}

	//when the first 2 rolls are 2 and the rest are 3, the score is 58.
	public class when_rolling_two_2_follwed_by_3
	{
		private Game _game;
		[SetUp]
		public void context()
		{
			_game = new Game();
			2.times(() => _game.roll(2));
			18.times(() => _game.roll(3));

		}

		[Test]
		public void score_is_fiftyeight()
		{
			(_game.Score == 58).ShouldBeTrue();
		}
	}

	//when rolling alternating 2s and 5s, the score 70.
	public class when_rolling_alternates_2_and_5
	{
		private Game _game;
		[SetUp]
		public void context()
		{
			_game = new Game();
			10.times(() =>
			{
				_game.roll(2);
				_game.roll(5);
			});

		}

		[Test]
		public void score_is_70()
		{
			(_game.Score).ShouldEqual(70);
		}
	}

	//when the first frame is a spare and the remaining rolls are all 2, the score is 48.
	public class first_frame_spare_remaining_are_2
	{
		private Game _game;
		[SetUp]
		public void context()
		{
			_game = new Game();
			_game.roll(2);
			_game.roll(8);
			18.times(() =>
			{
				_game.roll(2);
			});

		}

		[Test]
		public void score_is_48()
		{
			(_game.Score).ShouldEqual(48);
		}
	}
}