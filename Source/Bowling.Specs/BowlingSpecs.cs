using Bowling;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;

namespace specs_for_bowling
{
	public class when_its_all_gutter_balls : concerns
	{
		private BowlingGame _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new BowlingGame();
		}

		[Specification]
		public void the_score_is_zero()
		{
			20.times(() => _bowlingGame.Roll(0));
			_bowlingGame.Score.ShouldEqual(0);
		}
	}

	public class when_it_alternates_nines_and_gutters : concerns
	{
		private BowlingGame _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new BowlingGame();
		}

		[Specification]
		public void the_score_is_90()
		{
			10.times(() =>
			{
				_bowlingGame.Roll(0);
				_bowlingGame.Roll(9);
			});
			_bowlingGame.Score.ShouldEqual(90);
		}
	}

	public class when_the_first_frame_is_a_spare_and_the_rest_score_2 : concerns
	{
		private BowlingGame _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new BowlingGame();
			_bowlingGame.Roll(8);
			_bowlingGame.Roll(2);
			18.times(() => _bowlingGame.Roll(2));
		}

		[Specification]
		public void the_first_frame_is_a_spare()
		{
			_bowlingGame.IsSpare(8, 2);
			_bowlingGame.CalculateScore();
			_bowlingGame.Frames[0].ShouldEqual(12);
		}
		[Specification]
		public void the_score_is_48()
		{

			_bowlingGame.Score.ShouldEqual(48);
		}
	}

	public class when_the_first_2_frames_are_spares_and_the_rest_score_2 : concerns
	{
		private BowlingGame _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new BowlingGame();
			_bowlingGame.Roll(8);
			_bowlingGame.Roll(2);
			_bowlingGame.Roll(6);
			_bowlingGame.Roll(4);

			16.times(() => _bowlingGame.Roll(2));
		}

		[Specification]
		public void the_first_frame_is_a_spare()
		{
			_bowlingGame.IsSpare(8, 2);
			_bowlingGame.Frames[0].ShouldEqual(16);
		}
		[Specification]
		public void the_second_frame_is_a_spare()
		{
			_bowlingGame.IsSpare(6, 4);
			_bowlingGame.CalculateScore();
			_bowlingGame.Frames[1].ShouldEqual(12);
		}
		[Specification]
		public void the_score_is_60()
		{

			_bowlingGame.Score.ShouldEqual(60);
		}
	}

	public class when_10_frames_have_been_bowled : concerns
	{
		private BowlingGame _bowlingGame;
		protected override void context()
		{
			_bowlingGame = new BowlingGame();
			_bowlingGame.Roll(8);
			_bowlingGame.Roll(2);
			_bowlingGame.Roll(6);
			_bowlingGame.Roll(4);

			16.times(() => _bowlingGame.Roll(2));
		}

		[Specification]
		[ExpectedException(typeof(BowlingGame.GameOverException), ExpectedMessage = "The game is over!")]
		public void cannot_play_after_the_game_is_over()
		{
			_bowlingGame.Roll(3);
		}
	}

	public class when_the_first_frame_is_a_strike_and_the_rest_score_2 : concerns
	{
		private BowlingGame _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new BowlingGame();
			_bowlingGame.Roll(10);
			18.times(() => _bowlingGame.Roll(2));
		}

		[Specification]
		public void the_first_frame_is_a_strike()
		{
			_bowlingGame.IsStrike(10);
			_bowlingGame.Frames[0].ShouldEqual(14);
		}
		[Specification]
		public void the_score_is_50()
		{

			_bowlingGame.Score.ShouldEqual(50);
		}
	}
	public class when_the_first_2_frames_are_strikes_and_the_rest_score_2 : concerns
	{
		private BowlingGame _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new BowlingGame();
			_bowlingGame.Roll(10);
			_bowlingGame.Roll(10);
			16.times(() => _bowlingGame.Roll(2));
		}

		[Specification]
		public void the_first_frame_is_a_strike()
		{
			_bowlingGame.IsStrike(10);
			_bowlingGame.Frames[0].ShouldEqual(22);
		}
		[Specification]
		public void the_second_frame_is_a_strike()
		{
			_bowlingGame.Frames[1].ShouldEqual(14);
		}
		[Specification]
		public void the_score_is_68()
		{

			_bowlingGame.Score.ShouldEqual(68);
		}
	}
}