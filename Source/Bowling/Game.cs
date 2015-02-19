using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private List<Frame> _frames = new List<Frame>();
        /// <summary>
        /// Mehod that implements a bowling ball roll
        /// </summary>
        /// <param name="pins"></param>
		public void Roll(int pins)
		{			
            //if more than 10 frames have been rolled then skip rolling of the ball; the lane is closed
			if (_frames.Count == 10 && _frames.Last().Open == false)
			{
				return;
			}

			// if no frames have been added then intitate a new list and add a frame to it
			if (_frames.Count == 0)
			{
				var frame = new Frame(1, pins);
				_frames.Add(frame);
			}
			else //for all other rolls
			{
                //get last rolled frame
				var lastFrame = _frames.Last();

                //if last frame is still open; aka not a strike
				if (!lastFrame.Open)
				{
					Frame newFrame;

                    //if this is the last frame then special rules apply
					newFrame = _frames.Count == 9 ? new TenthFrame(_frames.Count + 1, pins) : new Frame(_frames.Count + 1, pins);
					_frames.Add(newFrame);
				}
				else //if the last roll is still open; aka first roll in frame was not a strike, then add the value of pins to the 2nd roll
				{
					lastFrame.Roll(pins);
				}
			}
		}

        /// <summary>
        /// Method to calculate the final score of the game
        /// </summary>
        /// <returns></returns>
		public int Score()
        {
            return _frames.Sum(
                frame =>
                {
                    var frameScore = frame.Score();

                    //if the frame was a spare or a strike then special score rules apply
                    if (frame.IsSpare || frame.IsStrike)
                    {
                        var nextFrame = _frames.Find(fr => fr.FrameIndex == frame.FrameIndex + 1);

                        //make sure the next roll after a strike or a spare is not null
                        if (nextFrame != null)
                        {
                            if (nextFrame.FirstRoll != null)
                            {
                                frameScore += nextFrame.FirstRoll.Value;
                                if (frame.IsStrike)
                                {
                                    if (nextFrame.SecondRoll.HasValue)
                                    {
                                        frameScore += nextFrame.SecondRoll.Value;
                                    }
                                    else
                                    {
                                        var secondBonusFrame = _frames.Find(fr => fr.FrameIndex == frame.FrameIndex + 2);
                                        if (secondBonusFrame != null)
                                        {
                                            if (secondBonusFrame.FirstRoll != null) frameScore += secondBonusFrame.FirstRoll.Value;
                                        }
                                    }

                                }
                            }
                        }

                    }

                    return frameScore;
                });
        }
	}

	public class Frame
	{
		public Frame(int frameIndex, int firstRoll)
		{
			FirstRoll = firstRoll;
			FrameIndex = frameIndex;
		}

		public int FrameIndex { get; set; }

		public int? FirstRoll { get; set; }
		public int? SecondRoll { get; set; }

		public virtual bool Open
		{
			get
			{
				return !FirstRoll.HasValue || (
					!SecondRoll.HasValue && !IsStrike);
			}
		}

		public virtual int Score()
		{

		    return FirstRoll.Value + (SecondRoll.HasValue ? SecondRoll.Value : 0);

		}

	    public virtual void Roll(int pins) {
			SecondRoll = pins;
		}

		public bool IsStrike
		{
			get
			{
				return FirstRoll == 10;
			}
		}

		public bool IsSpare
		{
			get
			{
				return FirstRoll != 10 && FirstRoll + SecondRoll == 10;
			}
		}
	}

	public class TenthFrame : Frame
	{
		public TenthFrame(int frameIndex, int pins) : base(frameIndex, pins) {}
		
		public int? ThirdRoll { get; set; }

		public override bool Open
		{
			get
			{
				return (
					(IsSpare || IsStrike) && (!ThirdRoll.HasValue) ||
					!SecondRoll.HasValue
				);
			}
		}

		public override int Score() {
			return FirstRoll.Value + (SecondRoll.HasValue ? SecondRoll.Value : 0)
				+ (ThirdRoll.HasValue ? ThirdRoll.Value : 0);
		}

		public override void Roll(int pins) {
			if (!SecondRoll.HasValue) SecondRoll = pins;
			else ThirdRoll = pins;
		}
	}
}