using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	/*
	 
* when rolling all gutter balls, the score is 0.
* when rolling all 2s, the score is 40.
* when the first 2 rolls are 2 and the rest are 3, the score is 58.
* when rolling alternating 2s and 5s, the score 70.
* when the first frame is a spare and the remaining rolls are all 2, the score is 48.
* when the first 2 frames are spare (as 2,8) and the rest score 2, the score is 56.
* when 10 frames have been bowled, don't allow any more to be bowled.
* when the first frame is a strike and the rest score 2, the score is 50.
* when the first 2 frames are strikes and the rest score 2, the score is 68.
* when rolling a perfect game, the score is 300.
* when rolling alternate strikes and spares, the score is 200.
	 */

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
		private Game game = new Game();
		protected override void context()
		{
			for(int i = 0; i < 20; i++){ game.Roll(0);}
		}

		[Specification]
		public void the_score_is_zero()
		{
			game.Score.ShouldEqual(0);
		}
	}
	public class when_rolling_all_2s_the_score_is_40 : concerns
	{
		private Game game = new Game();
		protected override void context()
		{
			for (int i = 0; i < 20; i++) { game.Roll(2); }
		}

		[Specification]
		public void the_score_is_40()
		{
			game.Score.ShouldEqual(40);
		}
	}

}