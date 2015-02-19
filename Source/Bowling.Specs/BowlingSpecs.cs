using Bowling;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;

namespace specs_for_bowling
{
	public class when_everything_is_wired_up : concerns
	{
		private Game game;

		[SetUp]
		public void Setup()
		{
			game = new Game();
		}

		[Specification]
		public void when_rolling_all_gutter_balls_the_score_is_0() {
			20.times(() =>
			{
				game.Roll(0);
			});
			game.Score().ShouldEqual(0);
		}

		[Specification]
		public void when_rolling_all_2s_the_score_is_40()
		{
			20.times(() =>
				{
					game.Roll(2);
				});
			game.Score().ShouldEqual(40);
		}

		[Specification]
		public void when_the_first_2_rolls_are_2_and_the_rest_are_3_the_score_is_58()
		{
			2.times(() =>
				{
					game.Roll(2);
				});
			18.times(() =>
			{
				game.Roll(3);
			});
			game.Score().ShouldEqual(58);
		}

		[Specification]
		public void when_rolling_alternating_2s_and_5s_the_score_70()
		{
			10.times(() =>
			{
				game.Roll(2);
				game.Roll(5);
			});
			game.Score().ShouldEqual(70);
		}

		[Specification]
		public void when_the_first_frame_is_a_spare_and_the_remaining_rolls_are_all_2_the_score_is_48()
		{
			game.Roll(5);
			game.Roll(5);
			18.times(() =>
			{
				game.Roll(2);
			});
			game.Score().ShouldEqual(48);
		}

		[Specification]
		public void when_the_first_2_frames_are_spare_as_2_and_8_and_the_rest_score_2_the_score_is_56()
		{
			2.times(() =>
			{
				game.Roll(2);
				game.Roll(8);
			});
			16.times(() =>
			{
				game.Roll(2);
			});
			game.Score().ShouldEqual(56);
		}

		[Specification]
		public void when_10_frames_have_been_bowled_do_not_allow_any_more_to_be_bowled()
		{
			9.times(() =>
			{
				game.Roll(2);
				game.Roll(8);
			});
			game.Roll(2);
			game.Roll(0);
			game.Score().ShouldEqual(110);
			// Game is over after the last roll. But, this guy is nuts and wants to keep rolling!
			// His score should NOT increase...
			game.Roll(5);
			game.Score().ShouldEqual(110);
		}

		[Specification]
		public void when_the_first_frame_is_a_strike_and_the_rest_score_2_the_score_is_50()
		{
			game.Roll(10);
			18.times(()=> game.Roll(2));
			game.Score().ShouldEqual(50);
		}

		[Specification]
		public void when_the_first_2_frames_are_strikes_and_the_rest_score_2_the_score_is_68()
		{
			game.Roll(10);
			game.Roll(10);
			16.times(()=> game.Roll(2));
			game.Score().ShouldEqual(68);
		}

		[Specification]
		public void when_rolling_a_perfect_game_the_score_is_300()
		{
			12.times(() => game.Roll(10));
			game.Score().ShouldEqual(300);
		}

        [Specification]
        public void when_rolling_alternate_strikes_and_spares_the_score_is_200()
        {
            5.times(() => { game.Roll(10); game.Roll(5); game.Roll(5); });
            game.Roll(10);
            game.Score().ShouldEqual(200);
        }
	}
}