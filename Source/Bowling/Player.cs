using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Player
    {
        readonly List<Frame> _frames;
        Frame _currentFrame;
        public Player()
        {
            _frames = new List<Frame>();
            for (int i = 1; i <= 10; i++) {
                _frames.Add(new Frame(i));
            }
            _currentFrame = _frames.First();
        }
        public void Roll(int pins)
        {
            ifGameOverExitWithError();

            if (_currentFrame.IsFirstRoll) {
                _currentFrame.FirstRoll.Pins = pins;
                if (_currentFrame.IsStrike && !_currentFrame.IsLastFrame) {
                    _currentFrame = nextFrame();
                }
            } else if (_currentFrame.IsSecondRoll || (_currentFrame.IsLastFrame && _currentFrame.IsStrike)) {
                _currentFrame.SecondRoll.Pins = pins;
                if (!_currentFrame.IsLastFrame) {
                    _currentFrame = nextFrame();
                }
            } else if (_currentFrame.BonusRollAllowed) {
                _currentFrame.BonusRoll.Pins = pins;
            }
        }
        void ifGameOverExitWithError()
        {
            if (gameOver()) {
                throw new ApplicationException("Game Ended!");
            }
        }
        bool gameOver()
        {
            if (!_currentFrame.IsLastFrame) return false;
            return _currentFrame.BonusRollAllowed ? _currentFrame.BonusRoll.Pins.HasValue : _currentFrame.SecondRoll.Pins.HasValue;
        }
        Frame nextFrame()
        {
            var nextId = _currentFrame.FrameId + 1;
            return _currentFrame.IsLastFrame ? null : _frames.SingleOrDefault(f => f.FrameId == nextId);
        }
        public int Score()
        {
            return _frames.CalculateScore();
        }
    }
}

