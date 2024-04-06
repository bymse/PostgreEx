namespace PostgreEx.Core.Output.Explained;

public class ExplainedPlan(ExplainedPlanNode planNode, ExplainedPlan[] children)
{
    public ExplainedPlanNode PlanNode { get; } = planNode;
    public ExplainedPlan[] Children { get; } = children;
}