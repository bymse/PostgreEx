namespace PostgreEx.Core.Settings;

public record SeqPageCost(decimal Value)
{
    public static implicit operator decimal(SeqPageCost seqPageCost) => seqPageCost.Value;
}