using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Game
    {
        public List<Frame> Frames { get; set; }

        public Game()
        {
            Frames = new List<Frame>();
        }

        public void Roll(int score)
        {
            if (Frames.Count == 0 || Frames.LastOrDefault().IsComplete)
            {
                var previousFrame = Frames.LastOrDefault();

                var f = new Frame();
                f.RollOne = score;
                Frames.Add(f);
            }
            else
            {
                var f = Frames.Last();
                f.RollTwo = score;

            }
        }

        public int GetScore()
        {
            var total = 0;

            for (int i = 0; i < Frames.Count(); i++)
            {
                var currentFrame = Frames[i];
                total += currentFrame.RollOne;
                total += currentFrame.RollTwo ?? 0;

                if (currentFrame.IsSpare && i < 10)
                {
                    total += Frames[i + 1].RollOne;
                }

                if (currentFrame.IsStrike && i < 10)
                {
                    total += Frames[i + 1].RollOne;
                    if (Frames[i + 1].RollTwo.HasValue)
                    {
                        total += Frames[i + 1].RollTwo ?? 0;
                    }
                    else
                    {
                        total += Frames[i + 2].RollOne;
                    }
                }

            }

            return total;
        }
    }

    //1,4,0,4

    //console.readline()
}
