using System.Linq;
using Bowling;
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

    public class when_9_strikes_rolled_then_then_three_gutters_game_ends : concerns
    {
        [Specification]
        public void score_is_10()
        {
            var game = new BowlingGame();
            9.times(() => game.Roll(10));
            game.Roll(0);
            game.Roll(0);
            typeof (GameEndException).should_be_thrown_by(() => game.Roll(0));
        }
    }

    public class when_9_strikes_rolled_then_two_gutters_score_is_XX : concerns
    {
        [Specification]
        public void score_is_250()
        {
            var game = new BowlingGame();
            9.times(() => game.Roll(10));
            game.Roll(0);
            game.Roll(0);
            game.getScore().should_equal(240);
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

    public class when_all_strikes_are_rolled : concerns
    {
        [Specification]
        public void score_is_10()
        {
            var game = new BowlingGame();
            12.times(() => game.Roll(10));
            game.getScore().should_equal(300);
            typeof (GameEndException).should_be_thrown_by(()=>game.Roll(5));
        }
    }
}




