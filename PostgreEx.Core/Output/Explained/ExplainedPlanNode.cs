using PostgreEx.Core.Explanation.Costs;
using PostgreEx.Core.Plans.Nodes;

namespace PostgreEx.Core.Output.Explained;

public class ExplainedPlanNode(PlanNode node, CostExplanation costExplanation)
{
    public PlanNode Node { get; } = node;
    public CostExplanation CostExplanation { get; } = costExplanation;
}