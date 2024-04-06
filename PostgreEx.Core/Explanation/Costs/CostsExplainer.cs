using PostgreEx.Core.Plans;
using PostgreEx.Core.Plans.Nodes;
using PostgreEx.Core.Settings;
using PostgreEx.Core.Statistics;

namespace PostgreEx.Core.Explanation.Costs;

public class CostsExplainer(IRelationStatistics relationStatistics, ICostSettings costSettings)
{
    public async Task<CostExplanation> Explain<T>(T plan) where T : PlanNode
    {
        return plan switch
        {
            SeqScanPlanNode seqScanPlan => await Explain(seqScanPlan),
            _ => throw new NotImplementedException()
        };
    }

    public async Task<CostExplanation> Explain(SeqScanPlanNode planNode)
    {
        return new SeqScanCostExplanation
        (
            await relationStatistics.GetRelTuples(planNode.RelationName),
            costSettings.CpuTupleCost,
            await relationStatistics.GetRelPages(planNode.RelationName),
            costSettings.SeqPageCost
        );
    }
}