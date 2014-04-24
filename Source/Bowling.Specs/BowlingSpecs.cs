using Bowling;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;

namespace specs_for_bowling
{
	public class when_rolling_all_gutter_balls : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			20.times(index => _game.Roll(0));
		}

		[Specification]
		public void the_score_should_be_zero()
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
			20.times(index => _game.Roll(2));
		}

		[Specification]
		public void the_score_should_be_fourty()
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
			2.times(index => _game.Roll(2));
			18.times(index => _game.Roll(3));
		}

		[Specification]
		public void the_score_should_be_fifty_eight()
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
			10.times(index =>
			{
				_game.Roll(2);
				_game.Roll(5);
			});
		}

		[Specification]
		public void the_score_should_be_seventy()
		{
			_game.Score.ShouldEqual(70);
		}
	}

	public class when_rolling_a_spare_followed_by_all_twos : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();

			_game.Roll(5);
			_game.Roll(5);

			18.times(index => _game.Roll(2));
		}

		[Specification]
		public void the_score_should_be_fourty_eight()
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

			_game.Roll(5);
			_game.Roll(5);

			_game.Roll(2);
			_game.Roll(8);

			16.times(index => _game.Roll(2));
		}

		[Specification]
		public void the_score_should_be_fifty_six()
		{
			_game.Score.ShouldEqual(56);
		}
	}

	public class trying_to_roll_more_than_ten_frames : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			20.times(index => _game.Roll(0));
		}

		[Specification]
		[ExpectedException(typeof(TooManyFrames))]
		public void is_not_allowed()
		{
			_game.Roll(0);
		}
	}

}
