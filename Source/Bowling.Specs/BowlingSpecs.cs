using Bowling.Specs.Infrastructure;


namespace specs_for_bowling
{

    public class BowlingGame
    {
        private int _current_roll_number = 0;
        private int _current_score = 0;

        public BowlingGame()
        {
        }

        public int getScore()
        {
            return _current_score;
        }

        public void Roll(int pins_fallen_)
        {
            // magic.
        }
    }

    public class when_20_gutter_balls_are_rolled : concerns
    {
        private BowlingGame _game;
        protected override void context()
        {
            _game = new BowlingGame();
            20.times( () => _game.Roll(0) );
        }

        [Specification]
        public void the_score_is_0()
        {
            _game.getScore().should_equal(0);s
        }

    }
}




// exception GameOver
//  var sc = new ScoreKeeper() ;
//  assert sc.getCurrentScore == 0;
// shouldRaiseException(...)
// foreach( i in 0..20) {
    // sc.nextRoll(0) 
    // }   
//assert sc.getScore() == 0;
//
//
// 
//
//
