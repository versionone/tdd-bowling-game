using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public static class Extends
    {
        public static int CalculateScore(this List<Frame> frames)
        {
            foreach (var frame in frames) {
                if (!frame.IsStrike && !frame.IsSpare) continue;

                if (frame.IsLastFrame && frame.IsStrike) {
                    if (frame.SecondRoll.Pins.HasValue) frame.SetBonus(frame.SecondRoll.Pins.Value);
                    if (frame.BonusRoll.Pins.HasValue) frame.SetBonus(frame.BonusRoll.Pins.Value);
                    continue;
                }
                if (frame.IsLastFrame && frame.IsSpare) { continue; }

                var index = frames.IndexOf(frame);
                var next = frames[index + 1];

                if (next.FirstRoll.Pins != null) frame.SetBonus(next.FirstRoll.Pins.Value);

                if (!frame.IsStrike) continue;

                if (next.IsLastFrame || next.IsSpare) {
                    if (next.SecondRoll.Pins != null) frame.SetBonus(next.SecondRoll.Pins.Value);
                } else {
                    var secondNext = frames[index + 2];
                    if (secondNext.FirstRoll.Pins != null) frame.SetBonus(secondNext.FirstRoll.Pins.Value);
                }
            }

            return frames.Sum(f => f.GetScore());
        }

    }
}
