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
        var frame = _isFrameStillBeingPlayed ? Frames.Last() : new Frame();
        if (!Frames.Contains(frame))
            Frames.Add(frame);

        frame.Rolls.Add(pins);
        _isFrameStillBeingPlayed = frame.Rolls.Count < 2 && !frame.IsStrike();
    }

    public int Score()
    {
        throw new NotImplementedException();
    }
}
