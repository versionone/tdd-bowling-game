using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Game
	{
		public Game()
		{
		}

		private List<Frame> _frames = new List<Frame>();

		public void Roll(int pins)
		{			
			if (_frames.Count == 10 && _frames.Last().Open == false)
			{
				return;
			}

			// first frame
			if (_frames.Count == 0)
			{
				var frame = new Frame(1, pins);
				_frames.Add(frame);
			}
			else
			{
				var lastFrame = _frames.Last();
				if (!lastFrame.Open)
				{
					Frame newFrame;
					if (_frames.Count == 9)
					{
						newFrame = new TenthFrame(_frames.Count + 1, pins);
					}
					else
					{
						newFrame = new Frame(_frames.Count + 1, pins);
					}
					_frames.Add(newFrame);
				}
				else
				{
					lastFrame.Roll(pins);
				}
			}
		}

		public int Score()
		{
			return _frames.Sum(
				(frame) =>
				{
					var frameScore = frame.Score();
					if (frame.IsSpare || frame.IsStrike)
					{
						var nextFrame = _frames.Find(fr => fr.FrameIndex == frame.FrameIndex + 1);
						if (nextFrame != null)
						{
							frameScore += nextFrame.FirstRoll.Value;
						}
						if (frame.IsStrike)
						{
							if (nextFrame.SecondRoll.HasValue)
							{
								frameScore += nextFrame.SecondRoll.Value;
							}
							else
							{
								var secondBonusFrame = _frames.Find(fr => fr.FrameIndex == frame.FrameIndex + 2);
								if (secondBonusFrame != null)
								{
									frameScore += secondBonusFrame.FirstRoll.Value;
								}
							}

						}
					}

					return frameScore;
				});
		}
	}

	public class Frame
	{
		public Frame(int frameIndex, int firstRoll)
		{
			FirstRoll = firstRoll;
			FrameIndex = frameIndex;
		}

		public int FrameIndex { get; set; }

		public int? FirstRoll { get; set; }
		public int? SecondRoll { get; set; }

		public virtual bool Open
		{
			get
			{
				return !FirstRoll.HasValue || (
					!SecondRoll.HasValue && !IsStrike);
			}
		}

		public virtual int Score()
		{
			return FirstRoll.Value + (SecondRoll.HasValue ? SecondRoll.Value : 0);
		}

		public virtual void Roll(int pins) {
			SecondRoll = pins;
		}

		public bool IsStrike
		{
			get
			{
				return FirstRoll == 10;
			}
		}

		public bool IsSpare
		{
			get
			{
				return FirstRoll != 10 && FirstRoll + SecondRoll == 10;
			}
		}
	}

	public class TenthFrame : Frame
	{
		public TenthFrame(int frameIndex, int pins) : base(frameIndex, pins) {}
		
		public int? ThirdRoll { get; set; }

		public override bool Open
		{
			get
			{
				return (
					(IsSpare || IsStrike) && (!ThirdRoll.HasValue) ||
					!SecondRoll.HasValue
				);
			}
		}

		public override int Score() {
			return FirstRoll.Value + (SecondRoll.HasValue ? SecondRoll.Value : 0)
				+ (ThirdRoll.HasValue ? ThirdRoll.Value : 0);
		}

		public override void Roll(int pins) {
			if (!SecondRoll.HasValue) SecondRoll = pins;
			else ThirdRoll = pins;
		}
	}
}