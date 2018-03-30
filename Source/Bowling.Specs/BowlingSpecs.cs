using Bowling.Specs.Infrastructure;
using NUnit.Framework;
using Bowling;
using System;

/*
Below are some scenarios we can use to drive the development of the game.

when rolling all gutter balls, the score is 0.
When_rolling_all_2s_the_score_is_40.
When_the_first_2_rolls_are_2_and_the_rest_are_3_the_score_is_58.
When_rolling_alternating_2s_and_5s_the_score_70.
When_the_first_frame_is_a_spare_and_the_remaining_rolls_are_all_2_the_score_is_48.
When_the_first_2_frames_are_spare_(as_28)_and_the_rest_score_2_the_score_is_56.
When_10_frames_have_been_bowled_don't_allow_any_more_to_be_bowled.
When_the_first_frame_is_a_strike_and_the_rest_score_2_the_score_is_50.
When_the_first_2_frames_are_strikes_and_the_rest_score_2_the_score_is_68.
When_rolling_a_perfect_game_the_score_is_300.
When_rolling_alternate_strikes_and_spares_the_score_is_200.

*/

namespace Bowling.Specs
{
	public class when_everything_is_wired_up
	{
		private bool _itWorked;

		[SetUp]
		public void context()
		{
			_itWorked = true;

		}

		[Test]
		public void it_works()
		{
			_itWorked.ShouldBeTrue();
		}

		public void allGutters()
		{

		}
	}

	public class JohnsTests
	{
		private Game testGame;
		[SetUp]
		public void createGame()
		{
			testGame = new Game();
		}

		[Test]
		public void When_rolling_all_gutter_balls_the_score_is_0()
		{
			for (var i = 0; i < 20; i++)
				testGame.Roll(0);
			testGame.Score().ShouldEqual(0);
		}
		[Test]
		public void When_rolling_all_2s()
		{
			for (var i = 0; i < 20; i++)
				testGame.Roll(2);
			testGame.Score().ShouldEqual(40);
		}
		[Test]
		public void When_the_first_2_rolls_are_2_and_the_rest_are_3s()
		{
			for (var i = 0; i < 2; i++)
				testGame.Roll(2);
			for (var i = 0; i < 18; i++)
				testGame.Roll(3);
			testGame.Score().ShouldEqual(58);
		}

		[Test]
		public void When_rolling_alternating_2s_and_5s()
		{
			for (var i = 0; i < 10; i++)
			{
				testGame.Roll(2);
				testGame.Roll(5);
			}

			testGame.Score().ShouldEqual(70);
		}

		[Test]
		public void When_the_first_frame_is_a_spare_and_the_remaining_rolls_are_all_2()
		{
			testGame.Roll(2);
			testGame.Roll(8);
			for (var i = 0; i < 18; i++)
			{
				testGame.Roll(2);
			}
			testGame.Score().ShouldEqual(48);
		}

		[Test]
		public void When_the_first_2_frames_are_spare_as_2_and_8_and_the_rest_score_2()
		{
			testGame.Roll(2);
			testGame.Roll(8);
			testGame.Roll(2);
			testGame.Roll(8);
			for (var i = 0; i < 16; i++)
			{
				testGame.Roll(2);
			}
			testGame.Score().ShouldEqual(56);
		}

		[Test]
		public void When_10_frames_have_been_bowled_dont_allow_any_more_to_be_bowled()
		{

			typeof(GameOverException).ShouldBeThrownBy(() =>
			{
				for (var i = 0; i < 20; i++)
				{
					testGame.Roll(2);
				}
				testGame.Roll(10);
			});

		}
		[Test]
		public void When_the_first_frame_is_a_strike_and_the_rest_score_2()
		{
			testGame.Roll(10);

			for (var i = 0; i < 18; i++)
			{
				testGame.Roll(2);
			}
			testGame.Score().ShouldEqual(50);
		}
		[Test]
		public void When_the_first_2_frames_are_strikes_and_the_rest_score_2()
		{
			testGame.Roll(10);
			testGame.Roll(10);
			for (var i = 0; i < 16; i++)
			{
				testGame.Roll(2);
			}
			testGame.Score().ShouldEqual(68);
		}

		[Test]
		public void When_rolling_a_perfect_game()
		{
			for (var i = 0; i < 12; i++)
			{
				testGame.Roll(10);
			}
			testGame.Score().ShouldEqual(300);

		}

		[Test]
		public void When_rolling_alternate_strikes_and_spares()
		{


			testGame.Roll(10);

			testGame.Roll(2);
			testGame.Roll(8);

			testGame.Roll(10);

			testGame.Roll(2);
			testGame.Roll(8);

			testGame.Roll(10);

			testGame.Roll(2);
			testGame.Roll(8);

			testGame.Roll(10);

			testGame.Roll(2);
			testGame.Roll(8);

			testGame.Roll(10);

			testGame.Roll(2);
			testGame.Roll(8);
			testGame.Roll(10);

			testGame.Score().ShouldEqual(200);
		}

		

	}
}
