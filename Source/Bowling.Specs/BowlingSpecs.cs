using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_everything_is_wired_up : concerns
	{
		private bool _itWorked;

		protected override void context()
		{
		}

		[Specification]
		public void EightScoreGame()
		{
		    Game game = new Game();
            game.Roll(8);
		    game.GetScore().should_equal(8);
		}

        [Specification]
        public void TestForStrike()
        {
            Game game = new Game();
            game.Roll(10);
            game.GetScore().should_equal(10);
        }


        [Specification]
        public void TestForFirstFourRolls()
        {
            Game game = new Game();
            game.Roll(1);
            game.Roll(4);
            game.GetScore().should_equal(5);
            game.Roll(4);
            game.Roll(5);
            game.GetScore().should_equal(14);
        }



	}
}