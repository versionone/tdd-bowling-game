using System;
using System.Collections.Generic;

namespace Bowling
{
	public class Game
	{
		readonly List<Frame> _frames = new List<Frame>();

		public Game()
		{
			_frames.Add(new Frame());
		}

		public int Score
		{
			get
			{
				var score = 0;
				foreach (var frame in _frames)
				{
					score += frame.Score;
				}
				return score;
			}
		}

		public void Roll(int pins)
		{
			CheckForGameOver();

			TrackRollOfCurrentFrame(pins);

			AddBonus(pins);

			if (HaveCompleteCurrentFrame())
				StartNewFrame();
		}


		private Frame LastFrame
		{
			get { return _frames[_frames.Count - 2]; }
		}

		private Frame FrameBeforeLast
		{
			get { return _frames[_frames.Count - 3]; }
		}

		private void AddBonus(int pins)
		{
			if (_frames.Count > 1)
				LastFrame.AddBonus(pins);
			if (_frames.Count > 2)
				FrameBeforeLast.AddBonus(pins);
		}

		private void CheckForGameOver()
		{
			if (_frames.Count > 10)
				throw new TooManyFramesException();
		}

		private void TrackRollOfCurrentFrame(int pins)
		{
			CurrentFrame.Roll(pins);
		}

		private void StartNewFrame()
		{
			_frames.Add(new Frame());
		}

		private bool HaveCompleteCurrentFrame()
		{
			return CurrentFrame.IsComplete;
		}

		private Frame CurrentFrame
		{
			get { return _frames[_frames.Count - 1]; }
		}

		class Frame
		{
			private int? _firstRoll;
			private int? _secondRoll;
			private int? _firstBonus;
			private int? _secondBonus;

			public int Score { get { return (_firstRoll ?? 0) + (_secondRoll ?? 0) + (_firstBonus ?? 0) +(_secondBonus ?? 0); } }

			public bool IsSpare { get { return _secondRoll.HasValue && (_firstRoll.Value + _secondRoll.Value) == 10; } }

			public bool IsStrike { get { return _firstRoll.Value == 10; } }

			public bool IsComplete { get { return _secondRoll.HasValue || IsStrike; } }

			public void Roll(int pins)
			{
				if (!_firstRoll.HasValue)
					_firstRoll = pins;
				else
					_secondRoll = pins;
			}

			public void AddBonus(int pins)
			{
				if (IsSpare && !_firstBonus.HasValue)
					_firstBonus = pins;
				if (IsStrike)
				{
					if (!_firstBonus.HasValue)
						_firstBonus = pins;
					else
						_secondBonus = pins;
				}
			}
		}
	}


	public class TooManyFramesException : Exception { }
}