using System.Linq.Expressions;
using PostgreEx.Core.Plans.Costs;
using PostgreEx.Core.Settings;
using PostgreEx.Core.Statistics;

namespace PostgreEx.Core.Explanation.Costs;

public class SeqScanCostExplanation(
    RelTuples relTuples,
    CpuTupleCost cpuTupleCost,
    RelPages relPages,
    SeqPageCost seqPageCost
) : CostExplanation
{
    public override Expression<Func<Cost>> NodeCost => () => cpuTupleCost * relTuples + relPages * seqPageCost;

    public override Expression<Func<Cost>> StartupCost => () => 0;
}