using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class BowlingFrame
	{
		#region Properties
		public int? Roll1 { get; set; }

		public int? Roll2 { get; set; }	
		#endregion

		#region Methods
		public void ApplyRoll(int pinsKnockedDown)
		{
			if (!Roll1.HasValue)
				Roll1 = pinsKnockedDown;
			else
				Roll2 = pinsKnockedDown;
		}

		public int CalculateScore(BowlingFrame nextFrame, BowlingFrame followingFrame)
		{
			var thisTotal = Roll1.GetValueOrDefault() + Roll2.GetValueOrDefault();

			if (IsSpare())
			{
				thisTotal += AddSpareBonus(nextFrame);
			}
			else if (IsStrike())
			{
				thisTotal += AddStrikeBonus(nextFrame, followingFrame);
			}

			return thisTotal;
		}

		public int CalculateScore(BowlingFrame nextFrame)
		{
			return CalculateScore(nextFrame, null);
		}

		private int AddSpareBonus(BowlingFrame nextFrame)
		{
			if (nextFrame != null)
				return nextFrame.Roll1.GetValueOrDefault();
			else
				return 0;
		}

		private int AddStrikeBonus(BowlingFrame nextFrame, BowlingFrame followingFrame)
		{
			var bonus = 0;

			if (nextFrame != null)
			{
				bonus += nextFrame.Roll1.GetValueOrDefault() + nextFrame.Roll2.GetValueOrDefault();

				if (nextFrame.IsStrike() && followingFrame != null)
					bonus += followingFrame.Roll1.GetValueOrDefault();
			}

			return bonus;
		}

		public bool IsComplete()
		{
			if (!Roll1.HasValue)
				return false;
			else if (Roll1.Value == 10)
				return true;
			else 
				return Roll2.HasValue;
		}

		public bool IsSpare()
		{
			return Roll1.GetValueOrDefault() != 10 &&
				   Roll1.GetValueOrDefault() + Roll2.GetValueOrDefault() == 10;
		}

		public bool IsStrike()
		{
			return Roll1.GetValueOrDefault() == 10;
		}
		#endregion
	}
}
