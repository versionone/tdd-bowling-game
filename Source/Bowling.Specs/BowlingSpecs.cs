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

    public class when_rolling_all_2s : concerns
    {
        private BowlingGame _game;

        protected override void context()
        {
            _game = new BowlingGame();

            10.times(() =>
            {
                _game.Bowl(2);
                _game.Bowl(2);
            });
        }

        [Specification]
        public void the_score_is_40()
        {
            _game.Score.ShouldEqual(40);
        }
    }

    public class when_rolling_two_2s_and_then_all_3s : concerns
    {
        private BowlingGame _game;

        protected override void context()
        {
            _game = new BowlingGame();

            _game.Bowl(2);
            _game.Bowl(2);

            9.times(() =>
            {
                _game.Bowl(3);
                _game.Bowl(3);
            });
        }

        [Specification]
        public void the_score_is_58()
        {
            _game.Score.ShouldEqual(58);
        }
    }

    public class when_alternating_2s_and_5s : concerns
    {
        private BowlingGame _game;

        protected override void context()
        {
            _game = new BowlingGame();

            10.times(() =>
            {
                _game.Bowl(2);
                _game.Bowl(5);
            });
        }

        [Specification]
        public void the_score_is_70()
        {
            _game.Score.ShouldEqual(70);
        }
    }

}