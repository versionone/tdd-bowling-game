using System;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private int _ballsThrown;
		private bool _isSpare;
		private int _lastBallThrown;
		private int _numberOfFrames = 1;

		public int Score
		{
			get { return _score; }
		}

		public void Roll(int pins)
		{
			CheckForGameOver();

			AdvanceToNextBallOfCurrentFrame();

			if (_isSpare)
			{
				AddSpareBonus(pins);
				_isSpare = false;
			}

			if (HaveCompleteFrame() && CurrentFrameIsSpare(pins))
				_isSpare = true;

			AddRollToScore(pins);

			if (HaveCompleteFrame())
			{
				StartNewFrame();
			}
			else
				TrackFirstRollOfCurrentFrame(pins);
		}

		private int AdvanceToNextBallOfCurrentFrame()
		{
			return _ballsThrown += 1;
		}

		private int AddRollToScore(int pins)
		{
			return _score = _score + pins;
		}

		private void AddSpareBonus(int pins)
		{
			_score += pins;
		}

		private void CheckForGameOver()
		{
			if (_numberOfFrames > 10)
				throw new TooManyFramesException();
		}

		private int TrackFirstRollOfCurrentFrame(int pins)
		{
			return _lastBallThrown = pins;
		}

		private void StartNewFrame()
		{
			_ballsThrown = 0;
			_numberOfFrames++;
		}

		private bool CurrentFrameIsSpare(int pins)
		{
			return (pins + _lastBallThrown) == 10;
		}

		private bool HaveCompleteFrame()
		{
			return _ballsThrown == 2;
		}
	}


	public class TooManyFramesException : Exception { }
}