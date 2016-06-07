using Bowling;
using Bowling.Specs.Infrastructure;
using NUnit.Framework;
using System.Collections.Generic;

/*
 *# TDD Bowling Game
An example of doing Test-Driven Development using Bowling as the domain.

## The game to be played
Below are some scenarios we can use to drive the development of the game.

*_when_10_frames_have_been_bowled,_don't_allow_any_more_to_be_bowled.

*_when_rolling_a_perfect_game,_the_score_is_300.
*_when_rolling_alternate_strikes_and_spares,_the_score_is_200.

*/
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
		readonly Bowl _bowl = new Bowl();

		protected override void context()
		{
			_bowl.PlayGame();
		}

		[Specification]
		public void the_score_is_0()
		{
			_bowl.Score.ShouldEqual(0);
		}
	}

	public class when_rolling_all_2s : concerns
	{
		readonly Bowl _bowl = new Bowl();

		protected override void context()
		{
			_bowl.PlayGame(2);
		}

		[Specification]
		public void the_score_is_40()
		{
			_bowl.Score.ShouldEqual(40);
		}
	}
	
	public class when_the_first_2_rolls_are_2_and_the_rest_are_3 : concerns
	{
		readonly Bowl _bowl = new Bowl();

		protected override void context()
		{
			List<int> pins = new List<int>() {2, 2};
			for (int i = 0; i < 18; i ++)
			{
				pins.Add(3);
			}

			_bowl.PlayGame(pins);
		}

		[Specification]
		public void the_score_is_58()
		{
			_bowl.Score.ShouldEqual(58);
		}
	}
	public class when_rolling_alternating_2s_and_5s : concerns
	{
		readonly Bowl _bowl = new Bowl();

		protected override void context()
		{
			List<int> pins = new List<int>();
			for (int i = 0; i < 10; i++)
			{
				pins.Add(2);
				pins.Add(5);
			}

			_bowl.PlayGame(pins);
		}

		[Specification]
		public void _the_score_70()
		{
			_bowl.Score.ShouldEqual(70);
		}
	}

	public class when_the_first_frame_is_a_spare_and_the_remaining_rolls_are_all_2 : concerns
	{
		readonly Bowl _bowl = new Bowl();

		protected override void context()
		{
			List<int> pins = new List<int>();
			pins.Add(5);
			pins.Add(5);
			for (int i = 0; i < 18; i++)
			{
				pins.Add(2);
			}

			_bowl.PlayGame(pins);
		}

		[Specification]
		public void the_score_is_48()
		{
			_bowl.Score.ShouldEqual(48);
		}
	}
	public class when_the_first_2_frames_are_spare_as_2_8_and_the_rest_score_2 : concerns
	{
		readonly Bowl _bowl = new Bowl();

		protected override void context()
		{
			List<int> pins = new List<int>();
			pins.Add(2);
			pins.Add(8);
			pins.Add(2);
			pins.Add(8);
			for (int i = 0; i < 16; i++)
			{
				pins.Add(2);
			}

			_bowl.PlayGame(pins);
		}

		[Specification]
		public void the_score_is_56()
		{
			_bowl.Score.ShouldEqual(56);
		}
	}

	//DEFERRING UNTIL LATER --KG
	//	public class when_10_frames_have_been_bowled : concerns
	//	{
	//		readonly Bowl _bowl = new Bowl();
	//
	//		protected override void context()
	//		{
	//			List<int> pins = new List<int>();
	//			pins.Add(2);
	//			pins.Add(8);
	//			pins.Add(2);
	//			pins.Add(8);
	//			for (int i = 0; i < 16; i++)
	//			{
	//				pins.Add(2);
	//			}
	//
	//			_bowl.PlayGame(pins);
	//		}
	//
	//		[Specification]
	//		public void dont_allow_any_more_to_be_bowled()
	//		{
	//			_bowl.Score.ShouldEqual(56);
	//		}
	//	}

	public class when_the_first_frame_is_a_strike_and_the_rest_score_2 : concerns
	{
		readonly Bowl _bowl = new Bowl();

		protected override void context()
		{
			List<int> pins = new List<int>();
			pins.Add(10);
			for (int i = 0; i < 18; i++)
			{
				pins.Add(2);
			}

			_bowl.PlayGame(pins);
		}

		[Specification]
		public void the_score_is_50()
		{
			_bowl.Score.ShouldEqual(50);
		}
	}
	public class when_the_first_2_frames_are_strikes_and_the_rest_score_2 : concerns
	{
		readonly Bowl _bowl = new Bowl();

		protected override void context()
		{
			List<int> pins = new List<int>();
			pins.Add(10);
			pins.Add(10);
			for (int i = 0; i < 16; i++)
			{
				pins.Add(2);
			}

			_bowl.PlayGame(pins);
		}

		[Specification]
		public void the_score_is_68()
		{
			_bowl.Score.ShouldEqual(68);
		}
	}

	public class when_rolling_a_perfect_game : concerns
	{
		readonly Bowl _bowl = new Bowl();

		protected override void context()
		{
			List<int> pins = new List<int>();
			for (int i = 0; i < 12; i++)
			{
				pins.Add(10);
			}

			_bowl.PlayGame(pins);
		}

		[Specification]
		public void the_score_is_300()
		{
			_bowl.Score.ShouldEqual(300);
		}
	}
}
