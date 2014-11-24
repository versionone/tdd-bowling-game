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
			for (int i = 0; i < 20; i++)
			{
				_game.Roll(0);
			}
		}

		[Specification]
		public void the_score_is_0()
		{
			_game.GetScore().ShouldEqual(0);
		}
	}

	public class when_rolling_all_twos : concerns
	{
		private Game _game;
		protected override void context()
		{
			_game = new Game();
			for (int i = 0; i < 20; i++)
			{
				_game.Roll(2);
			}
		}

		[Specification]
		public void the_score_is_40()
		{
			_game.GetScore().ShouldEqual(40);
		}
	}

	public class when_rolling_two_twos_followed_by_all_threes : concerns
	{
		private Game _game;
		protected override void context()
		{
			_game = new Game();
			_game.Roll(2);
			_game.Roll(2);
			18.times(() => _game.Roll(3));
		}

		[Specification]
		public void the_score_is_58()
		{
			_game.GetScore().ShouldEqual(58);
		}
	}
}

namespace Bowling
{
	public class Game
	{
		private int score;
		public void Roll(int pins)
		{
			score = score + pins;
		}
		public int GetScore()
		{
			return score;
		}
	}
}