using System;
using Bowling;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;
using StructureMap.Pipeline;

namespace specs_for_bowling
{
	/*
	 * 
	 * # TDD Bowling Game
An example of doing Test-Driven Development using Bowling as the domain.

## The game to be played
Below are some scenarios we can use to drive the development of the game.

* when rolling all gutter balls, the score is 0.
* when rolling all 2s, the score is 40.
* when the first 2 rolls are 2 and the rest are 3, the score is 58.
* when rolling alternating 2s and 5s, the score 70.
* when the first frame is a spare and the remaining rolls are all 2, the score is 48.
* when the first 2 frames are spare (as 2,8) and the rest score 2, the score is 56.
* when 10 frames have been bowled, don't allow any more to be bowled.
* when the first frame is a strike and the rest score 2, the score is 50.
* when the first 2 frames are strikes and the rest score 2, the score is 68.
* when rolling a perfect game, the score is 300.
* when rolling alternate strikes and spares, the score is 200.
	 * 
	 */

	public class when_rolling_all_gutter_balls : concerns
	{
		private int? _score;

		protected override void context()
		{
			ScoreSheet scoreSheet = new ScoreSheet();
			_score = scoreSheet.CalculateScore();
		}

		[Specification]
		public void the_score_should_be_zero()
		{
			_score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_gutter_balls_for_three_frames : concerns
	{
		private int? _score;
		private ScoreSheet scoreSheet;

		protected override void context()
		{
			scoreSheet = new ScoreSheet();
			scoreSheet.AddFrame(new Frame());
			scoreSheet.AddFrame(new Frame());
			scoreSheet.AddFrame(new Frame());

			_score = scoreSheet.CalculateScore();
		}

		[Specification]
		public void there_are_three_frames()
		{
			scoreSheet.Frames.Count.ShouldEqual(3);
		}

		[Specification]
		public void the_score_should_be_zero()
		{
			_score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_twos : concerns
	{
		private int? _score;
		private ScoreSheet scoreSheet;

		protected override void context()
		{
			scoreSheet = new ScoreSheet();
			for (var i = 0; i < 10; i++)
			{
				scoreSheet.AddFrame(new Frame() {FirstRoll = 2, SecondRoll = 2});
			}
			_score = scoreSheet.CalculateScore();
		}

		[Specification]
		public void the_score_should_be_forty()
		{
			_score.ShouldEqual(40);
		}
	}

	public class when_rolling_twos_for_the_first_two_frames_and_threes_for_the_remaining_frames : concerns
	{
		private int? _score;
		private ScoreSheet scoreSheet;

		protected override void context()
		{
			scoreSheet = new ScoreSheet();
			scoreSheet.AddFrame(new Frame() { FirstRoll = 2, SecondRoll = 2 });
			for (var i = 1; i < 10; i++)
			{
				scoreSheet.AddFrame(new Frame(){ FirstRoll = 3, SecondRoll = 3});
			}
			_score = scoreSheet.CalculateScore();
		}

		[Specification]
		public void the_score_should_be_fifty_eight()
		{
			_score.ShouldEqual(58);
		}
	}

	public class when_rolling_alternating_twos_and_fives : concerns
	{
		private int? _score;
		private ScoreSheet scoreSheet;

		protected override void context()
		{
			scoreSheet = new ScoreSheet();
			for (var i = 0; i < 10; i++)
			{
				if (i%2 != 0)
				{
					scoreSheet.AddFrame(new Frame() {FirstRoll = 2, SecondRoll = 2});
				}
				else
				{
					scoreSheet.AddFrame(new Frame() {FirstRoll = 5, SecondRoll = 5});
				}
			}
			_score = scoreSheet.CalculateScore();
		}

		[Specification]
		public void the_score_should_be_seventy()
		{
			_score.ShouldEqual(70);
		}
	}

	public class when_rolling_a_spare_and_the_twos_for_the_remaing_frames : concerns
	{
		private int? _score;
		private ScoreSheet scoreSheet;

		protected override void context()
		{
			scoreSheet = new ScoreSheet();
			scoreSheet.AddFrame(new Frame(){FirstRoll = 3, SecondRoll = 7});
			for (var i = 1; i < 10; i++)
			{
				scoreSheet.AddFrame(new Frame(){FirstRoll = 2, SecondRoll = 2});
			}
			_score = scoreSheet.CalculateScore();
		}

		[Specification]
		public void the_score_should_be_forty_eight()
		{
			_score.ShouldEqual(48);
		}
	}

	public class when_rolling_two_spares_with_first_roll_two_second_roll_eight_and_rolling_twos_for_the_remaing_frames : concerns
	{
		private int? _score;
		private ScoreSheet scoreSheet;

		protected override void context()
		{
			scoreSheet = new ScoreSheet();
			scoreSheet.AddFrame(new Frame() { FirstRoll = 2, SecondRoll = 8 });
			scoreSheet.AddFrame(new Frame() { FirstRoll = 2, SecondRoll = 8 });

			for (var i = 2; i < 10; i++)
			{
				scoreSheet.AddFrame(new Frame() { FirstRoll = 2, SecondRoll = 2 });
			}
			_score = scoreSheet.CalculateScore();
		}

		[Specification]
		public void the_score_should_be_fifty_six()
		{
			_score.ShouldEqual(56);
		}
	}

	public class when_ten_frames_have_been_bowled_dont_allow_another_frame : concerns
	{
		private int? _score;
		private ScoreSheet scoreSheet;

		protected override void context()
		{
			scoreSheet = new ScoreSheet();
			scoreSheet.AddFrame(new Frame() { FirstRoll = 2, SecondRoll = 8 });
			scoreSheet.AddFrame(new Frame() { FirstRoll = 2, SecondRoll = 8 });

			for (var i = 2; i < 10; i++)
			{
				scoreSheet.AddFrame(new Frame() { FirstRoll = 2, SecondRoll = 2 });
			}
			_score = scoreSheet.CalculateScore();
		}

		[Specification]
		public void the_add_frame_method_throws_an_exception()
		{
			try
			{
				scoreSheet.AddFrame(new Frame());
			}
			catch(TooManyFramesException e)
			{
				Assert.Pass();
			}
			Assert.Fail();
		}
	}
}