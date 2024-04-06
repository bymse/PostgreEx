namespace PostgreEx.Core.Statistics;

public record RelTuples(string Relation, int Count)
{
    public static implicit operator int(RelTuples tuples) => tuples.Count;
}