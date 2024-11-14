namespace DafBowling.Domain;

public class Game
{
    private const int MAX_FRAMES_PER_GAME = 10;
    private const int STRIKE = 10;
    public readonly List<Frame> Frames = [];
    private readonly int _totalFrameCount = 0;
    private int _frameRoll = 0;
    private bool _isFrameStillBeingPlayed = false;

    public void Roll(int pins)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(pins);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(pins, STRIKE);
        var frame = _isFrameStillBeingPlayed ? Frames.Last() : new Frame() ;
        if (frame.Rolls.Count == 0)
        {
            Frames.Add(frame);
            _isFrameStillBeingPlayed = true;

        }
        else
        {
            _isFrameStillBeingPlayed = false;
        }
        frame.Rolls.Add(pins);
    }

    public int Score() 
    { 
        throw new NotImplementedException(); 
    }
}
