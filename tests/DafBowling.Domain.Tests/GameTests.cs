using FluentAssertions;

namespace DafBowling.Domain.Tests;

public class GameTests
{
    private readonly Game _sut = new();

    [Fact]
    public void GivenPinsTakenDownWhenRollShouldReturn()
    {
        // Given & When
        _sut.Roll(5);
    }

    [Fact]
    public void GivenPinsTakenDownNegativeWhenRollShouldThrowArgumentOutOfRangeException()
    {
        // Given & When
        var action = () => _sut.Roll(-2);

        // Should
        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GivenPinsTakenDownMoreThanTenWhenRollShouldThrowArgumentOutOfRangeException()
    {
        // Given & When
        var action = () => _sut.Roll(12);

        // Should
        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GivenThreeRollsWhenGetFrameShouldReturnTwoFrames()
    {
        // Given 
        _sut.Roll(5);
        _sut.Roll(3);
        _sut.Roll(4);

        // When & Should
        _sut.Frames.Should().HaveCount(2);
    }

    //[Fact]
    //public void GivenPinsTakenDownWhenRollShouldReturnApropriateScore()
    //{
    //    // Given 
    //    var firstRoll = 2;
    //    _sut.Roll(firstRoll);

    //    // When
    //    var actual = _sut.Score();

    //    // Should
    //    actual.Should().Be(2);
    //}
}