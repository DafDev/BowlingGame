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
    public void GivenMoreThanTenPinDownInFrameWhenRollShouldThrow()
    {
        // Given 
        _sut.Roll(9);
        var action = () => _sut.Roll(3);

        // When & Should
        action.Should().Throw<TooManyPinsDownException>();
    }

    [Theory]
    [MemberData(nameof(GameTestsData.OngoingGamesData), MemberType = typeof(GameTestsData))]
    public void GivenOngoingGameShouldReturnNumberOfFrames(List<int> inputData, int frameCount)
    {
        // Given 
        RollSetup(inputData);
        // When & Should
        _sut.Frames.Should().HaveCount(frameCount);
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


    [Fact]
    public void InLastFrameNoMoreThanTenPinsDownInOnRoll()
    {
        // Given 
        // Roll 1 to 9
        for (int i = 0; i < 5; i++) 
            _sut.Roll(10);

        // Roll 10
        _sut.Roll(3);
        // // When 
        var action = () => _sut.Roll(8);


        // Should
        action.Should().Throw<TooManyPinsDownException>();
    }

    [Theory]
    [MemberData(nameof(GameTestsData.ScoreGamesData), MemberType = typeof(GameTestsData))]
    public void GivenOngoigGameWhenScoreShouldReturlCurrentScore(List<int> rolls, int score) 
    {
        // Given
        RollSetup(rolls);

        // When 
        var actual = _sut.Score();

        // Should
        actual.Should().Be(score);
    }

    private void RollSetup(List<int> rolls) => rolls.ForEach(_sut.Roll);
}