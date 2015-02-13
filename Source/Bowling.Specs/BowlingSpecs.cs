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
		private Game _game;
		protected override void context()
		{
			_game = new Game();
			for (int i = 1; i <= 20; i++)
			{
				_game.Roll(0);
			}
		}

		[Specification]
		public void the_score_is_zero()
		{
			_game.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_2s : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			for (int i = 1; i <= 20; i++)
			{
				_game.Roll(2);
			}
		}

		[Specification]
		public void the_score_is_40()
		{
			_game.Score.ShouldEqual(40);
		}
	}


	public class when_first_two_rolls_are_twos_and_the_rest_are_threes : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			_game.Roll(2);
			_game.Roll(2);
			for (int i = 1; i <= 18; i++)
			{
				_game.Roll(3);
			}
		}

		[Specification]
		public void the_score_is_58()
		{
			_game.Score.ShouldEqual(58);
		}
	}

}