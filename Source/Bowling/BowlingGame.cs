using System;
using System.Net.Configuration;
using System.Collections.Generic;

namespace Bowling
{
    public class BowlingGame
    {
        private List<int> _rawScores;
        private int _lastFrameScore;
        private int _lastRollScore;
        private int _rollCount;
        private int _extraStrikes = 0;

        public BowlingGame()
        {
            _rawScores = new List<int>();
        }

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
            HandlePerfectGame();
        }

        private void HandlePerfectGame()
        {
            if (_rollCount == 24 && LastFrameWasAStrike)
            {
                Score = 300;
            }
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
                if(_extraStrikes > 0)
                {
                   
                    //go back that many frames and 
                    //add non-zero raw scores
                    for (int j = _extraStrikes; j > 0; j-- )
                        for (int i = 2 * j; i < _rollCount; i++)
                        {
                            var strikeBonusCount = 0;
                            if (_rawScores[i] > 0)
                            {
                                Score += _rawScores[i];
                                strikeBonusCount++;
                            }
                            if (strikeBonusCount == 2)
                                break;
                        }
                    _extraStrikes = 0;
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
                    _extraStrikes++;
                }
                _rawScores.Add(0);
                _rollCount++;
                LastFrameWasAStrike = true;
            }
        }

        private void HandleCounters(int pins, bool isNewFrame)
        {
            _rawScores.Add(pins);

            _rollCount++;
            Score += pins;

            if (isNewFrame)
                _lastFrameScore = 0;

            _lastRollScore = pins;
            _lastFrameScore += _lastRollScore;


        }

        private void CheckGameOver()
        {
            if (FrameCount >= 10 && !LastFrameWasAStrike)
                throw new InvalidOperationException(("game over"));
        }

        private bool LastFrameWasASpare
        {
            get { return _lastFrameScore == 10 && _lastRollScore < 10; }
        }

        private bool LastFrameWasAStrike
        { get; set; }


        public int Score { get; private set; }

        private int FrameCount { get { return _rollCount / 2; } }


    }
}
