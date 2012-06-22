using System.Collections.Generic;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{

    public class BowlingGameSpecs : concerns
    {
        protected override void context()
        {
        }

        [Specification]
        public void when_i_roll_all_gutter_balls_the_score_is_zero()
        {
            var game = new BowlingGame();
            20.times(() => game.Roll(0));
            game.Score.should_equal(0);
        }

        [Specification]
        public void when_i_roll_one_pin_in_an_entire_game_the_score_is_one()
        {
            var game = new BowlingGame();

            game.Roll(1);
            19.times(() => game.Roll(0));


            game.Score.should_equal(1);
        }

        [Specification]
        public void rolls_dont_count_until_a_frame_is_closed()
        {
            var game = new BowlingGame();

            // first frame
            game.Roll(1);
            game.Roll(4);

            // second frame
            game.Roll(4);
            game.Roll(5);

            // third frame, INCOMPLETE
            game.Roll(6);

            game.Score.should_equal(14);
        }

        [Specification]
        public void when_i_roll_a_spare_the_score_for_the_frame_is_ten_plus_the_next_roll()
        {
            var game = new BowlingGame();

            // first frame
            game.Roll(1);
            game.Roll(4);

            // second frame
            game.Roll(4);
            game.Roll(5);

            // third frame, SPARE!
            game.Roll(6);
            game.Roll(4);

            // first roll of fifth frame
            game.Roll(5);

            game.Score.should_equal(29);
        }

        [Specification]
        public void frames_can_only_have_two_rolls()
        {
            var frame = new Frame();
            frame.Roll(1);
            frame.Roll(1);
            frame.Roll(1);

            frame.Score.should_equal(2);
        }

        [Specification]
        public void Roll_Two_Spares()
        {
            var game = new BowlingGame();
            
            game.Roll(5);
            game.Roll(5); // 11

            game.Roll(1);
            game.Roll(0); // 12

            game.Roll(5);
            game.Roll(5); // 23

            game.Roll(1);
            game.Roll(0); // 24

            game.Score.should_equal(24);


        }
    }

    public class BowlingGame
    {
        private readonly List<Frame> _allFrames = new List<Frame>();
        private Frame _currentFrame = new Frame();
        private Frame _bonusFrame = null;

        private bool SpareRolled { get; set; }


        public int Score
        {
            get
            {
                int score = 0;
                _allFrames.ForEach(f => score += f.Score);
                return score;
            }
        }


        public void Roll(int downedPins)
        {
            _currentFrame.Roll(downedPins);

            HandleSpareBonus(downedPins);
            AdvanceToNextFrame();
        }

        private void HandleSpareBonus(int downedPins)
        {
            if (_bonusFrame == null) return;

            _bonusFrame.AddBonus(downedPins);
            _allFrames.Add(_bonusFrame);
            _bonusFrame = null;
        }

        private void AdvanceToNextFrame()
        {
            if (!_currentFrame.RollsComplete) return;

            if (_currentFrame.IsSpare)
            {
                _bonusFrame = _currentFrame;
            }
            else
            {
                _allFrames.Add(_currentFrame);
            }

            _currentFrame = new Frame();
        }
    }

    public class Frame
    {
        
        private int _rollCount;
        private int _score;
        private int _bonus;
        private bool _isSpare;

        public int Score
        {
            get { return _score + _bonus; }
        }

        public bool RollsComplete
        {
            get { return _rollCount == 2; }
        }

        public bool IsSpare
        {
            get { return _isSpare; }
        }

        public void Roll(int downedPins)
        {
            if (_rollCount == 2) return;

            // am i a spare? if so, record it and don't offer a score yet
            // i need some way to ask the game when the next roll happens, so i can 
            // complete myself and get a score



            _rollCount += 1;
            _score += downedPins;

            _isSpare = (_rollCount == 2) && (_score == 10);
        }

        public void AddBonus(int amount)
        {
            _bonus = amount;
        }
    }

}