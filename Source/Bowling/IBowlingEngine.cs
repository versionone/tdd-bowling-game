namespace Bowling
{
    public interface IBowlingEngine
    {
	    int Score();
        void AddFrame(int firstRoll, int secondRoll);
    }
}