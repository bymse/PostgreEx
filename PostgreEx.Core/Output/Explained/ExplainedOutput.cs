namespace PostgreEx.Core.Output.Explained;

public class ExplainedOutput(ExplainedPlanNode planNode)
{
    public ExplainedPlanNode PlanNode { get; } = planNode;
}