using System;
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

	//when rolling alternating 2s and 5s, the score 70.
	public class when_rolling_alternate_2s_and_5s : concerns
	{
		private Scoreboard _scoreboard;

		protected override void context()
		{
			_scoreboard = new Scoreboard();

			10.times(() =>
			{
				_scoreboard.Record(2);
				_scoreboard.Record(5);
			});
		}

		[Specification]
		public void the_score_is_70()
		{
			_scoreboard.Score.ShouldEqual(70);
		}
	}

	// when the first frame is a spare and the remaining rolls are all 2, the score is 48.
	public class when_rolling_a_spare_followed_by_2s : concerns
	{
		private Scoreboard _scoreboard;

		protected override void context()
		{
			_scoreboard = new Scoreboard();

			_scoreboard.Record(3);
			_scoreboard.Record(7);

			9.times(() =>
			{
				_scoreboard.Record(2);
				_scoreboard.Record(2);
			});
		}

		[Specification]
		public void the_score_is_48()
		{
			_scoreboard.Score.ShouldEqual(48);
		}
	}

	// when the first 2 frames are spare (as 2,8) and the rest score 2, the score is 56.
	public class when_rolling_two_2_8_spares_followed_by_2s : concerns
	{
		private Scoreboard _scoreboard;

		protected override void context()
		{
			_scoreboard = new Scoreboard();

			2.times(() =>
			{
				_scoreboard.Record(2);
				_scoreboard.Record(8);
			});

			8.times(() =>
			{
				_scoreboard.Record(2);
				_scoreboard.Record(2);
			});
		}

		[Specification]
		public void the_score_is_56()
		{
			_scoreboard.Score.ShouldEqual(56);
		}
	}

	// when 10 frames have been bowled, don't allow any more to be bowled.
	public class when_10_frames_are_complete : concerns
	{
		private Scoreboard _scoreboard;

		protected override void context()
		{
			_scoreboard = new Scoreboard();

			20.times(() => _scoreboard.Record(0));
		}

		[Specification]
		public void no_more_rolls_are_permitted()
		{
			typeof (Exception).ShouldBeThrownBy(() => _scoreboard.Record(0));
		}
	}

	// when the first frame is a strike and the rest score 2, the score is 50.
	public class when_rolling_a_strike_followed_by_2s : concerns
	{
		private Scoreboard _scoreboard;

		protected override void context()
		{
			_scoreboard = new Scoreboard();

			_scoreboard.Record(10);

			18.times(() => _scoreboard.Record(2));
		}

		[Specification]
		public void the_score_is_50()
		{
			_scoreboard.Score.ShouldEqual(50);
		}
	}

}