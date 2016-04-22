using Bowling;
using Bowling.Specs.Infrastructure;
using Gallio.Framework.Assertions;

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
		private Game game;
		protected override void context()
		{
			game = new Game();
		}

		[Specification]
		public void the_score_is_0()
		{
			// assert that the score is 0
			game.getScore().ShouldEqual(0);
		}
	}

	/*
	 
*_when_rolling_all_2s_the_score_is_40.
*_when_the_first_2_rolls_are_2_and_the_rest_are_3_the_score_is_58.
*_when_rolling_alternating_2s_and_5s_the_score_70.
*_when_the_first_frame_is_a_spare_and_the_remaining_rolls_are_all_2_the_score_is_48.
*_when_the_first_2_frames_are_spare_(as_28)_and_the_rest_score_2_the_score_is_56.
*_when_10_frames_have_been_bowled_don't_allow_any_more_to_be_bowled.
*_when_the_first_frame_is_a_strike_and_the_rest_score_2_the_score_is_50.
*_when_the_first_2_frames_are_strikes_and_the_rest_score_2_the_score_is_68.
*_when_rolling_a_perfect_game_the_score_is_300.
*_when_rolling_alternate_strikes_and_spares_the_score_is_200._
	 */
}