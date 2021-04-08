using Bowling.Specs.Infrastructure;
using NUnit.Framework;

namespace Bowling.Specs
{
    public class when_one_frame_is_rolled
    {
        public Game _game;

        [SetUp]
        public void context()
        {
            _game = new Game();
        }

        [Test]
        public void rolling_one_frame_works()
        {
            //input 1, 4
            _game.Roll(1);
            _game.Roll(4);
            Assert.AreEqual(_game.GetScore(), 5);
        }

        [Test]
        public void rolling_full_game()
        {
            for (var i = 1; i <= 20; i++)
            {
                _game.Roll(1);
            }
            Assert.AreEqual(20, _game.GetScore());
        }

        [Test]
        public void rolling_a_spare_works()
        {
            _game.Roll(3);
            _game.Roll(7);
            _game.Roll(1);
            _game.Roll(0);

            Assert.AreEqual(12, _game.GetScore());
        }

        [Test]
        public void rolling_a_strike_works()
        {
            _game.Roll(10);
            _game.Roll(3);
            _game.Roll(5);

            Assert.AreEqual(26, _game.GetScore());

        }

        [Test]
        public void rolling_a_strike_back_to_back_works()
        {
            _game.Roll(10);
            _game.Roll(10);
            _game.Roll(2);
            _game.Roll(5);

            Assert.AreEqual(46, _game.GetScore());
        }
    }
}