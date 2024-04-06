namespace PostgreEx.Core.Settings;

public record SeqPageCost(int Value)
{
    public static implicit operator int(SeqPageCost seqPageCost) => seqPageCost.Value;
}