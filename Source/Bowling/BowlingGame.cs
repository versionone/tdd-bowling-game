using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Bowling
{
	public class BowlingGame
	{
		private List<int>Rolls { get; set; }
		private List<Frame> Frames { get; set; }

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
				Frames.Add(new Frame(pins));
			}
			else
			{
				var lastFrame = Frames.Last();
				if (!lastFrame.FrameIsFinished())
				{
					lastFrame.Roll(pins);
				}
				else
				{
					if (lastFrame.IsSpare())
					{
						lastFrame.Roll(pins);
					}

					Frames.Add(new Frame(pins));
				}
			}
		}
	}

	public class Frame
	{
		private int RollOne { get; set; }
		private int? RollTwo { get; set; }
		private int? RollThree { get; set; }


		public Frame(int pins)
		{
			RollOne = pins;
		}
		public bool IsSpare()
		{
			return FrameScore == 10;
		}

		public bool FrameIsFinished()
		{
			return RollTwo != null;
		}

		public int FrameScore
		{
			get { return RollOne + (RollTwo ?? 0) + (RollThree ?? 0); }
		}

		public void Roll(int pins)
		{
			if(RollTwo == null)
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
