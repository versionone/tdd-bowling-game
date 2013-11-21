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

		public int CurrentFrameIndex { get; set; } 

		public List<Frame> frames { get; set; }
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
					score += frame.Score;
					if (frame.NeedsBonus())
					{
						// peek forward/ determine bonus
						Frame nextFrame = frames[i + 1];
						int bonusScore = nextFrame.Rolls[0].PinsKnockedDown;
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
			if (Rolls.Count == 2)
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

		public Frame()
		{
			// make a place for rolls to go
			Rolls = new List<Roll>();
		}

		public int Score
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
