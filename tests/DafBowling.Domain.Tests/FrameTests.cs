using FluentAssertions;

namespace DafBowling.Domain.Tests;
public class FrameTests
{
    private readonly Frame _sut = new();

    [Theory]
    [InlineData(4, 6, true)]
    [InlineData(4, 5, false)]
    public void GivenTotalNumberOfPinInFrameWhenIsSpareShouldReturnAproriateResult(int firstRoll, int secondRoll, bool expected)
    {
        // Given
        _sut.Rolls.Add(firstRoll);
        _sut.Rolls.Add(secondRoll);

        // When
        var actual = _sut.IsSpare();
        
        // Should
        actual.Should().Be(expected);
    }

    [Fact]
    public void GivenTotalTenFallenPinInoneTryWhenIsStrikeShouldReturnTrue()
    {
        // Given
        _sut.Rolls.Add(10);

        // When
        var actual = _sut.IsStrike();

        // Should
        actual.Should().BeTrue();
    }
}
