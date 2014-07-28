using Bowling.Specs.Infrastructure;
using Bowling;

namespace specs_for_bowling
{
	public class when_everything_is_wired_up : concerns
	{
		private bool _itWorked;

		protected override void context()
		{
			_itWorked = true;
		}

		[Specification]
		public void it_works()
		{
			_itWorked.ShouldBeTrue();
		}
	}

    public class when_rolling_all_gutter_balls : concerns
    {
        private BowlingGame _game;

        protected override void context()
        {
            _game = new BowlingGame();

            20.times(() => _game.Bowl(0));
        }

        [Specification]
        public void the_score_is_0()
        {
            _game.Score.ShouldEqual(0);
        }
    }
}