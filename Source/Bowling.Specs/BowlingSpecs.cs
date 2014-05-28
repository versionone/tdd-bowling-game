using System;
using System.Runtime.Versioning;
using System.Security.Policy;
using Bowling.Specs.Infrastructure;
using Bowling;
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
		private int _theScore;
		protected override void context()
		{
			// roll a full game of gutter-balls
			Game game = new Game();
			for (int i = 1; i < 21; i++)
			{
				game.Roll(0);
			}
			_theScore = game.score;
		}

		[Specification]
		public void the_score_is_zero()
		{
			_theScore.ShouldEqual(0);
		}
	}

	public class when_rolling_all_2s: concerns
	{
		private int _theScore;
		protected override void context()
		{
			Game game = new Game();
			for (int i = 1; i < 21; i++)
			{
				game.Roll(2);
			}
			_theScore = game.score;
		}

		[Specification]
		public void the_score_is_forty()
		{
			_theScore.ShouldEqual(40);
		}
	}
	public class when_rolling_two_2s_then_3s: concerns
	{
		private int _theScore;
		protected override void context()
		{
			Game game = new Game();
			game.Roll(2);
			game.Roll(2);
			for (int i = 3; i < 21; i++)
			{
				game.Roll(3);
			}
			_theScore = game.score;
		}

		[Specification]
		public void the_score_is_fifty_eight()
		{
			_theScore.ShouldEqual(58);
		}
	}
	public class when_rolling_twos_and_fives: concerns
	{
		private int _theScore;
		protected override void context()
		{
			Game game = new Game();
			for (int i = 1; i < 21; i++)
			{
				if (i%2 == 0)
				{
					game.Roll(5);
				}
				else
				{
					game.Roll(2);
				}
				
			}
			_theScore = game.score;
		}

		[Specification]
		public void the_score_is_seventy()
		{
			_theScore.ShouldEqual(70);
		}
	}
	public class when_rolling_a_spare_and_2s: concerns
	{
		private int _theScore;
		protected override void context()
		{
			Game game = new Game();
			game.Roll(5);
			game.Roll(5);
			for (int i = 3; i < 21; i++)
			{
				game.Roll(2);
			}
			_theScore = game.score;
		}

		[Specification]
		public void the_score_is_fortyEight()
		{
			_theScore.ShouldEqual(48);
		}
	}
	public class when_rolling_two_spares_and_2s: concerns
	{
		private int _theScore;
		protected override void context()
		{
			Game game = new Game();
			game.Roll(2);
			game.Roll(8);
			game.Roll(2);
			game.Roll(8);
			for (int i = 5; i < 21; i++)
			{
				game.Roll(2);
			}
			_theScore = game.score;
		}

		[Specification]
		public void the_score_is_fifty_six()
		{
			_theScore.ShouldEqual(56);
		}
	}
	public class when_20_rolls_are_thrown_stop: concerns
	{
		private int _theScore;
		private Game game;
		protected override void context()
		{
			game = new Game();
			for (int i = 1; i < 21; i++)
			{
				game.Roll(2);
			}
			_theScore = game.score;
		}

		[Specification]
		public void do_not_allow_more_than_20_rolls()
		{
			typeof(Exception).ShouldBeThrownBy(()=>game.Roll(2));
		}
	}

	public class when_rolling_10_then_2s: concerns
	{
		private int _theScore;
		private Game game;
		protected override void context()
		{
			game = new Game();
			game.Roll(10);
			for (int i = 2; i < 20; i++)
			{
				game.Roll(2);
			}
			_theScore = game.score;
		}

		[Specification]
		public void the_score_is_fifty()
		{
			_theScore.ShouldEqual(50);
		}
	}
	public class when_rolling_10s_then_2s: concerns
	{
		private int _theScore;
		private Game game;
		protected override void context()
		{
			game = new Game();
			game.Roll(10);
			game.Roll(10);
			for (int i = 3; i < 19; i++)
			{
				game.Roll(2);
			}
			_theScore = game.score;
		}

		[Specification]
		public void the_score_is_sixty_eight()
		{
			_theScore.ShouldEqual(68);
		}
	}
	public class when_rolling_10s: concerns
	{
		private int _theScore;
		private Game game;
		protected override void context()
		{
			game = new Game();
			for (int i = 1; i < 13; i++)
			{
				game.Roll(10);
			}
			_theScore = game.score;
		}

		[Specification]
		public void the_score_is_three_hundred()
		{
			_theScore.ShouldEqual(300);
		}
	}
	public class when_alternating_strikes_and_spares: concerns
	{
		private int _theScore;
		private Game game;
		protected override void context()
		{
			game = new Game();
			game.Roll(10);
			game.Roll(5);
			game.Roll(5);
			game.Roll(10);
			game.Roll(5);
			game.Roll(5);
			game.Roll(10);
			game.Roll(5);
			game.Roll(5);
			game.Roll(10);
			game.Roll(5);
			game.Roll(5);
			game.Roll(10);
			game.Roll(5);
			game.Roll(5);
			game.Roll(10);
			_theScore = game.score;
		}

		[Specification]
		public void the_score_is_two_hundred()
		{
			_theScore.ShouldEqual(200);
		}
	}
}