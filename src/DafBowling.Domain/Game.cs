using DafBowling.Domain.Exceptions;

namespace DafBowling.Domain;

public class Game
{
    private const int MAX_FRAMES_PER_GAME = 10;
    private const int MAX_NUMBER_OF_PINS = 10;
    public readonly List<Frame> Frames = [];
    private bool _isFrameOngoing = false;

    public void Roll(int pins)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(pins);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(pins, MAX_NUMBER_OF_PINS);
        if (Frames.Count >= MAX_FRAMES_PER_GAME && !_isFrameOngoing)
            return;

        var frame = _isFrameOngoing ? Frames.Last() : new Frame();
        if (!Frames.Contains(frame))
            Frames.Add(frame);

        if (AreThereTooManyPinsDown(pins, frame))
            throw new TooManyPinsDownException();

        frame.Rolls.Add(pins);
        _isFrameOngoing = CheckFrameIsOngoing(frame);
    }
    public int Score()
    {
        throw new NotImplementedException();
    }

    private bool AreThereTooManyPinsDown(int pins, Frame frame)
        => frame.Rolls.Sum() + pins > MAX_NUMBER_OF_PINS && Frames.Count < MAX_FRAMES_PER_GAME
            || Frames.Count == MAX_FRAMES_PER_GAME && frame.Rolls.Count == 1 && !frame.IsStrike() && frame.Rolls.Sum() + pins > MAX_NUMBER_OF_PINS
            || Frames.Count == MAX_FRAMES_PER_GAME && frame.Rolls.Count == 2 && frame.Rolls.Sum() + pins > 2 * MAX_NUMBER_OF_PINS;

    private bool CheckFrameIsOngoing(Frame frame) => frame.Rolls.Count < 2 && !frame.IsStrike()
            || (frame.IsStrike() || frame.IsSpare()) && Frames.Count == MAX_FRAMES_PER_GAME && frame.Rolls.Count < 3;

}
