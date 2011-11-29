using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class BowlingGame
    {
        private IFrame currentFrame;

        public List<IFrame> Frames { get; set; }
        
        
        public BowlingGame()
        {
            lastRoll = new NullRoll();
            Frames = new List<IFrame>();
            currentFrame = new OpenFrame();
        }

        public int GameTotal
        {
            get
            {
                int runningTotal = 0;
                

                Frames.ForEach(frame =>
                                   {
                                       var index = Frames.IndexOf(frame);
                                       IFrame oneFrameAhead = Frames.ElementAtOrDefault(index + 1) ?? new NullFrame();
                                       IFrame twoFramesAhead = Frames.ElementAtOrDefault(index + 2) ?? new NullFrame();

                                       var list = oneFrameAhead.Rolls.Concat(twoFramesAhead.Rolls);
                                       
                                       runningTotal += frame.CalculateScore(list);
                                   });

                return runningTotal;
            }
        }

        public void AddFrame(IFrame frame)
        {
            lastRoll = new NullRoll();
            Frames.Add(frame);
        }

        public IRoll lastRoll;

        public void Roll(int pins)
        {
            currentFrame.AddRoll(new Roll(pins));
            
            if (currentFrame.IsCompelete())
            {
                CompleteFrame();
            }
        }

        private void CompleteFrame()
        {
            AddFrame(currentFrame);
            currentFrame = Frames.Count == 9 ? new TenthFrame() : new OpenFrame();
        }
    }
}
