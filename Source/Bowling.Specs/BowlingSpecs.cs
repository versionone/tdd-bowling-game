using Bowling;
using Bowling.Specs.Infrastructure;

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
		private BowlingGame _theGame;

		protected override void context()
		{
			_theGame = build_up();
			20.times(() => { _theGame.Roll(0); });
			
		}

		[Specification]
		public void the_score_is_zero()
		{
			_theGame.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_twos : concerns<BowlingGame>
	{
		private BowlingGame _theGame;

		protected override void context()
		{
			_theGame = build_up();
			20.times(() => { _theGame.Roll(2); });
			
		}

		[Specification]
		public void the_score_is_fourty()
		{
			_theGame.Score.ShouldEqual(40);
		}	

	}

	public class when_rolling_all_twos_followed_by_all_threes : concerns<BowlingGame>
	{
		private BowlingGame _theGame;

		protected override void context()
		{
			_theGame = build_up();
			2.times(() => { _theGame.Roll(2); });
			18.times(() => { _theGame.Roll(3); });
		}

		[Specification]
		public void the_score_is_fifty_eight()
		{
			_theGame.Score.ShouldEqual(58);
		}

	}

	public class when_alternating_between_two_and_five : concerns<BowlingGame>
	{
		private BowlingGame _theGame;

		protected override void context()
		{
			_theGame = build_up();

				10.times(() =>
				{
					_theGame.Roll(2);
					_theGame.Roll(5);
				});
		}

		[Specification]
		public void the_score_is_seventy()
		{
			_theGame.Score.ShouldEqual(70);
		}

	}

	public class when_rolling_a_spare_followed_by_all_twos : concerns<BowlingGame>
	{
		private BowlingGame _theGame;

		protected override void context()
		{
			_theGame = build_up();
			_theGame.Roll(2);
			_theGame.Roll(8);
			18.times(() => { _theGame.Roll(2); });
		}

		[Specification]
		public void the_score_is_fourty_eight()
		{
			_theGame.Score.ShouldEqual(48);
		}

	}
}
