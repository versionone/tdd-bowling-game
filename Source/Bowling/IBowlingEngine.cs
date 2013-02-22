namespace Bowling
{
    public interface IBowlingEngine
    {
        int Score { get; set; }
        int AddFrame(int firstRoll, int secondRoll);
    }
}