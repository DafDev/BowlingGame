namespace DafBowling.Domain.Exceptions;
public class TooManyPinsDownException : Exception
{
    public TooManyPinsDownException(string message) : base(message) { }
    public TooManyPinsDownException() : base() { }
}
