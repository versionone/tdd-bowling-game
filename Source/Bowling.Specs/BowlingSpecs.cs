using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_you_throw_all_gutters : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			10.times(() => _game.RollFrame(0, 0));
		}

		[Specification]
		public void the_score_should_be_zero()
		{
			_game.Score().should_equal(0);
		}
	}

	public class when_you_throw_open_frames_only_scores_should_be_cumulative_of_frames : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			_game.RollFrame(2, 3);

			9.times(() => _game.RollFrame(0, 0));
		}

		[Specification]
		public void the_score_should_equal_five()
		{
			_game.Score().should_equal(5);
		}
	}

	public class when_you_throw_a_spare : concerns
	{
		private Game _game;

		protected override void context()
		{
			_game = new Game();

			_game.RollFrame(5, 5);

			_game.RollFrame(3, 0);

			8.times(() => _game.RollFrame(0, 0));
		}

		[Specification]
		public void the_score_is_16()
		{
			_game.Score().should_equal(16);
		}
	}

}