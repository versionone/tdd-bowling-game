using System;
using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	internal class when_rolling_all_gutters : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();
			
			20.times(() => _game.Roll(0));
		}

		[Specification]
		private void the_score_is_zero()
		{
			_game.Score().should_equal(0);
		}
	}

	internal class when_rolling_all_open_threes : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			20.times(() => _game.Roll(3));
		}

		[Specification]
		private void the_score_is_sixty()
		{
			_game.Score().should_equal(60);
		}
	}


	internal class when_you_roll_a_spare_then_all_threes : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			_game.Roll(4);
			_game.Roll(6); //spare (10 ... + 3) 13

			18.times(() => _game.Roll(3)); //54+13 = 67
		}

		[Specification]
		private void the_score_is_sixty()
		{
			_game.Score().should_equal(67);
		}
	}

	internal class when_you_roll_two_spares_then_all_threes : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			_game.Roll(4);
			_game.Roll(6); //spare (10 ... + 7) 17
			_game.Roll(7);
			_game.Roll(3); //spare (17 + 10 + 3) 30

			16.times(() => _game.Roll(3)); 
		}

		[Specification]
		private void the_score_is_seventy_eight()
		{
			_game.Score().should_equal(78);
		}
	}

	internal class when_you_roll_a_complete_game : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			20.times(() => _game.Roll(3)); 
		}

		[Specification]
		private void rolling_again_fails()
		{
			typeof (GameCompleteException).should_be_thrown_by(() => _game.Roll(3));
		}
	}

	internal class when_you_roll_a_strike_and_then_threes : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			_game.Roll(10);
			18.times(() => _game.Roll(3));
		}

		[Specification]
		private void scores_a_seventy()
		{
			_game.Score().should_equal(70);
		}
	}

	internal class when_you_roll_2_strikes_and_then_threes : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			_game.Roll(10);
			_game.Roll(10);
			16.times(() => _game.Roll(3));
		}

		[Specification]
		private void scores_eight_seven()
		{
			_game.Score().should_equal(87);
		}
	}

	internal class when_you_roll_threes_then_a_spare_on_the_tenth_frame : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			18.times(() => _game.Roll(3)); //9 frames = 54

			_game.Roll(6); //roll 1 of tenth  = 60
			_game.Roll(4); //64
			_game.Roll(4); //bonus = 68
		}

		[Specification]
		private void scores_sixty_eight()
		{
			_game.Score().should_equal(68);
		}
	}

	internal class when_you_roll_all_strikes : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			12.times(() => _game.Roll(10));
		}

		[Specification]
		private void scores_perfect()
		{
			_game.Score().should_equal(300);
		}
	}

	internal class when_you_roll_dutch : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			5.times(() =>
				{
					_game.Roll(10);
					_game.Roll(5);
					_game.Roll(5);
				});
			_game.Roll(10);
		}

		[Specification]
		private void scores_perfect()
		{
			_game.Score().should_equal(200);
		}
	}
}