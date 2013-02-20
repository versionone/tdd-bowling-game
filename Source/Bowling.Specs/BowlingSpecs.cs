using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_rolling_all_gutters : concerns
	{
	    private int _score;

	    protected override void context()
		{
		    var game = new Game();
            20.times(()=> game.Roll(0));

		    _score = game.Score();
		}

		[Specification]
		public void the_score_is_zero()
		{
		    _score.should_equal(0);
		}
	}

    public class when_rolling_open_frame : concerns
    {
        private int _score;

        protected override void context()
        {
            var game = new Game();
            20.times(() => game.Roll(2));
            _score = game.Score();
        }

        [Specification]
        public void the_score_is_zero()
        {
            _score.should_equal(40);
        }
    }
}