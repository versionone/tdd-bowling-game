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

            if (frames.Count >= MAX_NUM_FRAMES && lastFrame != null && !lastFrame.AllowMoreRolls())
            {
                throw new GameOverException();
            }

           
            if (lastFrame != null && lastFrame.AllowMoreRolls())
            {
                    lastFrame.Roll2 = pins;                 
            }
            else
            {
                var frame = new Frame();
                frames.Add(frame);
                frame.Roll1 = pins;
            }

        }

        public int Score 
        {
            get
            {
                for (int i = 0; i < frames.Count; i++)
                {
                    var currentFrame = frames[i];
                    
                    if (i > 0)
                    {
                        var previousFrame = frames[i - 1];
                        if (previousFrame.IsSpare())
                        {
                            var roll1 = currentFrame.Roll1;
                            previousFrame.Bonus = roll1;
                        }
                        else if (previousFrame.IsStrike())
                        {
                            var bonus = currentFrame.Roll1;

                            if (currentFrame.IsStrike()) {
                                //look ahead and grab score from next roll
                                if (i != frames.Count)
                                {
                                    var nextFrame = frames[i + 1];
                                    bonus += nextFrame.Roll1;
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
            return Roll1 == 10 && !Roll2.HasValue;
        }

        public bool IsSpare()
        {
            return Roll2.HasValue && (Roll1 + Roll2 == 10);
        }

        public int GetNumOfPins()
        {
            return Roll1 + Roll2.GetValueOrDefault();
        }

        public bool AllowMoreRolls()
        {
            if (IsStrike() || Roll2.HasValue) 
            {
                return false;
            }

            return true;
        }
    }
}
