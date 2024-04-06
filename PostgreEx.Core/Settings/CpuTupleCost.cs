namespace PostgreEx.Core.Settings;

public record CpuTupleCost(decimal Value)
{
    public static implicit operator decimal(CpuTupleCost cpuTupleCost) => cpuTupleCost.Value;
}