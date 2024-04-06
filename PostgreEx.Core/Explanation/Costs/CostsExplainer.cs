using PostgreEx.Core.Plans.Nodes;
using PostgreEx.Core.Settings;
using PostgreEx.Core.Statistics;

namespace PostgreEx.Core.Explanation.Costs;

public class CostsExplainer(IRelationStatistics relationStatistics, ICostSettingsProvider costSettingsProvider)
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
        var costSettings = await costSettingsProvider.GetSettings();
        return new SeqScanCostExplanation
        (
            await relationStatistics.GetRelTuples(planNode.RelationName),
            costSettings.CpuTupleCost,
            await relationStatistics.GetRelPages(planNode.RelationName),
            costSettings.SeqPageCost
        );
    }
}