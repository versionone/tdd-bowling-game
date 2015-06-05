using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		public List<Frame> Frames { get; private set; }
		private int LastRoll { get; set; }
		private Frame CurrentFrame { get; set; }
		private int NumberOfRolls { get; set; }
		private int StrikeAtFrame { get; set; }
		private bool PreviousSpare { get; set; }
		private bool PreviousStrike { get; set; }

		public int Score
		{
			get { return Frames.Sum(x => x.FirstRoll.Value + x.SecondRoll.Value); }
		}

		public Game()
		{
			Frames = new List<Frame>();
		}

		public void Roll(int pinsKnockedDown)
		{
			if(CurrentFrame == null) CurrentFrame = new Frame();
			if (!CurrentFrame.FirstRoll.HasValue) CurrentFrame.FirstRoll = pinsKnockedDown;
			else
			{
				CurrentFrame.SecondRoll = pinsKnockedDown;
				Frames.Add((CurrentFrame));
				CurrentFrame = null;
			}



//			ValidateRoll();
//
//
//
//			CalculateScore(pinsKnockedDown);
//
//			if (IsStrike(pinsKnockedDown))
//			{
//				PreviousStrike = true;
//				ResetFrame();
//			}
//			else if (NumberOfRolls == 2)
//			{
//				if (IsSpare())
//				{
//					//calculate spare score
//				}
//				else
//				{
//					//calculate normal score
//				}
//				//reset frame
//			}
//			else if (IsSpare(pinsKnockedDown))
//			{
//				UpdateSpareStatus(pinsKnockedDown);
//				ResetFrame();
//			}
//
//			/*
//			 * if strike
//			 * if numberofrolls >= 2 
//			 */
//
//			UpdateStrikeStatus();
//			UpdateSpareStatus(pinsKnockedDown);
//
//			LastRoll = pinsKnockedDown;
//			NumberOfRolls++;
		}
//
//		private void ValidateRoll()
//		{
//			if (NumberOfRolls >= 20) throw new Exception("Can not roll more than 10 frames.");
//		}
//
//		private int CalculateScore(int pinsKnockedDown)
//		{
//			var updatedScore = 0;
//			if (PreviousSpare) updatedScore = pinsKnockedDown * 2;
//			if (PreviousStrike) updatedScore = pinsKnockedDown * 2;
//			return updatedScore;
//		}
//
//		private void UpdateStrikeStatus()
//		{
//			if (NumberOfRolls - StrikeAtFrame >= 2) PreviousStrike = false;
//		}
//
//		private void UpdateSpareStatus(int pinsKnockedDown)
//		{
//			PreviousSpare = true;
//		}
//
//		private bool IsStrike(int pinsKnockedDown)
//		{
//			return pinsKnockedDown == 10;
//		}
//
//		private bool IsSpare(int pinsKnockedDown)
//		{
//			return (NumberOfRolls%2 == 1 && pinsKnockedDown + LastRoll == 10);
//		}
//
//		private void ResetFrame()
//		{
//			CurrentFrame++;
//			NumberOfRolls = 0;
//		}
	}
}
