using System;
using System.Net.Configuration;

namespace Bowling
{
    public class BowlingGame
    {
        public void Roll(int pins)
        {
            CheckGameOver();

            var isNewFrame = _rollCount % 2 == 0;

            if (isNewFrame)
            {
                HandleSpareBonus(pins);
                CheckStrike(pins);
            }
            else
            {
                HandleStrikeBonuses(pins);
            }

            HandleCounters(pins, isNewFrame);

        }

        private void HandleSpareBonus(int pins)
        {
            if (LastFrameWasASpare)
            {
                Score += pins;
            }
        }

        private void HandleStrikeBonuses(int pins)
        {
            if (LastFrameWasAStrike)
            {
                if(_consecutiveStrikes)
                {
                    Score += 10 + _lastRollScore;
                }
                Score += _lastRollScore + pins;
                LastFrameWasAStrike = false;
            }
        }

        private void CheckStrike(int pins)
        {
            if (pins == 10)
            {
                if(LastFrameWasAStrike)
                {
                    _consecutiveStrikes = true;
                }
                
                _rollCount++;
                LastFrameWasAStrike = true;
            }
        }

        private void HandleCounters(int pins, bool isNewFrame)
        {
            _rollCount++;
            Score += pins;

            if (isNewFrame)
                _lastFrameScore = 0;

            _lastRollScore = pins;
            _lastFrameScore += _lastRollScore;

        }

        private void CheckGameOver()
        {
            if (FrameCount >= 10)
                throw new InvalidOperationException(("game over"));
        }

        private bool LastFrameWasASpare
        {
            get { return _lastFrameScore == 10 && _lastRollScore < 10; }
        }

        private bool LastFrameWasAStrike
        { get; set; }

        private int _lastFrameScore;
        private int _lastRollScore;

        public int Score { get; private set; }

        private int _rollCount;
        private int FrameCount { get { return _rollCount / 2; } }

        private bool _consecutiveStrikes;
    }
}
