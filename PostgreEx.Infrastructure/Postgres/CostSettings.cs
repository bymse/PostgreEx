using PostgreEx.Core.Settings;

namespace PostgreEx.Infrastructure.Postgres;

public class CostSettings(SeqPageCost seqPageCost, CpuTupleCost cpuTupleCost) : ICostSettings
{
    public SeqPageCost SeqPageCost { get; } = seqPageCost;
    public CpuTupleCost CpuTupleCost { get; } = cpuTupleCost;
}