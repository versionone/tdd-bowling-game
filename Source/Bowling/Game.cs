using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class Game
    {
        private IList<Frame> frames = new List<Frame>();

        public Game()
        {
        }

        public void Roll(int pins)
        {
            Frame currentFrame;

            if (frames.Count == 0) frames.Add(new Frame());

            if (frames[frames.Count - 1].rolls.Count() == 2)
            {
                frames.Add(new Frame());
                currentFrame = frames.Last();
            }
            else
            {
                currentFrame = frames.Last();
            }

            currentFrame.rolls.Add(pins);
            
        }

        public int GetScore()
        {
            int result = 0;

            for (int i = 0; i <= frames.Count-1; i++)
            {
                for (int j = 0; j <= frames[i].rolls.Count-1; j++)
                {
                    result += frames[i].rolls[j];
                }
            }
            
            return result;
        }


    }
}
