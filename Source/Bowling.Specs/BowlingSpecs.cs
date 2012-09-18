using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public abstract class bowling_concerns : concerns
	{
		protected BowlingGame currentGame;

		protected override void context()
		{
			currentGame = new BowlingGame();
			PlayGame();
		}

		protected abstract void PlayGame();

		protected void AssertScoreIs(int score)
		{
			currentGame.CalculateScore().should_equal(score);
		}
	}

	public class when_rolling_all_gutters : bowling_concerns
	{
		protected override void PlayGame()
		{
			20.times(() => currentGame.Roll(0));
		}

		[Specification]
		public void then_the_score_is_zero()
		{
			AssertScoreIs(0);
		}
	}

	public class when_I_knock_down_nine_pins_in_the_first_frame_only : bowling_concerns
	{
		protected override void PlayGame()
		{
			currentGame.Roll(9);
			19.times(() => currentGame.Roll(0));
		}

		[Specification]
		public void then_the_score_is_nine()
		{
			AssertScoreIs(9);
		}
	}

	public class when_I_knock_down_nine_pins_in_each_frame : bowling_concerns
	{
		protected override void PlayGame()
		{
			10.times(() =>
			         	{
			         		currentGame.Roll(9);
			         		currentGame.Roll(0);
			         	}
					);
		}

		[Specification]
		public void then_the_score_is_90()
		{
			AssertScoreIs(90);
		}
	}

	public class when_I_only_a_get_a_spare_with_a_bonus : bowling_concerns
	{
		protected override void PlayGame()
		{
			currentGame.Roll(9);
			currentGame.Roll(1);

			currentGame.Roll(1);
			currentGame.Roll(0);

			8.times(() =>
			        	{
			        		currentGame.Roll(0);
			        		currentGame.Roll(0);
			        	}
				);
		}

		[Specification]
		public void then_the_score_is_twelve()
		{
			AssertScoreIs(12);
		}
	}

	public class when_I_only_a_get_a_spare_with_a_bonus_in_the_middle_of_a_game : bowling_concerns
	{
		protected override void PlayGame()
		{
			currentGame.Roll(0);
			currentGame.Roll(0);

			currentGame.Roll(9);
			currentGame.Roll(1);

			currentGame.Roll(1);
			currentGame.Roll(0);

			7.times(() =>
			{
				currentGame.Roll(0);
				currentGame.Roll(0);
			}
				);
		}

		[Specification]
		public void then_the_score_is_twelve()
		{
			AssertScoreIs(12);
		}
	}

	public class when_I_only_get_two_spares_in_a_row : bowling_concerns
	{
		protected override void PlayGame()
		{
			currentGame.Roll(1);
			currentGame.Roll(9);

			currentGame.Roll(9);
			currentGame.Roll(1);

			8.times(() =>
			{
				currentGame.Roll(0);
				currentGame.Roll(0);
			}
				);
		}
		[Specification]
		public void the_the_score_is_twenty_nine()
		{
			AssertScoreIs(29);
		}
	}

	public class when_two_spares_two_bonuses : bowling_concerns
	{
		protected override void PlayGame()
		{
			currentGame.Roll(1);
			currentGame.Roll(9);

			currentGame.Roll(9);
			currentGame.Roll(1);

			currentGame.Roll(1);
			currentGame.Roll(0);

			7.times(() =>
			{
				currentGame.Roll(0);
				currentGame.Roll(0);
			}
				);
		}
		[Specification]
		public void the_the_score_is_31()
		{
			AssertScoreIs(31);
		}
	}

	public class when_getting_a_strike_with_bonus_on_first_frame : bowling_concerns
	{
		protected override void PlayGame()
		{
			currentGame.Roll(10);

			currentGame.Roll(1);
			currentGame.Roll(1);

			8.times(() =>
			        	{
			        		currentGame.Roll(0);
			        		currentGame.Roll(0);
			        	}
				);
		}
		[Specification]
		public void the_the_score_is_14()
		{
			AssertScoreIs(14);
		}
	}

	public class when_getting_a_turkey : bowling_concerns
	{
		protected override void PlayGame()
		{
			currentGame.Roll(10); // 30
			currentGame.Roll(10); // 20
			currentGame.Roll(10); // 10

			7.times(() =>
			        	{
			        		currentGame.Roll(0);
			        		currentGame.Roll(0);
			        	}
				);
		}
		[Specification]
		public void the_the_score_is_60()
		{
			AssertScoreIs(60);
		}
	}

	public class when_getting_a_canadian_monkey : bowling_concerns
	{
		protected override void PlayGame()
		{
			currentGame.Roll(10); // 20

			currentGame.Roll(9); // 20
			currentGame.Roll(1);

			currentGame.Roll(10); // 20

			currentGame.Roll(9); // 10
			currentGame.Roll(1);

			6.times(() =>
			{
				currentGame.Roll(0);
				currentGame.Roll(0);
			}
				);
		}
		[Specification]
		public void the_the_score_is_70()
		{
			AssertScoreIs(70);
		}
	}

	public class when_perfect_game : bowling_concerns
	{
		protected override void PlayGame()
		{
			12.times(() => currentGame.Roll(10));
		}

		[Specification]
		public void the_the_score_is_300()
		{
			AssertScoreIs(300);
		}
	}

	public class when_single_pin_every_roll : bowling_concerns
	{
		protected override void PlayGame()
		{
			20.times(() => currentGame.Roll(1));
		}

		[Specification]
		public void the_the_score_is_20()
		{
			AssertScoreIs(20);
		}
	}

	public class when_all_spares_kind : bowling_concerns
	{
		protected override void PlayGame()
		{
			10.times(() =>
			         	{
			         		currentGame.Roll(9);
			         		currentGame.Roll(1);
			         	});
			currentGame.Roll(9);
		}

		[Specification]
		public void the_the_score_is_190()
		{
			AssertScoreIs(190);
		}
	}

	public class when_all_spares_cruel : bowling_concerns
	{
		protected override void PlayGame()
		{
			10.times(() =>
			{
				currentGame.Roll(1);
				currentGame.Roll(9);
			});
			currentGame.Roll(1);
		}

		[Specification]
		public void the_the_score_is_110()
		{
			AssertScoreIs(110);
		}
	}

}