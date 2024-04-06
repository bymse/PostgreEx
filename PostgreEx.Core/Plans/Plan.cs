using PostgreEx.Core.Plans.Nodes;

namespace PostgreEx.Core.Plans;

public class Plan(PlanNode planNode, Plan[] children)
{
    public PlanNode Node { get; } = planNode;
    public Plan[] Children { get; } = children;
}