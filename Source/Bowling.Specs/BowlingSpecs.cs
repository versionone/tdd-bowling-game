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

	internal class when_you_roll_a_strike_and_then_twos : concerns
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

}