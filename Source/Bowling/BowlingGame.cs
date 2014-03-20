using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class Frame
	{
		private int? _FirstBallPins;
		private int? _SecondBallPins;
		private int? _Bonus;

		public int Score
		{
			get
			{
				if (IsScorable)
				{
					return _FirstBallPins.Value + _SecondBallPins.Value + (_Bonus ?? 0);
				}
			
				throw new InvalidOperationException("Not scorable, don't do this.");	
			}
		}

		public bool IsScorable
		{
			get
			{
				if (IsSpare || IsStrike)
				{
					return _Bonus.HasValue;
				}
				return IsFull;
			}
		}

		public bool IsSpare
		{
			get { return (IsFull && (_FirstBallPins + _SecondBallPins == 10)); }
		}

		public bool IsStrike
		{
			get { return (_FirstBallPins == 10); }
		}

		public bool IsFull
		{
			get { return (_FirstBallPins.HasValue && _SecondBallPins.HasValue) || IsStrike; }
		}

		public void Roll(int pins)
		{
			if (_FirstBallPins == null)
			{
				_FirstBallPins = pins;
			}
			else if (_SecondBallPins ==  null)
			{
				_SecondBallPins = pins;
			}
			else
			{
				_Bonus = pins;
			}
		}
	}

	public class BowlingGame
	{
		private readonly Frame[] _frames = new Frame[10];
		private int _currentFrame = 0;

		public BowlingGame()
		{
			for (var i = 0; i < _frames.Length; i++)
			{
				_frames[i] = new Frame();
			}
		}

		public void Roll(int pins)
		{
			if (_frames[_currentFrame].IsFull)
			{
				_currentFrame++;

				if (_currentFrame == _frames.Length)
				{
					throw new InvalidOperationException("Too many frames, ist verbotten.");
				}
			}

			_frames[_currentFrame].Roll(pins);

			// So far this handles spares
			if (_currentFrame > 0 && !_frames[_currentFrame - 1].IsScorable)
			{
				_frames[_currentFrame - 1].Roll(pins);
			}

			// Make this handle strikes
			if (_currentFrame > 0 && _frames[_currentFrame - 1].IsStrike && _frames[_currentFrame - 1].IsScorable && _frames[_currentFrame].IsFull)
			{
				_frames[_currentFrame - 1].Roll(pins);
			}
		}

		public int Score
		{
			get { return CalculateScore(); }
		}

		private int CalculateScore()
		{
			return _frames.Where(t => t.IsScorable).Sum(t => t.Score);
		}
	}
}
