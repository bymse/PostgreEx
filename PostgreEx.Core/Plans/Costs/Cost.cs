namespace PostgreEx.Core.Costs;

public record Cost(decimal Value)
{
    public static bool operator >(Cost a, Cost b) => a.Value > b.Value;
    public static bool operator <(Cost a, Cost b) => a.Value < b.Value;
    public static bool operator >=(Cost a, Cost b) => a.Value >= b.Value;
    public static bool operator <=(Cost a, Cost b) => a.Value <= b.Value;
    
    public static implicit operator decimal(Cost cost) => cost.Value;
    public static implicit operator Cost(decimal cost) => new(cost);
}