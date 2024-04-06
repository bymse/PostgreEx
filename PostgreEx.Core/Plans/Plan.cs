using PostgreEx.Core.Plans.Nodes;

namespace PostgreEx.Core.Plans;

public class Plan(PlanNode planNode, Plan[] children)
{
    public PlanNode PlanNode { get; } = planNode;
    public Plan[] Children { get; } = children;
}