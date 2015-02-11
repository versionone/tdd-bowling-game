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

	public class when_rolling_all_gutter_balls : concerns
	{
		private int _score;

		protected override void context()
		{
			var game = new BowlingGame();
			20.times(() => game.Roll(0));
			_score = game.Score;
		}

		[Specification]
		public void the_score_should_be_0()
		{
			_score.ShouldEqual(0);
		}

	}

	public class when_rolling_all_twos : concerns
	{
		private int _score;

		protected override void context()
		{
			var game = new BowlingGame();
			20.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Specification]
		public void the_score_should_be_40()
		{
			_score.ShouldEqual(40);
		}

	}

	public class when_rolling_two_twos_and_rest_threes : concerns
	{
		private int _score;

		protected override void context()
		{
			var game = new BowlingGame();
			2.times(() => game.Roll(2));
			18.times(() => game.Roll(3));
			_score = game.Score;
		}

		[Specification]
		public void the_score_should_be_58()
		{
			_score.ShouldEqual(58);
		}

	}

	public class when_rolling_alternating_twos_and_fives : concerns
	{
		private int _score;

		protected override void context()
		{
			var game = new BowlingGame();
			10.times(() =>
			{
				game.Roll(2);
				game.Roll(5);
			});
			_score = game.Score;
		}

		[Specification]
		public void the_score_should_be_70()
		{
			_score.ShouldEqual(70);
		}

	}

	public class when_rolling_a_spare_followed_by_all_twos : concerns
	{
		private int _score;

		protected override void context()
		{
			var game = new BowlingGame();
			game.Roll(9);
			game.Roll(1);
			18.times(() =>game.Roll(2));
			_score = game.Score;
		}

		[Specification]
		public void the_score_should_be_48()
		{
			_score.ShouldEqual(48);
		}

	}

	public class when_rolling_two_spares_followed_by_all_twos : concerns
	{
		private int _score;

		protected override void context()
		{
			var game = new BowlingGame();
			game.Roll(2);
			game.Roll(8);
			game.Roll(2);
			game.Roll(8);
			16.times(() => game.Roll(2));
			_score = game.Score;
		}

		[Specification]
		public void the_score_should_be_56()
		{
			_score.ShouldEqual(56);
		}

	}

	public class when_rolling_more_than_10_frames : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			20.times(() => _game.Roll(2));
		}

		[Specification]
		[ExpectedException(typeof (InvalidOperationException))]
		public void do_not_allow_it()
		{
			_game.Roll(2);
		}

	}

}
