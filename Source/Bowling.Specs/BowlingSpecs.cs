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
			currentGame.CalculateScore().should_equal(90);
		}
	}

	public class when_I_only_a_get_a_spare_with_a_bonus : bowling_concerns
	{
		protected override void PlayGame()
		{
			// frame 1
			currentGame.Roll(9);
			currentGame.Roll(1);

			// frame 2
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
			currentGame.CalculateScore().should_equal(12);
		}
	}

}