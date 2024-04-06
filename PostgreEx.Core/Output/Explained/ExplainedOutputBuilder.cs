using PostgreEx.Core.Explanation.Costs;
using PostgreEx.Core.Plans;
using PostgreEx.Core.Plans.Nodes;

namespace PostgreEx.Core.Output.Explained;

public class ExplainedOutputBuilder(CostsExplainer costsExplainer)
{
    public async Task<ExplainedOutput> Build(ExplainOutput output)
    {
        return new ExplainedOutput(await BuildPlan(output.Plan));
    }

    private async Task<ExplainedPlan> BuildPlan(Plan plan)
    {
        var list = new List<ExplainedPlan>();
        foreach (var planChild in plan.Children)
        {
            list.Add(await BuildPlan(planChild));
        }

        return new ExplainedPlan(
            await BuildNode(plan.Node),
            list.ToArray()
        );
    }

    private async Task<ExplainedPlanNode> BuildNode(PlanNode node)
    {
        return new ExplainedPlanNode(
            node,
            await costsExplainer.Explain(node)
        );
    }
}