using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		private int _score;
		private IList<IFrame> _frames = new List<IFrame>();

		private IFrame CurrentFrame
		{
			get { return _frames.LastOrDefault(); }
		}

		public void Roll(int pins)
		{
			if (IsOver)
			{
				throw new Exception("Game is over.");
			}

			if (CurrentFrame == null || CurrentFrame.IsFinished())
			{
				_frames.Add(_frames.Count == 9 ? new TenthFrame(pins) : new Frame(pins));
			}
			else
			{
				CurrentFrame.AddRoll(pins);
			}
		}

		public bool IsOver
		{
			get
			{
				return _frames.Count(f => f.IsFinished()) == 10;
			}
		}


		public int Score
		{
			get
			{
				var score = 0;
				for (var frameIndex = 0; frameIndex < _frames.Count; frameIndex++)
				{
					var frame = _frames[frameIndex];
					score += frame.Score(_frames.Skip(frameIndex + 1).Take(2));
				}
				return score;
			}
		}
	}

	public class TenthFrame : Frame
	{
		public TenthFrame(int pins) : base(pins)
		{
		}

		public override bool IsFinished()
		{
			var finished = !(IsSpare() || IsStrike()) && base.IsFinished();
			return finished || _rolls.Count == 3;
		}

		public override void AddRoll(int pins)
		{
			if (IsFinished())
				throw new Exception("Frame is already full.");

			base.AddRoll(pins);
		}

		public override int Score(IEnumerable<IFrame> extraFrames)
		{
			return _rolls.Sum();
		}
	}

	public interface IFrame
	{
		int FirstRoll { get; }
		int? SecondRoll { get; }
		bool IsSpare();
		bool IsStrike();
		bool IsFinished();
		void AddRoll(int pins);
		int Score(IEnumerable<IFrame> extraFrames);
	}

	public class Frame : IFrame
	{
		protected readonly List<int> _rolls = new List<int>();

		public Frame(int pins)
		{
			_rolls.Add(pins);
		}

		public int FirstRoll { get { return _rolls.First(); } }
		public int? SecondRoll { get { return _rolls.ElementAtOrDefault(1); } }

		public bool IsSpare()
		{
			return !IsStrike() && _rolls.Take(2).Sum() == 10;
		}

		public virtual bool IsFinished()
		{
			return IsStrike() || _rolls.Count == 2;
		}

		public virtual void AddRoll(int pins)
		{
			_rolls.Add(pins);
		}

		public virtual int Score(IEnumerable<IFrame> extraFrames)
		{
			var score = _rolls.Sum();
			var nextRoll = extraFrames.First();

			if (IsSpare())
			{
				score += nextRoll.FirstRoll;
			}
			else if (IsStrike())
			{
				score += nextRoll.FirstRoll;

				if (nextRoll.IsStrike())
				{
					if (nextRoll is TenthFrame)
						score += ((TenthFrame) nextRoll).SecondRoll.Value;
					else
						score += extraFrames.ElementAt(1).FirstRoll;
				}
				else score += nextRoll.SecondRoll.GetValueOrDefault();
			}

			return score;
		}

		public bool IsStrike()
		{
			return _rolls.First() == 10;
		}
	}
}
