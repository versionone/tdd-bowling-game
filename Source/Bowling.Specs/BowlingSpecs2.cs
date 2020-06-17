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
			10.times(()=> _game.RollFrame(gutterball,gutterball));
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
			10.times(() => _game.RollFrame(2,2));
			
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
			_game.RollFrame(2,2);
			9.times(() => _game.RollFrame(3,3));

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
			10.times(() => { _game.RollFrame(2, 5); });

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
			_game.RollFrame(2, 8);
			9.times(() =>
			{
				_game.RollFrame(2,2);
			});

		}

		[Test]
		public void score_is_48()
		{
			(_game.Score).ShouldEqual(48);
		}
	}

	//when the first 2 frames are spare (as 2,8) and the rest score 2, the score is 56.
	public class first_two_frame_is_2_8_rest_2
	{
		private Game _game;
		[SetUp]
		public void context()
		{
			_game = new Game();
			_game.RollFrame(2, 8);
			_game.RollFrame(2, 8);
			8.times(() =>
			{
				_game.RollFrame(2,2);
			});

		}

		[Test]
		public void score_is_48()
		{
			(_game.Score).ShouldEqual(56);
		}
	}
}