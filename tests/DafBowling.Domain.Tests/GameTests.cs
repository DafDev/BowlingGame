using DafBowling.Domain.Exceptions;
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

    [Fact]
    public void GivenTwoRollsWithStrikeWhenRollShouldReturnTwoFrames()
    {
        // Given 
        _sut.Roll(10);
        _sut.Roll(3);

        // When & Should
        _sut.Frames.Should().HaveCount(2);
    }

    [Fact]
    public void GivenMoreThanTenPinDownInFrameWhenRollShouldThrow()
    {
        // Given 
        _sut.Roll(9);
        var action = () => _sut.Roll(3);

        // When & Should
        action.Should().Throw<TooManyPinsDownException>();
    }

    [Theory]
    [MemberData(nameof(GameTestsData.LastFrameWithExtraRollsOrNotData), MemberType = typeof(GameTestsData))]
    public void GivenRightConditionsOnLasFrameWhenGetFrameShouldReturnLastFrameWithExtraRoll(List<int> rolls,int frameCount,int lastFrameRollCount)
    {
        // Given
        RollSetup(rolls);

        // When & Should
        _sut.Frames.Should().HaveCount(frameCount);
        _sut.Frames.Last().Rolls.Should().HaveCount(lastFrameRollCount);
    }

    private void RollSetup(List<int> rolls) => rolls.ForEach(_sut.Roll);

    [Fact]
    public void GivenRightConditionsWithSpareWhenGetFrameShouldReturnLastFrameWithThreeRolls()
    {
        // Given 
        // Roll 1
        _sut.Roll(10);
        // Roll 2
        _sut.Roll(3);
        _sut.Roll(2);
        // Roll 3
        _sut.Roll(7);
        _sut.Roll(3);
        // Roll 4
        _sut.Roll(6);
        _sut.Roll(4);
        // Roll 5
        _sut.Roll(3);
        _sut.Roll(6);
        // Roll 6
        _sut.Roll(3);
        _sut.Roll(7);
        // Roll 7
        _sut.Roll(3);
        _sut.Roll(5);
        // Roll 8
        _sut.Roll(3);
        _sut.Roll(4);
        // Roll 9
        _sut.Roll(2);
        _sut.Roll(4);
        // Roll 10
        _sut.Roll(3);
        _sut.Roll(7);
        _sut.Roll(7);

        // When & Should
        _sut.Frames.Should().HaveCount(10);
        _sut.Frames.Last().Rolls.Should().HaveCount(3);
    }

    [Fact]
    public void GivenRightConditionsWithStrikeWhenGetFrameShouldReturnLastFrameWithThreeRolls()
    {
        // Given 
        // Roll 1
        _sut.Roll(10);
        // Roll 2
        _sut.Roll(3);
        _sut.Roll(2);
        // Roll 3
        _sut.Roll(7);
        _sut.Roll(3);
        // Roll 4
        _sut.Roll(6);
        _sut.Roll(4);
        // Roll 5
        _sut.Roll(3);
        _sut.Roll(6);
        // Roll 6
        _sut.Roll(3);
        _sut.Roll(7);
        // Roll 7
        _sut.Roll(3);
        _sut.Roll(5);
        // Roll 8
        _sut.Roll(3);
        _sut.Roll(4);
        // Roll 9
        _sut.Roll(2);
        _sut.Roll(4);
        // Roll 10
        _sut.Roll(10);
        _sut.Roll(7);

        // When & Should
        _sut.Frames.Should().HaveCount(10);
        _sut.Frames.Last().Rolls.Should().HaveCount(2);
    }

    [Fact]
    public void GivenNoRightConditionsWithStrikeWhenGetFrameShouldReturnLastFrameWithTwoRolls()
    {
        // Given 
        // Roll 1
        _sut.Roll(10);
        // Roll 2
        _sut.Roll(3);
        _sut.Roll(2);
        // Roll 3
        _sut.Roll(7);
        _sut.Roll(3);
        // Roll 4
        _sut.Roll(6);
        _sut.Roll(4);
        // Roll 5
        _sut.Roll(3);
        _sut.Roll(6);
        // Roll 6
        _sut.Roll(3);
        _sut.Roll(7);
        // Roll 7
        _sut.Roll(3);
        _sut.Roll(5);
        // Roll 8
        _sut.Roll(3);
        _sut.Roll(4);
        // Roll 9
        _sut.Roll(2);
        _sut.Roll(4);
        // Roll 10
        _sut.Roll(2);
        _sut.Roll(7);
        _sut.Roll(7);

        // When & Should
        _sut.Frames.Should().HaveCount(10);
        _sut.Frames.Last().Rolls.Should().HaveCount(2);
    }

    [Fact]
    public void NoMoreThanTenFramesByGame()
    {
        // Given 
        // Roll 1
        _sut.Roll(10);
        // Roll 2
        _sut.Roll(3);
        _sut.Roll(2);
        // Roll 3
        _sut.Roll(7);
        _sut.Roll(3);
        // Roll 4
        _sut.Roll(6);
        _sut.Roll(4);
        // Roll 5
        _sut.Roll(1);
        _sut.Roll(8);
        // Roll 6
        _sut.Roll(3);
        _sut.Roll(7);
        // Roll 7
        _sut.Roll(3);
        _sut.Roll(5);
        // Roll 8
        _sut.Roll(3);
        _sut.Roll(4);
        // Roll 9
        _sut.Roll(2);
        _sut.Roll(4);
        // Roll 10
        _sut.Roll(3);
        _sut.Roll(6);
        // Roll 11
        _sut.Roll(5);

        // When & Should
        _sut.Frames.Should().HaveCount(10);
    }

    [Fact]
    public void InLastFrameNoMoreThanTenPinsDownInOnRoll()
    {
        // Given 
        // Roll 1
        _sut.Roll(10);
        // Roll 2
        _sut.Roll(3);
        _sut.Roll(2);
        // Roll 3
        _sut.Roll(7);
        _sut.Roll(3);
        // Roll 4
        _sut.Roll(6);
        _sut.Roll(4);
        // Roll 5
        _sut.Roll(1);
        _sut.Roll(8);
        // Roll 6
        _sut.Roll(3);
        _sut.Roll(7);
        // Roll 7
        _sut.Roll(3);
        _sut.Roll(5);
        // Roll 8
        _sut.Roll(3);
        _sut.Roll(4);
        // Roll 9
        _sut.Roll(2);
        _sut.Roll(4);
        // Roll 10
        _sut.Roll(3);
        // // When 
        var action = () => _sut.Roll(8);


        // Should
        action.Should().Throw<TooManyPinsDownException>();
    }
}