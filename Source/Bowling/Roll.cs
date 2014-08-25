
namespace Bowling
{
    public class Roll
    {
        public int? Pins { get; set; }
        public bool IsStrike
        {
            get { return Pins.HasValue && Pins.Value == 10; }
        }
    }
}
