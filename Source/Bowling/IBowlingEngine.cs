namespace Bowling
{
    public interface IBowlingEngine
    {
	    int Score();
        int AddFrame(int firstRoll, int secondRoll);
    }
}