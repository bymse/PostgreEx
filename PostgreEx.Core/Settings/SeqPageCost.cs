namespace PostgreEx.Core.Settings;

public record SeqPageCost(double Value)
{
    public static implicit operator double(SeqPageCost seqPageCost) => seqPageCost.Value;
}