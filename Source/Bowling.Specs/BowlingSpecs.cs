using System;
using Bowling;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;

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

	public class when_rolling_all_gutter_balls : concerns<Game>
	{
		private Game _game;
		protected override void context()
		{
			_game = build_up();

			20.times(() => _game.Roll(0));
		}

		[Specification]
		public void the_score_is_zero()
		{
			_game.Score.ShouldEqual(0);
		}
	}
	public class when_rolling_all_2s : concerns<Game>
	{
		private Game _game;
		protected override void context()
		{
			_game = build_up();

			20.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_forty()
		{
			_game.Score.ShouldEqual(40);
		}
	}
	public class when_first_2_rolls_are_2s_and_rest_are_3s : concerns<Game>
	{
		private Game _game;
		protected override void context()
		{
			_game = build_up();

			2.times(() => _game.Roll(2));
			18.times(() => _game.Roll(3));
		}

		[Specification]
		public void the_score_is_fifty_eight()
		{
			_game.Score.ShouldEqual(58);
		}
	}
	public class when_rolling_alternating_2s_and_5s : concerns<Game>
	{
		private Game _game;
		protected override void context()
		{
			_game = build_up();

			10.times(() =>
			{
				_game.Roll(2);
				_game.Roll(5);
			});
		}

		[Specification]
		public void the_score_is_seventy()
		{
			_game.Score.ShouldEqual(70);
		}
	}
	public class when_first_frame_is_a_spare_and_remaining_rolls_are_2s : concerns<Game>
	{
		private Game _game;
		protected override void context()
		{
			_game = build_up();

			_game.Roll(5);
			_game.Roll(5);
			18.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_forty_eight()
		{
			_game.Score.ShouldEqual(48);
		}
	}
	public class when_first_2_frames_are_spares_and_remaining_rolls_are_2s : concerns<Game>
	{
		private Game _game;
		protected override void context()
		{
			_game = build_up();

			2.times(() =>
			{
				_game.Roll(2);
				_game.Roll(8);
			});
			
			16.times(() => _game.Roll(2));
		}

		[Specification]
		public void the_score_is_fifty_six()
		{
			_game.Score.ShouldEqual(56);
		}
	}
	public class when_10_frames_have_been_bowled : concerns<Game>
	{
		private Game _game;
		protected override void context()
		{
			_game = build_up();

			20.times(() => _game.Roll(1));
		}

		[Specification]
		[ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "Game Over")]
		public void do_not_allow_anymore_to_be_bowled()
		{
			_game.Roll(1);
		}
	}
/*
	public class when_10_frames_have_been_bowled_in_a_different_way : concerns<Game>
	{
		private Game _game;
		protected override void context()
		{
			_game = build_up();

			12.times(() => _game.Roll(10));
		}

		[Specification]
		[ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "Game Over")]
		public void do_not_allow_anymore_to_be_bowled()
		{
			_game.Roll(1);
		}
	}
*/
}
