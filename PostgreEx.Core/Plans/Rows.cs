namespace PostgreEx.Core.Plans;

public record Rows(int Count)
{
    public static implicit operator int(Rows rows) => rows.Count;
}