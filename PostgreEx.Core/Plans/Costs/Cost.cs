namespace PostgreEx.Core.Plans.Costs;

public record Cost(double Value)
{
    public static bool operator >(Cost a, Cost b) => a.Value > b.Value;
    public static bool operator <(Cost a, Cost b) => a.Value < b.Value;
    public static bool operator >=(Cost a, Cost b) => a.Value >= b.Value;
    public static bool operator <=(Cost a, Cost b) => a.Value <= b.Value;
    
    public static implicit operator double(Cost cost) => cost.Value;
    public static implicit operator Cost(double cost) => new(cost);
}