using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class BowlingGame
    {
        private const int MAX_NUM_FRAMES = 10;
        private List<Frame> frames = new List<Frame>();

        public void Bowl(int pins)
        {
            Frame lastFrame = frames.LastOrDefault();
	        var lastFrameIndex = frames.IndexOf(lastFrame);
            if (frames.Count >= MAX_NUM_FRAMES && lastFrame != null && !lastFrame.AllowMoreRolls(lastFrameIndex))
            {
                throw new GameOverException();
            }


            if (lastFrame == null || !lastFrame.AllowMoreRolls(lastFrameIndex))
            {
                var frame = new Frame();
                frames.Add(frame);
                frame.Roll1 = pins;
            }

            else
            {
                // special case if we're on the 10th frame
                if (frames.Count == 10 && lastFrame.IsStrike()) {
                    if (!lastFrame.Roll2.HasValue)
                    {
                        lastFrame.Roll2 = pins;
                    }
                    else
                    {
                        lastFrame.Roll3 = pins;
                    }
                }

                else if (lastFrame.AllowMoreRolls(lastFrameIndex))
                {
                    lastFrame.Roll2 = pins;
                }
            }
        }

        public int Score
        {
            get
            {
                for (int i = 0; i < frames.Count; i++)
                {
                    var currentFrame = frames[i];

                    //if we are not on the first frame grab the previous frame and compute the score
                    if (i > 0)
                    {
                        var previousFrame = frames[i - 1];
                        if (previousFrame.IsSpare())
                        {
                            previousFrame.Bonus = currentFrame.Roll1;
                        }
                        else if (previousFrame.IsStrike())
                        {
                            var bonus = currentFrame.Roll1;

                            if (currentFrame.IsStrike()) {
                                Frame nextFrame = null;

                                if (i < frames.Count - 1)
                                {
                                    nextFrame = frames[i + 1];
                                }

                                //if we are not on the last frame
                                if (nextFrame != null && i < frames.Count - 1)
                                {
                                    bonus += nextFrame.Roll1;
                                }
								else //we are on the last frame
                                {
	                                bonus += currentFrame.Roll2.Value;
                                }

                            }
                            else { bonus += currentFrame.Roll2.Value; }

                            previousFrame.Bonus = bonus;
                        }


                    }
                }

                //since the array is small we can eat the computational cost of looping through the array twice
                return frames.Sum(x => x.TotalScore);
            }
        }
    }

    public class GameOverException : Exception {
    }

    public class Frame
    {

        public int Roll1 { get; set; }
        public int? Roll2 { get; set; }
        public int? Roll3 { get; set; }
        public int? Bonus { get; set; }


        public int TotalScore
        {
            get
            {
                return GetNumOfPins() + Bonus.GetValueOrDefault();
            }
        }
        public bool IsStrike()
        {
            return Roll1 == 10;
        }

        public bool IsSpare()
        {
            return Roll2.HasValue && (Roll1 + Roll2 == 10);
        }

        public int GetNumOfPins()
        {
            return Roll1 + Roll2.GetValueOrDefault() + Roll3.GetValueOrDefault();
        }

        public bool AllowMoreRolls(int frameIndex)
        {
			if (frameIndex < 9)
			{
				if ((IsStrike() || Roll2.HasValue))
				{
					return false;
				}
			}
			else
			{
				if (IsStrike() && Roll3.HasValue)
				{
					return false;
				}
				if (!IsStrike() && !IsSpare() && Roll2.HasValue)
				{
					return false;
				}
				if (IsSpare() && Roll3.HasValue)
				{
					return false;
				}
			}

            return true;
        }


    }
}
