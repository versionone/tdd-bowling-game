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

	public class when_rolling_all_gutter_balls : concerns
	{
		private Scoreboard _scoreboard;

		protected override void context()
		{
			_scoreboard = new Scoreboard();

			20.times(() => _scoreboard.Record(0));
		}

		[Specification]
		public void the_score_is_zero()
		{
			_scoreboard.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_2s : concerns
	{
		private Scoreboard _scoreboard;

		protected override void context()
		{
			_scoreboard = new Scoreboard();

			20.times(() => _scoreboard.Record(2));
		}

		[Specification]
		public void the_score_is_40()
		{
			_scoreboard.Score.ShouldEqual(40);
		}
	}

	// when the first 2 rolls are 2 and the rest are 3, the score is 58.
	public class when_rolling_2_2s_then_3s : concerns
	{
		private Scoreboard _scoreboard;

		protected override void context()
		{
			_scoreboard = new Scoreboard();

			_scoreboard.Record(2);
			_scoreboard.Record(2);
			18.times(() => _scoreboard.Record(3));
		}

		[Specification]
		public void the_score_is_58()
		{
			_scoreboard.Score.ShouldEqual(58);
		}
	}
}