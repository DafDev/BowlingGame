namespace DafBowling.Domain;
public class Frame
{
    public IList<int> Rolls { get; set; } = [];
    public int Points { get; set; }
}
