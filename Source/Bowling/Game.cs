using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class Game
	{
		private List<Frame> frames;
		private int frameIndex;
		public Game()
		{
			frames = new List<Frame>(10);
			for (var f = 0; f < frames.Capacity; f++)
			{
				var frame = new Frame();
				frames.Add(frame);
			}
			frameIndex = 0;
		}

		private Frame CurrentFrame => frames[frameIndex];

        public int Score()
        {
            var frameIndex = 0;

            var score = frames.Aggregate(0, (runningTotal, frame) =>
            {
                var bonusTotal = 0;
                if (frame.IsSpare())
                {
                    if (HasFrameAtIndex(frameIndex + 1))
                    {
                        bonusTotal += frames[frameIndex + 1].Rolls[0];
                    }
                    else //I'm on the last frame, take the third roll
                    {
                        bonusTotal += frames[frameIndex + 1].Rolls[2];
                    }
                }
                else if (frame.IsStrike())
                {
                    if (HasFrameAtIndex(frameIndex + 1))
                    {
                        if (frames[frameIndex + 1].IsOpen() || frames[frameIndex + 1].IsSpare())
                        {
                            bonusTotal += frames[frameIndex + 1].Total();
                        }
                        else //strike rolled in next frame
                        {
                            bonusTotal += frames[frameIndex + 1].Rolls[0];
                            if (HasFrameAtIndex(frameIndex + 2))
                            {
                                bonusTotal += frames[frameIndex + 2].Rolls[0];
                            }
                            else
                            {
                                bonusTotal += frames[frameIndex + 1].Rolls[1];
                            }
                        }
                       
                    }
                   
                 
                }
				frameIndex++;

				var frameTotal = frame.Total();
				return runningTotal + bonusTotal + frameTotal;
			});

			return score;
		}

		private bool HasFrameAtIndex(int frameIndex) => frames.Count - 1 >= frameIndex;

		public void Roll(int pins)
		{
			if(frameIndex > 9)
			{
				throw new GameOverException();
			}
			if (frameIndex < 9) {
				CurrentFrame.Roll(pins);
				if (CurrentFrame.CurrentRoll > 1 || CurrentFrame.IsStrike())
				{
					frameIndex++;
				}
				
			}
			else //frame 10
			{

                if (CurrentFrame.CurrentRoll < 2)
                {
                    CurrentFrame.Roll(pins);
                }
                else if (CurrentFrame.IsOpen())
                {
                    throw new GameOverException();
                }
                else {
                   if (CurrentFrame.CurrentRoll < 3){
                        CurrentFrame.Roll(pins);
                    }
                } 
            }
		}
	}

	public class Frame
	{
		public List<int> Rolls;
		public int CurrentRoll => Rolls.Count;

		public Frame()
		{
			Rolls = new List<int>();
		}
		public void Roll(int pins)
		{
			Rolls.Add(pins);
		}

		public int Total()
		{
			return Rolls.Sum();
		}

		public bool IsSpare() => Total() == 10 && Rolls[0] != 10 && Rolls.Count == 2;

		public bool IsStrike() => Rolls[0] == 10;

		public bool IsOpen() => Rolls.Count == 2 && Total() < 10;
	}


	public class GameOverException : Exception
	{
		public GameOverException() : base("Game over") { }
	}
}
