using Bowling.Specs.Infrastructure;
using NUnit.Framework;
using Rhino.Mocks.Exceptions;

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

	public class when_Rolling_the_first_two_frames_as_spares_and_2s_for_the_rest
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();
			_game.Roll(2);
			_game.Roll(8);
			_game.Roll(2);
			_game.Roll(8);
			for (int i = 0; i < 8; i++)
			{
				_game.Roll(2);
				_game.Roll(2);
			}
		}

		[Test]
		public void the_score_is_56()
		{
			_game.Score.ShouldEqual(56);
		}
	}

	public class when_10_frames_have_been_bowled
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
		public void dont_allow_additional_frames_to_be_bowled()
		{
			try
			{
				_game.Roll(2);
				Assert.Fail("allowed to roll more than 10 frames");
			}
			catch (TooManyFramesException ex)
			{
			}
		}
	}

	public class when_first_frame_is_strike_and_subsequent_rolls_are_two
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();
			_game.Roll(10);
			for (int i = 0; i < 9; i++)
			{
				_game.Roll(2);
				_game.Roll(2);
			}
		}

		[Test]
		public void the_score_is_50()
		{
			_game.Score.ShouldEqual(50);
		}
	}

	public class when_first_two_frames_are_strikes_and_subsequent_rolls_are_two
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();
			_game.Roll(10);
			_game.Roll(10);
			for (int i = 0; i < 8; i++)
			{
				_game.Roll(2);
				_game.Roll(2);
			}
		}

		[Test]
		public void the_score_is_68()
		{
			_game.Score.ShouldEqual(68);
		}
	}

	public class when_roling_alternating_strikes_and_spares
	{
		private Game _game;

		[SetUp]
		public void context()
		{
			_game = new Game();
			for (int i = 0; i < 5; i++)
			{
				_game.Roll(10);
				_game.Roll(5);
				_game.Roll(5);
			}
		}

		[Test]
		public void the_score_is_200()
		{
			_game.Score.ShouldEqual(200);
		}
	}
}