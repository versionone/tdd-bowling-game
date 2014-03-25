using Bowling;
using Bowling.Specs.Infrastructure;

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
}