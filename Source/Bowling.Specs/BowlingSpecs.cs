using System;
using Bowling;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;

namespace specs_for_bowling
{
	public class when_everything_is_wired_up : concerns
	{
		private bool _itWorked;

		protected override void context()
		{
			_itWorked = true;
		}

		[Specification]
		public void it_works()
		{
			_itWorked.ShouldBeTrue();
		}
	}

	public class when_rolling_all_gutter_balls : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			20.times(() => _game.Roll(0));
		}

		[Specification]
		public void score_should_be_zero()
		{
			_game.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_twos : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void score_should_be_fourty()
		{
			_game.Score.ShouldEqual(40);
		}
	}

	public class when_rolling_two_twos_followed_by_all_threes : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			2.times(() => _game.Roll(2));
			18.times(() => _game.Roll(3));
		}

		[Specification]
		public void score_should_be_fifty_eight()
		{
			_game.Score.ShouldEqual(58);
		}
	}

	public class when_rolling_alternating_twos_and_fives : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			10.times(() =>
			{
				_game.Roll(2);
				_game.Roll(5);
			});
		}

		[Specification]
		public void score_should_be_seventy()
		{
			_game.Score.ShouldEqual(70);
		}
	}

	public class when_rolling_spare_followed_by_all_twos : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			_game.Roll(1);
			_game.Roll(9);
			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void score_should_be_fourty_eight()
		{
			_game.Score.ShouldEqual(48);
		}
	}

	public class when_rolling_two_spares_followed_by_all_twos : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			2.times(() => { _game.Roll(2); _game.Roll(8); });
			16.times(() => _game.Roll(2));
		}

		[Specification]
		public void score_should_be_fifty_six()
		{
			_game.Score.ShouldEqual(56);
		}
	}

	public class when_rolling_more_than_ten_frames : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			20.times(() => _game.Roll(0));
		}

		[Specification]
		[ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "Game Over")]
		public void throw_an_exception()
		{
			_game.Roll(0);
		}
	}

	public class when_rolling_more_than_ten_frames_with_all_strikes : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			12.times(() => _game.Roll(10));
		}

		[Specification]
		[ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "Game Over")]
		public void throw_an_exception()
		{
			_game.Roll(0);
		}
	}

	public class when_rolling_strike_followed_by_all_twos : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			_game.Roll(10);
			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void score_should_be_fifty()
		{
			_game.Score.ShouldEqual(50);
		}
	}

	// x_ x_ 22 22 22 ...
	// 22 14 4  4  4
	// 22 36 40 44 48
	public class when_rolling_two_strikes_followed_by_all_twos : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			2.times(() => _game.Roll(10));
			16.times(() => _game.Roll(2));
		}

		[Specification]
		public void score_should_be_sixty_eight()
		{
			_game.Score.ShouldEqual(68);
		}
	}

	/*	1  2      8   9   10
	 *  X  X  ..  X   X   XXX
	 * 	30 60 ..  240 270 300
	 * 	1 - 10
	 * 	2 - 30
	 * 	3 - 60
	 * 	4 - 90
	 * 
	 */
	public class when_rolling_perfect_game : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			12.times(() => _game.Roll(10));
		}

		[Specification]
		public void score_should_be_three_hundred()
		{
			_game.Score.ShouldEqual(300);
		}
	}
}

/*
 * X-2 X-1 X
 *  N   N  n
 *  /   N  n
 *  X   N  n
 *  N   /  2*n
 *  N   X  2*n
 *  /   /  2*n
 *  X   /  2*n
 *  /   X  2*n
 *  X   X  3*n
 */
