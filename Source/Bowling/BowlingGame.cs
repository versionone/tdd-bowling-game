using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		public List<int>Rolls { get; set; }
		public List<Frame> Frames { get; set; }
		public int Score {
			get
			{
				int total = 0;
				foreach (var frame in Frames)
				{
					total += frame.FrameScore;
				}
				return total;
			}

		}

		public BowlingGame()
		{
			Rolls = new List<int>();
			Frames = new List<Frame>();
		}

		public void Roll(int pins)
		{
			if (Frames.Count == 0)
			{
				var frame = new Frame();
				frame.Roll(pins);
				Frames.Add(frame);
			}
			else
			{
				var lastFrame = Frames.Last();
				if (lastFrame.RollTwo == null)
					lastFrame.Roll(pins);
				else
				{
					if (lastFrame.FrameScore == 10)
					{
						lastFrame.Roll(pins);
					}

					var frame = new Frame();
					frame.Roll(pins);
					Frames.Add(frame);
				}
			}

			//if (Rolls.Count == 2 && Rolls[0] + Rolls[1] == 10)
			//{
			//    Rolls.Add(pins*2);
			//}
			//else
			//{

			//    Rolls.Add(pins);
			//}
		}
	}

	public class Frame
	{
		public int? RollOne { get; private set; }
		public int? RollTwo { get; private set; }
		public int? RollThree { get; private set; }
		public int FrameScore
		{
			get { return (RollOne ?? 0) + (RollTwo ?? 0) + (RollThree ?? 0); }
		}

		public Frame()
		{
		}


		public void Roll(int pins)
		{
			if (RollOne == null)
			{
				RollOne = pins;
			}
			else if(RollTwo == null)
			{
				RollTwo = pins;
			}
			else
			{
				RollThree = pins;
			}
		}
	}
}
