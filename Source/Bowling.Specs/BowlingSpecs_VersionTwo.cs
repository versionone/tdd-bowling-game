using System;
using System.Collections;
using NUnit.Framework;

namespace Bowling.Specs
{
    [TestFixture]
    public class BowlingSpecs_VersionTwo
    {
        [Test, TestCaseSource(typeof(BowlingTestCases), "BowlingSimulator")]
        public int BowlingTest(string sim)
        {
            var game = new Player();
            var rolls = sim.Split(';');
            foreach (var pins in rolls) {
                game.Roll(Convert.ToInt32(pins));
            }
            return game.Score();
        }
    }

    public class BowlingTestCases
    {
        public static IEnumerable BowlingSimulator
        {
            get {
                yield return new TestCaseData("0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0").Returns(0).SetName("Gutter Ball Test");
                yield return new TestCaseData("2;2;3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;3").Returns(58).SetName("First 2 roll is 2 then rest are 3.");
                yield return new TestCaseData("5;5;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2").Returns(48).SetName("First 2 roll are spare and rest are 2.");
                yield return new TestCaseData("2;8;2;8;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2").Returns(56).SetName("First 4 roll are spare and rest are 2.");
                yield return new TestCaseData("10;10;10;10;10;10;10;10;10;10;10;10").Returns(300).SetName("Perfect game");
                yield return new TestCaseData("2;5;2;5;2;5;2;5;2;5;2;5;2;5;2;5;2;5;2;5").Returns(70).SetName("Alternative 2 and 5");
                yield return new TestCaseData("10;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2").Returns(50).SetName("Strike then all 2s.");
                yield return new TestCaseData("10;10;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2").Returns(68).SetName("2 Strike then all 2s.");
                yield return new TestCaseData("10;5;5;10;5;5;10;5;5;10;5;5;10;5;5;10").Returns(200).SetName("Alternate strike and spare.");
                yield return new TestCaseData("2;2;3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;5;5;9").Returns(71).SetName("Last Strike with bonus ball");
                yield return new TestCaseData("0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0")
                    .SetName("Rolled Extra ball, not allowed").Throws(typeof (ApplicationException));
            }
        }
    }
}
