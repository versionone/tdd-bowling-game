using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		public BowlingGame()
		{
			frames = new List<Frame>(10);
			for (int i = 0; i < 10; i++)
				frames.Add(new Frame());
			// fill in list of frames? (option a)
			//Score = 0;
		}

		private int CurrentFrameIndex { get; set; } 

		private List<Frame> frames { get; set; }

		public int Score
		{
			get
			{
				// loop through frames and tally score...
				int score = 0;
				for (int i = 0; i < frames.Count; i ++)
				{
					Frame frame = frames[i];
					// Frame .Score needs to be smarter.. able to figure out bonuses
					score += frame.SumOfPinsKnockedDown;
					if (frame.NeedsBonus())
					{
						// peek forward/ determine bonus
						Frame nextFrame = frames[i + 1];

						// Spare bonus (or a strike) bonus is the next ball
						int bonusScore = nextFrame.Rolls[0].PinsKnockedDown;

						// is frame a strike?
						// if it is, then peek ahead another roll, and add to that to the bonus too
						if (frame.IsStrike())
						{
							if (nextFrame.IsStrike())
							{
								// need to get a roll from the following frame
								Frame nextNextFrame = frames[i + 2];
								bonusScore += nextNextFrame.Rolls[0].PinsKnockedDown;
							}
							else
								bonusScore += nextFrame.Rolls[1].PinsKnockedDown;

						}


						score += bonusScore;
					}
				}
				return score; 
			}
		}

		public void Roll(int pinsKnockedDown)
		{
			// is the game over yet??!
			if (CurrentFrameIndex == 10)
				throw new GameOverException();

			var r = new Roll { PinsKnockedDown = pinsKnockedDown };
			frames[CurrentFrameIndex].Rolls.Add(r);

			if (frames[CurrentFrameIndex].IsDone())
				CurrentFrameIndex += 1;
		}
	}

	public class Frame
	{
		public List<Roll> Rolls { get; set; }

		public bool IsDone()
		{
			if (Rolls.Count == 2 || SumOfPinsKnockedDown == 10)
				return true;
			else
				return false;
		}

		public bool NeedsBonus()
		{
			if (Rolls.Sum(x => x.PinsKnockedDown) == 10)
				return true;
			else
				return false;
		}

		public bool IsStrike()
		{
			if (Rolls.Count == 1 && NeedsBonus())
				return true;
			else
				return false;
		}

		public Frame()
		{
			// make a place for rolls to go
			Rolls = new List<Roll>();
		}

		public int SumOfPinsKnockedDown
		{
			get
			{
				int score = 0;
				foreach (var roll in Rolls)
				{
					score += roll.PinsKnockedDown;
				}
				return score;
			}
		}
	}

	public class Roll
	{
		public int PinsKnockedDown { get; set; }
	}

	public class GameOverException :Exception
	{
	}

}
