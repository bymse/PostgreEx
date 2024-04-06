namespace PostgreEx.Core.Settings;

public record CpuTupleCost(double Value)
{
    public static implicit operator double(CpuTupleCost cpuTupleCost) => cpuTupleCost.Value;
}