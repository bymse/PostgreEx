using PostgreEx.Core.Plans;
using PostgreEx.Core.Settings;
using PostgreEx.Core.Statistics;

namespace PostgreEx.Core.Explanation.Costs;

public class CostsExplainer(IRelationStatistics relationStatistics, ICostSettings costSettings)
{
    public async Task<CostExplanation> Explain<T>(T plan) where T : Plan
    {
        return plan switch
        {
            SeqScanPlan seqScanPlan => await Explain(seqScanPlan),
            _ => throw new NotImplementedException()
        };
    }

    public async Task<CostExplanation> Explain(SeqScanPlan plan)
    {
        return new SeqScanCostExplanation
        (
            await relationStatistics.GetRelTuples(plan.RelationName),
            costSettings.CpuTupleCost,
            await relationStatistics.GetRelPages(plan.RelationName),
            costSettings.SeqPageCost
        );
    }
}