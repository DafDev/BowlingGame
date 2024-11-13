namespace DafBowling.Domain;

public class Game
{
    private const int MAX_FRAMES_PER_GAME = 10;
    private const int STRIKE = 10;
    private readonly Frame[] _frames = new Frame[MAX_FRAMES_PER_GAME];
    private readonly int _totalFrameCount;
    private int _frameRoll;

    public void Roll(int pins)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(pins);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(pins, STRIKE);
        var frame = new Frame();
        frame.Rolls.Add(pins);
        _frames[_totalFrameCount] = frame;
    }

    public int Score() 
    { 
        throw new NotImplementedException(); 
    }
}
