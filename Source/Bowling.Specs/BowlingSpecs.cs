using System;
using Bowling.Specs.Infrastructure;
using Bowling;
using NUnit.Framework;

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
        private Scorecard card;

        protected override void context()
        {
            card = new Scorecard();
            for (var i = 0; i < 20; i++)
            {
                card.roll(0); 
            }           
        }

        [Specification]
        public void score_is_0()
        {
            ShouldExtensionMethods.ShouldEqual(card.GetScore(), 0);
        }
    }

    public class when_rolling_all_2s : concerns
    {
        private Scorecard card;

        protected override void context()
        {
            card = new Scorecard();
            for (var i = 0; i < 20; i++)
            {
                card.roll(2);
            }
        }

        [Specification]
        public void score_is_20()
        {
            ShouldExtensionMethods.ShouldEqual(card.GetScore(), 40);
        }
    }

    public class when_rolling_2s_and_5s : concerns
    {
        private Scorecard card;

        protected override void context()
        {
            card = new Scorecard();
            for (var i = 0; i < 20; i++)
            {
                if (i % 2 == 0) { card.roll(2); }
                else { card.roll(5); }
            }
        }

        [Specification]
        public void score_is_70()
        {
            card.GetScore().ShouldEqual(70);
        }
    }

    public class when_rolling_spare_and_2s : concerns
    {
        private Scorecard card;

        protected override void context()
        {
            card = new Scorecard();
            card.roll(8);
            for (var i = 1; i < 20; i++)
            {
                card.roll(2);
                
            }
        }

        [Specification]
        public void score_is_48()
        {
            card.GetScore().ShouldEqual(48);
        }
    }


    public class when_rolling_2s_and_3s : concerns
    {
        private Scorecard card;

        protected override void context()
        {
            card = new Scorecard();
            card.roll(2);
            card.roll(2);
            for (var i = 2; i < 20; i++)
            {
                card.roll(3);

            }
        }

        [Specification]
        public void score_is_58()
        {
            card.GetScore().ShouldEqual(58);
        }
    }

    public class when_rolling_2_spares_and_2s : concerns
    {
        private Scorecard card;

        protected override void context()
        {
            card = new Scorecard();
            card.roll(2);
            card.roll(8);
            card.roll(2);
            card.roll(8);
            for (var i = 4; i < 20; i++)
            {
                card.roll(2);
            }
        }

        [Specification]
        public void score_is_56()
        {
            card.GetScore().ShouldEqual(56);
        }
    }

    public class when_rolling_too_many_frames : concerns
    {
        private Scorecard card;

        protected override void context()
        {
            card = new Scorecard();
        }

        [Specification, ExpectedException(typeof(TooManyRollsException))]
        public void exception_is_thrown()
        {
            for (var i = 0; i < 21; i++)
            {
                card.roll(2);
            }
        }
    }

    public class when_rolling_one_strike_and_2s : concerns
    {
        private Scorecard card;

        protected override void context()
        {
            card = new Scorecard();

            card.roll(10);
            for (var i = 1; i < 20; i++)
            {
                card.roll(2);
            }

        }

        [Specification]
        public void score_is_50()
        {
            card.GetScore().ShouldEqual(50);
        }
    }

    public class when_rolling_two_strike_and_2s : concerns
    {
        private Scorecard card;

        protected override void context()
        {
            card = new Scorecard();

            card.roll(10);
            card.roll(10);
            for (var i = 2; i < 20; i++)
            {
                card.roll(2);
            }

        }

        [Specification]
        public void score_is_68()
        {
            card.GetScore().ShouldEqual(68);
        }
    }

    public class when_rolling_a_perfect_game : concerns
    {
        private Scorecard card;

        protected override void context()
        {
            card = new Scorecard();
            for (var i = 0; i < 12; i++)
            {
                card.roll(10);
            }

        }

        [Specification]
        public void score_is_300()
        {
            card.GetScore().ShouldEqual(300);
        }
    }

    public class when_rolling_dutch : concerns
    {
        private Scorecard card;

        protected override void context()
        {
            card = new Scorecard();
            for (var i = 0; i < 5; i++)
            {
                card.roll(10);
                card.roll(5);
                card.roll(5);
            }
            card.roll(10);

        }

        [Specification]
        public void score_is_200()
        {
            card.GetScore().ShouldEqual(200);
        }
    }
}