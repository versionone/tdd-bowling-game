using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public interface IGame
	{
		int Score();
		void Roll(int numberOfPinsKnockedDown);
		bool IsComplete { get; }
	}

	public class Game : IGame
	{
		private int _score;
		private List<Frame> _frames = new List<Frame>();
		private Frame _currentFrame;

		public bool IsComplete
		{
			get { return _frames.Count == 10; }
		}

		public int Score()
		{
			return _score;
		}

		public void Roll(int numberOfPinsKnockedDown)
		{
			if (_currentFrame == null) // this is the first roll of a frame
			{
				_currentFrame = new Frame();
				_currentFrame.RollOne = numberOfPinsKnockedDown;
				if (_currentFrame.IsComplete)
				{
					ScoreFrame(_currentFrame);
					_currentFrame = null;
				}
			}
			else // this is a the second of a frame
			{
				_currentFrame.RollTwo = numberOfPinsKnockedDown;
				ScoreFrame(_currentFrame);
				_currentFrame = null;
			}
		}


		public void RollFrame(int numberOfPinsKnockedDownOnRollOne, int numberOfPinsKnockedDownOnRollTwo)
		{
			VerifyLegality(numberOfPinsKnockedDownOnRollOne, numberOfPinsKnockedDownOnRollTwo);

			var frame = new Frame();
			frame.RollOne = numberOfPinsKnockedDownOnRollOne;
			frame.RollTwo = numberOfPinsKnockedDownOnRollTwo;
			ScoreFrame(frame);

			_frames.Add(frame);
		}

		private void ScoreFrame(Frame frame)
		{
			if (!frame.IsValid)
				throw new Exception("illegal roll");

			_score += frame.Score();

			// calculate bonus pins if we have more than one frame completed
			if (_frames.Count > 0)
			{
				// last frame
				var frameOne = _frames[_frames.Count - 1];
				var frameTwo = frame;
				_score += CalculateBonusPins(frameOne, frameTwo);
			}

			_frames.Add(_currentFrame);
		}

		private void VerifyLegality(int numberOfPinsKnockedDownOnRollOne, int numberOfPinsKnockedDownOnRollTwo)
		{
			if (numberOfPinsKnockedDownOnRollOne > 10 || numberOfPinsKnockedDownOnRollOne < 0)
				throw new Exception("Roll 1 is out of bounds");
			if (numberOfPinsKnockedDownOnRollTwo > 10 || numberOfPinsKnockedDownOnRollTwo < 0)
				throw new Exception("Roll 2 is out of bounds");
		}

		private int CalculateBonusPins(Frame frameOne, Frame frameTwo)
		{
			var bonus = 0;
			if (!frameOne.IsOpen)
			{
				bonus += frameTwo.RollOne.Value;
			}

			if (frameOne.IsStrike)
			{
				bonus += frameTwo.RollTwo.Value;
			}

			return bonus;
		}

	}

	internal class Frame
	{
		private int _score;

		public int? RollOne { get; set; }

		public int? RollTwo { get; set; }

		public bool IsValid
		{
			get
			{

				if (RollOne.HasValue && (RollOne.Value > 10 || RollOne.Value < 0))
					return false;

				if (RollTwo.HasValue && (RollTwo.Value > 10 || RollTwo.Value < 0))
					return false;

				return true;
			}
		}

		public bool IsComplete
		{
			get { return (RollOne.HasValue && RollOne.Value == 10) || (RollOne.HasValue && RollTwo.HasValue); }
		}

		public bool IsOpen
		{
			get { return Score() < 10; }
		}

		public bool IsStrike
		{
			get { return RollOne == 10; }
		}

		public int Score()
		{
			return RollOne.Value + (RollTwo ?? 0);
		}
	}
}