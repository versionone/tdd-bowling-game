using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class Game
	{
		private List<int> rollScores = new List<int>();
		public void Roll(int pins)
		{
			rollScores.Add(pins);
		}
		public int GetScore()
		{
			int finalScore = 0;
			for (var i = 0; i < rollScores.Count; i++)
				finalScore += rollScores[i];
			return finalScore;
		}
	}
}
