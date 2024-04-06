namespace PostgreEx.Core.Settings;

public interface ICostSettings
{
    SeqPageCost SeqPageCost { get; }
    CpuTupleCost CpuTupleCost { get; }
}