using Bowling;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;
using System.Collections.Generic;

/*
 *# TDD Bowling Game
An example of doing Test-Driven Development using Bowling as the domain.

## The game to be played
Below are some scenarios we can use to drive the development of the game.

*_
*_when_rolling_alternating_2s_and_5s,_the_score_70.
*_when_the_first_frame_is_a_spare_and_the_remaining_rolls_are_all_2,_the_score_is_48.
*_when_the_first_2_frames_are_spare_(as_2,8)_and_the_rest_score_2,_the_score_is_56.
*_when_10_frames_have_been_bowled,_don't_allow_any_more_to_be_bowled.
*_when_the_first_frame_is_a_strike_and_the_rest_score_2,_the_score_is_50.
*_when_the_first_2_frames_are_strikes_and_the_rest_score_2,_the_score_is_68.
*_when_rolling_a_perfect_game,_the_score_is_300.
*_when_rolling_alternate_strikes_and_spares,_the_score_is_200.

*/
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
		readonly Bowl _bowl = new Bowl();

		protected override void context()
		{
			_bowl.PlayGame();
		}

		[Specification]
		public void the_score_is_0()
		{
			_bowl.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_2s : concerns
	{
		readonly Bowl _bowl = new Bowl();

		protected override void context()
		{
			_bowl.PlayGame(2);
		}

		[Specification]
		public void the_score_is_40()
		{
			_bowl.Score.ShouldEqual(40);
		}
	}
	
	public class when_the_first_2_rolls_are_2_and_the_rest_are_3 : concerns
	{
		readonly Bowl _bowl = new Bowl();

		protected override void context()
		{
			List<int> pins = new List<int>() {2, 2};
			for (int i = 0; i < 18; i ++)
			{
				pins.Add(3);
			}

			_bowl.PlayGame(pins);
		}

		[Specification]
		public void the_score_is_58()
		{
			_bowl.Score.ShouldEqual(58);
		}
	}

}
