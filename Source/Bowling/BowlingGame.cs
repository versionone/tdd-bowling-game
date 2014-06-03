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
        private const int PERFECT_SCORE = 300;
        private const int MAX_ROLLS = 24;
        private const int MAX_NORMAL_ROLLS = 20;
        private const int MAX_FRAMES = 10;
        private const int MAX_PINS = 10;

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
            if (_rollCount == MAX_ROLLS && LastFrameWasAStrike)
            {
                Score = PERFECT_SCORE;
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
                if (_extraStrikes > 0)
                {

                    //go back that many frames and 
                    //add non-zero raw scores
                    for (int j = _extraStrikes; j > 0; j--)
                        for (int i = 1 + (2 * j); i < _rollCount; i++)
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
            if (pins == MAX_PINS)
            {
                if (LastFrameWasAStrike)
                {
                    _extraStrikes++;
                }
                _rawScores.Add(pins);
                _rollCount++;
                LastFrameWasAStrike = true;
            }
        }

        private void HandleCounters(int pins, bool isNewFrame)
        {
            if (!isNewFrame && LastFrameWasAStrike)
            {
                _rawScores.Add(0);
            }
            else
            {
                _rawScores.Add(pins);
            }

            _rollCount++;

            if (isNewFrame)
                _lastFrameScore = 0;

            _lastRollScore = pins;
            _lastFrameScore += _lastRollScore;

            // after max rolls scores are only for bonuses
            if(_rollCount <= MAX_NORMAL_ROLLS)
                Score += pins;



        }

        private void CheckGameOver()
        {
            if (FrameCount > MAX_FRAMES)
                throw new InvalidOperationException(("game over"));
        }

        private bool LastFrameWasASpare
        {
            get { return _lastFrameScore == MAX_PINS && _lastRollScore < MAX_PINS; }
        }

        private bool LastFrameWasAStrike
        { get; set; }


        public int Score { get; private set; }

        private int FrameCount
        {
            get
            {
                if (LastFrameWasAStrike && _rollCount >= MAX_NORMAL_ROLLS && _rollCount <= MAX_ROLLS)
                    return MAX_FRAMES;
                if (LastFrameWasASpare && _rollCount == MAX_NORMAL_ROLLS)
                    return MAX_FRAMES;
                return (_rollCount / 2) + 1;
            }
        }


    }
}
