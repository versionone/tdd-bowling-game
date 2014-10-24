using Bowling.Specs.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


/*
10.times(() =>
{
	game.Roll(0);
});
*/
namespace specs_for_bowling
{
	public class Game
	{
		private List<int> _rolls = new List<int>();
		
		private bool _isSpare;

		public int Score()
		{
			var tally = 0;
			var frameNumber = 1;

			for(var i = 0; i < _rolls.Count; i++) {
				var currentRoll = _rolls[i];
				tally += currentRoll;

				if (currentRoll == 10)
				{
					if (i + 1 < _rolls.Count)
					{
						tally += _rolls[i + 1];
					}
					if (i + 2 < _rolls.Count)
					{
						tally += _rolls[i + 2];
					}
					frameNumber++;
				} else if (i < _rolls.Count - 1) {
					//are we in our last roll
					if ((i + 1) % 2 == 0)
					{
						if ((_rolls[i - 1] + currentRoll) == 10)
							tally += _rolls[i + 1];
						frameNumber++;
					}
				}
			}
			
			return tally;
		}

		public void Roll(int pins)
		{
			var frameNumber = 1;

			for (var i = 0; i < _rolls.Count; i++)
			{
				if (i < _rolls.Count - 1)
				{
					if (_rolls[i] == 10)
					{
						frameNumber++;
					} else if ((i + 1) % 2 == 0)
					{
						frameNumber++;
					}
				}
			}

			// 10th frame and is a spare:
			if (_rolls.Count == 20 && _rolls[19] + _rolls[20] == 10) {
				_rolls.Add(pins);
			}
			else if ((frameNumber == 11 || frameNumber == 12) 
				&& _rolls[_rolls.Count-1] == 10) { // 10th frame special case
				_rolls.Add(pins);
			}
			else if (frameNumber < 11)
			{
				_rolls.Add(pins);
			}
			else {
				throw new Exception();
			}
		}
	}

	public class when_everything_is_wired_up : concerns
	{
		private Game game;
		
		[SetUp]
		public void Setup()
		{
			game = new Game();
		}

		[Specification]
		public void when_rolling_all_gutter_balls_the_score_is_0()
		{
			20.times(() =>
			{
				game.Roll(0);
			});

			game.Score().ShouldEqual(0);			
		}

		[Specification]
		public void when_rolling_all_2s()
		{
			20.times(() =>
			{
				game.Roll(2);
			});

			game.Score().ShouldEqual(40);
		}

		[Specification]
		public void when_rolling_two_2_and_all_3s()
		{
			2.times(() =>
			{
				game.Roll(2);
			});

			18.times(() =>
			{
				game.Roll(3);
			});

			game.Score().ShouldEqual(58);
		}

		[Specification]
		public void when_rolling_alternating_2_and_5s()
		{
			10.times(() =>
			{
				game.Roll(2);
				game.Roll(5);
			});

			game.Score().ShouldEqual(70);
		}

		[Specification]
		public void when_rolling_spare_then_all_2s()
		{
			1.times(() =>
			{
				game.Roll(2);
				game.Roll(8);
			});
			18.times(() =>
			{
				game.Roll(2);
			});

			game.Score().ShouldEqual(48);

		}

		[Specification]
		public void when_2frames_spare_then_all_2s()
		{
			2.times(() =>
			{
				game.Roll(2);
				game.Roll(8);
			});
			16.times(() =>
			{
				game.Roll(2);
			});

			game.Score().ShouldEqual(56);
		}

		[Specification]
		[ExpectedException()]
		public void allow_10frames_bowled_only()
		{
			10.times(() =>
			{
				game.Roll(2);
				game.Roll(8);
			});
			game.Roll(4);		
		}

		[Specification]
		public void first_frame_strike_and_then_all_2s()
		{
			1.times(() =>
			{
				game.Roll(10);
			});
			18.times(() =>
			{
				game.Roll(2);
			});
			game.Score().ShouldEqual(50);			
		}
		[Specification]
		public void first_two_frames_strike_then_all_2s()
		{
			2.times(() =>
			{
				game.Roll(10);
			});
			16.times(() =>
			{
				game.Roll(2);
			});
			game.Score().ShouldEqual(68);
		}

		[Specification]
		public void perfect_game()
		{
			13.times(() =>
			{
				game.Roll(10);
			});
			game.Score().ShouldEqual(300);
		}

	}
}

/*
 * when rolling all gutter balls, the score is 0.
xxwhen rolling all 2s, the score is 40.
xxwhen the first 2 rolls are 2 and the rest are 3, the score is 58.
xxwhen rolling alternating 2s and 5s, the score 70.
xxwhen the first frame is a spare and the remaining rolls are all 2, the score is 48.
xxwhen the first 2 frames are spare (as 2,8) and the rest score 2, the score is 56.
xxwhen 10 frames have been bowled, don't allow any more to be bowled.
xxwhen the first frame is a strike and the rest score 2, the score is 50.
xxwhen the first 2 frames are strikes and the rest score 2, the score is 68.
when rolling a perfect game, the score is 300.
when rolling alternate strikes and spares, the score is 200.*/