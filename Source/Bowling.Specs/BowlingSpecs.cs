using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_rolling_all_gutter_balls : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			20.times(() => _game.Roll(0));
		}

		[Specification]
		public void the_score_is_zero()
		{
			_game.GetScore().ShouldEqual(0);
		}
	}

	public class when_rolling_all_2s : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_40()
		{
			_game.GetScore().ShouldEqual(40);
		}
	}
	public class when_rolling_two_2s_and_the_rest_3s : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			2.times(() => _game.Roll(2));
			18.times(() => _game.Roll(3));
		}

		[Specification]
		public void the_score_is_58()
		{
			_game.GetScore().ShouldEqual(58);
		}
	}
	public class when_rolling_alternating_2s_and_5s : concerns<BowlingGame>
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
		public void the_score_is_70()
		{
			_game.GetScore().ShouldEqual(70);
		}
	}

	public class when_rolling_a_spare_followed_by_all_2s : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			_game.Roll(0);
			_game.Roll(10);
			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_48()
		{
			_game.GetScore().ShouldEqual(48);
		}
	}

	public class when_rolling_two_2_8_spares_followed_by_all_2s : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			2.times(() =>
			{
				_game.Roll(2);
				_game.Roll(8);
			});
			16.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_56()
		{
			_game.GetScore().ShouldEqual(56);
		}
	}

	public class after_rolling_10_frames : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void rolling_extra_balls_does_not_change_the_score()
		{
			_game.GetScore().ShouldEqual(40);
			_game.Roll(2);
			_game.GetScore().ShouldEqual(40);
		}
	}

	public class when_rolling_a_strike_followed_by_all_2s : concerns<BowlingGame>
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = build_up();
			_game.Roll(10);
			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_50()
		{
			_game.GetScore().ShouldEqual(50);
		}
	}
}