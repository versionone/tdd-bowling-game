using Bowling;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;
using System;

namespace specs_for_bowling
{
	public class when_its_all_gutters : concerns
	{
		Game game = new Game();

		protected override void context()
		{
			20.times(() => game.Roll(0));
		}

		[Specification]
		public void then_the_score_is_0()
		{
			game.Score.ShouldEqual(0);
		}
	}

	public class when_its_all_2s : concerns
	{
		Game game = new Game();

		protected override void context()
		{
			20.times(() => game.Roll(2));
		}
		[Specification]
		public void then_the_score_is_40()
		{
			game.Score.ShouldEqual(40);
		}
	}

	public class when_the_first_frame_is_a_spare_and_the_remaining_rolls_are_all_2: concerns
	{
		private Game game = new Game();

		protected override void context()
		{
			game.Roll(8);
			19.times(() => game.Roll(2));
		}

		[Specification]
		public void then_the_score_is_48()
		{
			game.Score.ShouldEqual(48);
		}
	}

	public class when_the_first_two_frames_are_spare_and_the_remaining_rolls_are_all_2 : concerns
	{
		private Game game = new Game();

		protected override void context()
		{
			game.Roll(2);
			game.Roll(8);
			game.Roll(2);
			game.Roll(8);
			16.times(() => game.Roll(2));
		}

		[Specification]
		public void then_the_score_is_56()
		{
			game.Score.ShouldEqual(56);
		}
	}

	public class when_10_frames_are_bowled : concerns
	{
		private Game game = new Game();

		[Specification]
		[ExpectedException(typeof(Exception))]
		public void then_20_rolls_with_no_bonuses()
		{
			20.times(() =>game.Roll(4));
			game.Roll(4);
		}

		[Specification]
		[ExpectedException(typeof(Exception))]
		public void then_12_rolls_with_all_strikes()
		{
			12.times(() => game.Roll(10));
			game.Roll(4);
		}

		[Specification]
		[ExpectedException(typeof(Exception))]
		public void then_21_rolls_with_all_spares()
		{
			21.times(() => game.Roll(5));
			game.Roll(4);
		}
		[Specification]
		public void count_completed_frames()
		{
			game.Roll(2);
			game.CountCompletedFrames().ShouldEqual(0);
			game.Roll(8);
			game.CountCompletedFrames().ShouldEqual(0);
			game.Roll(2);
			game.CountCompletedFrames().ShouldEqual(1);
			game.Roll(8);
			game.CountCompletedFrames().ShouldEqual(1);
			16.times(() => game.Roll(2));
			game.CountCompletedFrames().ShouldEqual(10);
		}
	}

	public class when_the_first_frame_is_a_strike : concerns
	{
		private Game game = new Game();

		protected override void context()
		{
			game.Roll(10);
			18.times(() => game.Roll(2));
		}

		[Specification]
		public void then_the_score_is_50()
		{
			game.Score.ShouldEqual(50);
		}
	}
}