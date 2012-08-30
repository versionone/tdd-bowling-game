using System;
using System.Collections.Generic;
using System.Linq;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
    public class FrameAdvancerFixture : concerns
    {
        [Specification]
        public void StrikeRollShouldAdvance()
        {
            var advancer = new FrameAdvancer();
            advancer.ShouldFrameAdvance(10).should_be_true();
        }

        [Specification]
        public void AOneRollWillNotAdvance()
        {
            var advancer = new FrameAdvancer();
            advancer.ShouldFrameAdvance(1).should_be_false();
        }

        [Specification]
        public void TwoRegularRollsWillAdvance()
        {
            var advancer = new FrameAdvancer();
            advancer.ShouldFrameAdvance(1).should_be_false();
            advancer.ShouldFrameAdvance(4).should_be_true();
        }

        [Specification]
        public void third_regular_roll_will_not_advance()
        {
            var advancer = new FrameAdvancer();
            advancer.ShouldFrameAdvance(1).should_be_false();
            advancer.ShouldFrameAdvance(4).should_be_true();
            advancer.ShouldFrameAdvance(7).should_be_false();            
        }

        [Specification]
        public void fourth_regular_roll_will_advance()
        {
            var advancer = new FrameAdvancer();
            advancer.ShouldFrameAdvance(1).should_be_false();
            advancer.ShouldFrameAdvance(4).should_be_true();
            advancer.ShouldFrameAdvance(7).should_be_false();
            advancer.ShouldFrameAdvance(1).should_be_true();
        }

        [Specification]
        public void handle_the_tenth_frame()
        {
            var advancer = new FrameAdvancer();
            18.times(() => advancer.ShouldFrameAdvance(1));

            advancer.ShouldFrameAdvance(10).should_be_false();
            advancer.ShouldFrameAdvance(10).should_be_false();
            advancer.ShouldFrameAdvance(10).should_be_false();
        }

        [Specification]
        public void strikeFollowedByRegularShouldNotAdvance()
        {
            var advancer = new FrameAdvancer();
            advancer.ShouldFrameAdvance(10).should_be_true();
            advancer.ShouldFrameAdvance(1).should_be_false();
        }

        [Specification]
        public void perfectGame()
        {
            var advancer = new FrameAdvancer();
            9.times(() => advancer.ShouldFrameAdvance(10).should_be_true());
            advancer.ShouldFrameAdvance(10).should_be_false();
            advancer.ShouldFrameAdvance(10).should_be_false();
            advancer.ShouldFrameAdvance(10).should_be_false();
        }
    }

    public class when_everything_is_wired_up : concerns
    {
        [Specification]
        public void GutterOnlyGameShouldEqualZero()
        {
            var game = new Game();

            for (int roll = 1; roll <= 20; roll++)
            {
                int pinCount = 0;
                game.Roll(pinCount);
            }

            game.Score().should_equal(0);
        }

        [Specification]
        public void AllOnePinRollsShouldEqual20()
        {
            var game = new Game();
            20.times(() => game.Roll(1));
            game.Score().should_equal(20);
        }

        [Specification]
        public void InvalidRollsDontContributeToGameScore()
        {
            var game = new Game();
            game.Roll(15);
            game.Roll(15);
            game.Score().should_equal(0);
        }

        [Specification]
        public void ScoreOnlyWhenAFrameIsComplete()
        {
            var game = new Game();

            game.Roll(1);

            game.Score().should_equal(0);
        }

        [Specification]
        public void SpareBonusMechanics()
        {
            var game = new Game();

            game.Roll(1);
            game.Roll(4);

            game.Score().should_equal(5);

            game.Roll(4);
            game.Roll(5);

            game.Score().should_equal(14);

            game.Roll(6);
            game.Roll(4); // spare!

            game.Score().should_equal(14);

            game.Roll(5); // bonus to spare!

            game.Score().should_equal(29);
        }

        [Specification]
        public void TwoSubsequentSparesBonusMechanics()
        {
            var game = new Game();

            game.Roll(1);
            game.Roll(4);

            game.Score().should_equal(5);

            game.Roll(4);
            game.Roll(5);

            game.Score().should_equal(14);

            game.Roll(6);
            game.Roll(4); // spare!

            game.Score().should_equal(14);

            game.Roll(5);
            game.Roll(5); // spare!

            game.Score().should_equal(29);

            game.Roll(10);

            game.Score().should_equal(49);
        }

        [Specification]
        public void StrikeBonusMechanics()
        {
            var game = new Game();

            game.Roll(1);
            game.Roll(4);

            game.Score().should_equal(5);

            game.Roll(4);
            game.Roll(5);

            game.Score().should_equal(14);

            game.Roll(6);
            game.Roll(4); // spare!

            game.Score().should_equal(14);

            game.Roll(5);
            game.Roll(5); // spare!

            game.Score().should_equal(29);

            game.Roll(10);

            game.Score().should_equal(49);

            game.Roll(0);
            game.Roll(1);

            game.Score().should_equal(60);
        }
    }

    public class Game
    {
        private readonly List<Frame> frames;
        private Frame currentFrame;
        private int rollCount;
        private FrameAdvancer advancer;

        public event Action<int> RolledEvent;

        public Game()
        {
            frames = new List<Frame>();
            currentFrame = new Frame(this);
            frames.Add(currentFrame);

            advancer = new FrameAdvancer();
            advancer.GameEnd += new Action(OnGameEnd);
        }

        void OnGameEnd()
        {
            // TODO: something
        }

        public void Roll(int pinCount)
        {
            if (!isValidRoll(pinCount)) return;

            rollCount += 1;

            RolledEvent(pinCount);

            if (rollCount == 2)
            {
                var newFrame = new Frame(this);
                currentFrame = newFrame;
                frames.Add(newFrame);
                rollCount = 0;
            }
        }

        private bool isValidRoll(int roll)
        {
            return (roll >= 0 && roll <= 10);
        }

        public int Score()
        {
            return frames.Sum((frame) => frame.Score());
        }
    }

    public class FrameAdvancer
    {
        public event Action GameEnd;

        private int _frameCount = 1;
        private int _rollCount = 0;
        private int _finalRolls = 3;

        public bool ShouldFrameAdvance(int pins)
        {
            _rollCount++;

            if (_frameCount >= 10)
            {
                _finalRolls--;
                return false;
            }

            if (_finalRolls == 0)
            {
                GameEnd();
            }

            if (_rollCount == 2)
            {
                _frameCount++;
                _rollCount = 0;
                return true;
            }

            if (pins == 10)
            {
                _frameCount++;
                _rollCount = 0;
                return true;
            }

            return false;
        }
    }

    public class Frame
    {
        public bool ApplySpareBonus;
        public List<int> PinCounts;
        private int _score;
        private int _rollCount = 0;
        private int _rollsNeeded = 2;

        public Frame(Game game)
        {
            game.RolledEvent += new Action<int>(OnRolledEvent);    
        }

        void OnRolledEvent(int pinCount)
        {
            if (IsScored()) return;
            
            _rollCount += 1;
            _score += pinCount;

            if (IsStrike()) _rollsNeeded += 2;
            if (IsSpare()) _rollsNeeded += 1;
        }

        public int Score()
        {
            if (!IsScored()) return 0;
            return _score;
        }

        private bool IsSpare()
        {
            return (_rollCount == 2) && (_score == 10);
        }

        private bool IsStrike()
        {
            return (_rollCount == 1) && (_score == 10);
        }

        private bool IsScored()
        {
            return _rollCount >= _rollsNeeded;
        }
    }

}