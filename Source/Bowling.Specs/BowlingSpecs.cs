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

	public class when_rolling_all_gutter_balls : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			20.times(() => _game.Roll(0));
		}

		[Specification]
		public void the_score_is_zero()
		{
			_game.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_twos: concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_40()
		{
			_game.Score.ShouldEqual(40);
		}
	}

	public class when_rolling_two_twos_followed_by_threes : concerns
	{
		private readonly Game _game = new Game();

		protected override void context()
		{
			2.times(() => _game.Roll(2));
			18.times(()=> _game.Roll(3));
		}

		[Specification]
		public void the_score_is_58()
		{
			_game.Score.ShouldEqual(58);
		}
	}
}