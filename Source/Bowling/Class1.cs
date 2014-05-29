using System;

public class Game
{
	public int score;
	public int rollNum;
	public int strike;
	public int lastRoll;
	public int lastFrame;

	public Game()
	{
		rollNum = 1;
	}

	public void Roll(int n) 
	{
		/*if (rollNum >= 21)
			throw new Exception();*/

		if (IsLastRollOfFrame())
		{
			lastFrame = lastRoll + n;
		}
		else 
		{
			if (LastFrameWasSpare())
			{
				score = score + n;
			}
			else if (strike > 0)
			{
				for (int i = 1; i <= strike; i++)
					score = score + n;
			}
			if (10 == n)
			{
				strike++;
				rollNum++;
			}
			else
			{
				strike--;
			}
		}

		score = score + n;
		rollNum++;
		lastRoll = n;
	}

	private bool IsLastRollOfFrame()
	{
		return 0 == (rollNum%2);
	}

	private bool LastFrameWasSpare()
	{
		return 10 == lastFrame;
	}
}
