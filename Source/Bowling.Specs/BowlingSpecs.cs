using System;
using System.Collections.Generic;
using System.Linq;
using Bowling.Specs.Infrastructure;



// exception GameOver



// Scoring rules:
//  roll n
//  roll n+1
//  roll n+2

// Closed Frames
//  score for a strike = 10 + (n+1) + (n+2)
//  score for a spare = 10 + (n+1)
// 
// Two rolls per frame
//   A strike is always allowed two following rolls
//   A spare is always alloed one follow rolls.


 


namespace specs_for_bowling
{
    public class GameEndException: Exception
    {
        
    }

    public class BowlingGame
    {
        private int _rolls_taken = 0;
        private int _current_score = 0;

        private int _guaranteed_rolls_remaining = 0;

        private List<int> _frame_scores = new List<int>();

        private enum FRAME_STATES
        {
            ROLL_1,
            ROLL_2,
        };

        private FRAME_STATES _frame_state;

        public BowlingGame()
        {
            _frame_state = FRAME_STATES.ROLL_1;
        }

        public int getScore()
        {
            return _current_score;
        }

        public void Roll(int pins_fallen)
        {
            if( _frame_state == FRAME_STATES.ROLL_1)
            {
                _frame_state = FRAME_STATES.ROLL_2;
            }

            if( _frame_state == FRAME_STATES.ROLL_2 )
            {
                // A new frame is starting
                _frame_scores.Add(0);
                _frame_state = FRAME_STATES.ROLL_1;
            }


            if(_rolls_taken >= 20 )
            {
                throw new GameEndException();
            }

            if( pins_fallen < 10) // not a spare or strike
            {
                _rolls_taken++;
                _frame_scores[_frame_scores.Count - 1] += pins_fallen;
            }
            else // spare or strike
            {
                switch (_frame_state)
                {
                    case FRAME_STATES.ROLL_1:                    
                        // A strike has occurred
                        _frame_scores[_frame_scores.Count - 1] += pins_fallen;
                        break;

                }
            }

        }
    }

    public class when_pin_falls_get_nonzero_score : concerns
    {
        private BowlingGame _game;
        protected override void context()
        {
            _game = new BowlingGame();
        }

        [Specification]
        public void the_score_is_0()
        {
            _game.Roll(9);
            _game.getScore().should_not_equal(0);
        }

    }


    public class when_20_gutter_balls_are_rolled : concerns
    {
        private BowlingGame _game;
        protected override void context()
        {
            _game = new BowlingGame();
            20.times(() => _game.Roll(0));
        }

        [Specification]
        public void the_score_is_0()
        {
            _game.getScore().should_equal(0);
        }

    }

    public class when_20_ones_are_rolled : concerns
    {
        private BowlingGame _game;
        protected override void context()
        {
            _game = new BowlingGame();
            20.times(() => _game.Roll(1));
        }

        [Specification]
        public void the_score_is_20()
        {
            _game.getScore().should_equal(20);
        }

    }


    public class when_21_rolls_game_ends : concerns
    {
        private BowlingGame _game;
        protected override void context()
        {
            _game = new BowlingGame();
        }

        [Specification]
        public void the_game_ends()
        {
            20.times(() => _game.Roll(1));
            typeof (GameEndException).should_be_thrown_by(() => _game.Roll(1));
        }

    }

    public class when_a_spare_is_rolled_then_all_gutters :concerns
    {
        [Specification]
        public void score_is_10()
        {
            var game = new BowlingGame();
            game.Roll(4);
            game.Roll(6); //spare
            18.times(() => game.Roll(0));
            game.getScore().should_equal(10);
        }
    }


    public class when_a_spare_is_rolled_then_a_bonus_then_all_gutters : concerns
    {
        [Specification]
        public void score_is_10()
        {
            var game = new BowlingGame();
            game.Roll(4);
            game.Roll(6); //spare
            game.Roll(3); //bonus
            17.times(() => game.Roll(0));
            game.getScore().should_equal(16);
        }
    }
}




