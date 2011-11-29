using System.Collections.Generic;
using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class BowlingGameTests : concerns
	{

        [SpecificationAttribute]
        public void given_i_have_rolled_a_two_and_a_three_my_score_should_be_five()
        {
            var game = new BowlingGame();
            game.Roll(2);
            game.Roll(3);
            game.GameTotal.should_equal(5);
        }

        [Specification]
        public void given_i_have_not_completed_a_frame_my_score_should_not_include_incomplete_frame()
        {
            var game = new BowlingGame();
            game.Roll(2);
            game.Roll(3);
            game.Roll(4);
            game.GameTotal.should_equal(5);
        }

        [Specification]
        public void given_i_have_rolled_a_two_made_a_spare_then_rolled_a_six()
        {
            var game = new BowlingGame();
            game.Roll(2);
            game.Roll(8);
            game.Roll(6);
            game.Roll(0);

            game.GameTotal.should_equal(22);
        }

        [Specification]
        public void given_i_have_rolled_two_balls_should_close_out_frame()
        {
            var frame = new OpenFrame();
            frame.AddRoll(new Roll(5));
            frame.AddRoll(new Roll(2));
            frame.IsCompelete().should_be_true();

            frame.IsCompelete().should_be_true();
        }

        [Specification]
        public void WhenAllGutterBalls_ScoreShouldEqualZero()
        {
            var game = new BowlingGame();
            20.times(()=> game.Roll(0));
            game.GameTotal.should_equal(0);
        }

        [Specification]
        public void WhenThereIsASpare_ShouldAddNextBall()
        {
            var game = new BowlingGame();
            game.Roll(8);
            game.Roll(2);
            game.Roll(9);
            game.Roll(0);

            game.GameTotal.should_equal(19 + 9);
        }

        [Specification]
        public void WhenThereIsAStrike_ShouldAddNextTwoBalls()
        {
            var game = new BowlingGame();
            game.Roll(10);
            game.Roll(8);
            game.Roll(0);

            game.GameTotal.should_equal(18 + 8);
        }

        [Specification]
        public void WhenTwoStrikes_ShouldCalcSoemthing()
        {
            var game = new BowlingGame();
            game.Roll(10);
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);

            game.GameTotal.should_equal(25 + 20 + 10);

        }

        [Specification]
        public void when_i_roll_12_strikes_should_equal_300()
        {
            var forSparta = new BowlingGame();
            12.times(() => forSparta.Roll(10));

            forSparta.GameTotal.should_equal(300);
        }

	}
}