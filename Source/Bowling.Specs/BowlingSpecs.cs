using Bowling.Specs.Infrastructure;
using Bowling;

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
			_itWorked.should_be_true("we're ready to roll!");
		}
	}

	public class when_rolling_all_gutter_balls : concerns
	{

		private Game _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new Game();
		}

		[Specification]
		public void score_is_zero()
		{
			20.times(() => _bowlingGame.Roll(0)); //roll ten frames, miss everything
			_bowlingGame.Score.should_equal(0);
		}
	}

	public class when_the_first_frame_is_a_spare_thens_2s : concerns
	{
		private Game _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new Game();
		}

		[Specification]
		public void score_is_48()
		{
			2.times(() => _bowlingGame.Roll(5)); //spare
			18.times(() => _bowlingGame.Roll(2));
			_bowlingGame.Score.should_equal(48);
		}
	}

	public class when_the_first_two_frames_are_spares_then_2s : concerns
	{
		private Game _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new Game();
		}

		[Specification]
		public void score_is_56()
		{
			_bowlingGame.Roll(2); //spares
			_bowlingGame.Roll(8); //spares
			_bowlingGame.Roll(2); //spares
			_bowlingGame.Roll(8); //spares
			16.times(() => _bowlingGame.Roll(2));
			_bowlingGame.Score.should_equal(56);
		}
	}

	public class when_the_ten_frames_bowled : concerns
	{
		private Game _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new Game();
		}

		[Specification]
		public void the_game_is_over()
		{
			_bowlingGame.Roll(2); //spares
			_bowlingGame.Roll(8); //spares
			_bowlingGame.Roll(2); //spares
			_bowlingGame.Roll(8); //spares
			16.times(() => _bowlingGame.Roll(2));
			_bowlingGame.Score.should_equal(56);
			_bowlingGame.IsGameOver.should_equal(true);
		}
	}

	public class when_the_first_frame_strike_then_2s : concerns
	{
		private Game _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new Game();
		}

		[Specification]
		public void the_score_is_50()
		{
			_bowlingGame.Roll(10); //strike
			18.times(() => _bowlingGame.Roll(2));
			_bowlingGame.Score.should_equal(50);
		}
	}

	public class when_the_first_two_frames_are_strike_then_2s : concerns
	{
		private Game _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new Game();
		}

		[Specification]
		public void the_score_is_68()
		{
			2.times(() => _bowlingGame.Roll(10)); //strikes
			16.times(() => _bowlingGame.Roll(2));
			_bowlingGame.Score.should_equal(68);
		}
	}

	public class when_perfect_game : concerns
	{
		private Game _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new Game();
		}

		[Specification]
		public void the_score_is_300()
		{
			9.times(() => _bowlingGame.Roll(10)); //strikes
			3.times(() => _bowlingGame.Roll(10)); //tenth frame
			_bowlingGame.Score.should_equal(300);
		}
	}

	public class when_alternating_strikes_and_spares : concerns
	{
		private Game _bowlingGame;

		protected override void context()
		{
			_bowlingGame = new Game();
		}

		[Specification]
		public void the_score_is_200()
		{
			4.times(() =>
				        {
					        _bowlingGame.Roll(10);
					        _bowlingGame.Roll(2);
					        _bowlingGame.Roll(8);
				        }); //alt strikes and spares
			_bowlingGame.Roll(10); //ninth
			_bowlingGame.Roll(2); //tenth
			_bowlingGame.Roll(8);
			_bowlingGame.Roll(10); //tenth
			_bowlingGame.Score.should_equal(200);
		}
	}
}