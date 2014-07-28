using System;
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

    public class when_first_frame_is_spare_and_remaining_rolls_are_2: concerns
    {
        private BowlingGame _game;

        protected override void context()
        {
            _game = new BowlingGame();

            1.times(() =>
            {
                _game.Bowl(3);
                _game.Bowl(7);
            });

            9.times(() =>
            {
                _game.Bowl(2);
                _game.Bowl(2);
            });
        }

        [Specification]
        public void the_score_is_48()
        {
            _game.Score.ShouldEqual(48);
        }
    }

    public class when_the_first_2_frames_are_spares_and_the_rest_are_2s : concerns
    {
        private BowlingGame _game;

        protected override void context()
        {
            _game = new BowlingGame();

            2.times(() =>
            {
                _game.Bowl(2);
                _game.Bowl(8);
            });

            8.times(() =>
            {
                _game.Bowl(2);
                _game.Bowl(2);
            });
        }

        [Specification]
        public void the_score_is_56()
        {
            _game.Score.ShouldEqual(56);
        }
    }

    public class when_10_frames_have_been_bowled_game_over : concerns
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
        public void throw_an_exception()
        {
            typeof(GameOverException).ShouldBeThrownBy(() => _game.Bowl(2));
        }
    }

    public class when_the_first_roll_is_a_strike_and_the_rest_are_2 : concerns
    {
        private BowlingGame _game;

        protected override void context()
        {
            _game = new BowlingGame();

            _game.Bowl(10);
            9.times(() =>
            {
                _game.Bowl(2);
                _game.Bowl(2);
            });


        }

        [Specification]
        public void score_is_50()
        {
            _game.Score.ShouldEqual(50);
        }
    }

    public class when_the_first_two_rolls_are_a_strike_and_the_rest_are_2 : concerns
    {
        private BowlingGame _game;

        protected override void context()
        {
            _game = new BowlingGame();

            _game.Bowl(10);
            _game.Bowl(10);
            8.times(() =>
            {
                _game.Bowl(2);
                _game.Bowl(2);
            });


        }

        [Specification]
        public void score_is_68()
        {
            _game.Score.ShouldEqual(68);
        }
    }

    public class when_all_rolls_are_strikes : concerns
    {
        private BowlingGame _game;

        protected override void context()
        {
            _game = new BowlingGame();

            12.times(() =>
            {
                _game.Bowl(10);
            });


        }

        [Specification]
        public void score_is_300()
        {
            _game.Score.ShouldEqual(300);
        }
    }
}