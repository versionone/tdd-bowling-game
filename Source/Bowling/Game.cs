using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class Frame
	{
		public int roll1;
		public int roll2;
		public int rollTotal => roll1 + roll2;
		public bool isSpare => (rollTotal == 10);
		public bool isStrike => roll1 == 10;
	}
	public class Game
	{
		private List<int> rollScores = new List<int>();
		public void Roll(int pins)
		{
			rollScores.Add(pins);
			List<Frame> frames = rollsToFrames();
			if (frames.Count > 10) throw new Exception();
		}

		public List<Frame> rollsToFrames()
		{
			List<Frame> frames = new List<Frame>();
			for (int i = 0; i < rollScores.Count; i++)
			{
				Frame fr = new Frame();
				if (rollScores[i] == 10) fr.roll1 = 10;
				else
				{
					fr.roll1 = rollScores[i];
					if (i + 1 < rollScores.Count)
					{
						fr.roll2 = rollScores[i+1];
						i++;
					}
				}

				frames.Add(fr);
			}
			return frames;
		}

		public int GetScore()
		{
			int finalScore = 0;
			List<Frame> frames = rollsToFrames();
			for (int i = 0; i < frames.Count; i++)
			{
				finalScore += frames[i].rollTotal;
				if(i != 0 && frames[i-1].isStrike)
				{
					if (frames[i].isStrike)
					{
						finalScore += frames[i + 1].roll1;
					}
					finalScore += frames[i].rollTotal;
				}
				else if(i != 0 && frames[i-1].isSpare)
				{
					finalScore += frames[i].roll1;
				}
				
			}

			return finalScore;
		}
	}
}
