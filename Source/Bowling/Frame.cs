namespace Bowling
{
    public class Frame
    {
        private int _markBonus;
        public int FrameId { get; set; }
        public Roll FirstRoll { get; set; }
        public Roll SecondRoll { get; set; }
        public Roll BonusRoll { get; set; }
        public bool IsLastFrame
        {
            get { return FrameId == 10; }
        }
        public bool IsSpare
        {
            get { return !IsStrike && ((FirstRoll.Pins + SecondRoll.Pins) == 10); }
        }
        public bool IsStrike
        {
            get { return FirstRoll.IsStrike; }
        }
        public int GetScore()
        {
            var totalScore = 0;
            totalScore += FirstRoll.Pins.HasValue ? FirstRoll.Pins.Value : 0;
            totalScore += SecondRoll.Pins.HasValue ? SecondRoll.Pins.Value : 0;
            totalScore += IsLastFrame && BonusRoll.Pins.HasValue ? BonusRoll.Pins.Value : 0;
            totalScore += _markBonus;
            return totalScore;
        }
        public void SetBonus(int bonus)
        {
            _markBonus += bonus;
        }
        public bool IsFirstRoll
        {
            get { return !FirstRoll.Pins.HasValue; }
        }
        public bool IsSecondRoll
        {
            get { return FirstRoll.Pins.HasValue && !IsStrike && !SecondRoll.Pins.HasValue; }
        }
        public bool BonusRollAllowed
        {
            get { return IsLastFrame && !BonusRoll.Pins.HasValue && (IsStrike || IsSpare); }
        }
        public Frame(int frameId)
        {
            FrameId = frameId;
            FirstRoll = new Roll();
            SecondRoll = new Roll();
            BonusRoll = new Roll();
        }
    }
}
