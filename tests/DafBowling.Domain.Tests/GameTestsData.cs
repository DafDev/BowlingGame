namespace DafBowling.Domain.Tests;
internal class GameTestsData
{
    public static TheoryData<List<int>,int,int> LastFrameWithExtraRollsOrNotData()
    {
        List<int> firstNineFrameResults = [10, 3, 2, 7, 3, 6, 4, 3, 6, 3, 7, 3, 5, 4, 3, 2, 4];
        
        List<int> extraRollWithSpareData = [];
        extraRollWithSpareData.AddRange(firstNineFrameResults);
        extraRollWithSpareData.AddRange([3, 7, 7]);

        List<int> extraRollWithStrikeData = [];
        extraRollWithStrikeData.AddRange(firstNineFrameResults);
        extraRollWithStrikeData.AddRange([10,8]);

        var frameCount = 10;
        return new()
        {
            {extraRollWithSpareData,frameCount,3 },
            {extraRollWithStrikeData,frameCount,2 },
        };
    }
}
