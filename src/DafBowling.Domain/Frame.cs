

namespace DafBowling.Domain;
public class Frame
{
    public List<int> Rolls { get; set; } = [];
    public int Points { get; set; }

    public bool IsSpare() => Rolls.Count > 1 && Rolls.Sum() == 10;

    public bool IsStrike()
    {
        return Rolls.Count == 1 && Rolls.Single() == 10;
    }
}
