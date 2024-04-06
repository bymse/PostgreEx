using PostgreEx.Core.Plans.Costs;

namespace PostgreEx.Core.Plans.Nodes;

public abstract class PlanNode(
    string relationName,
    string alias,
    PlanCosts costs,
    Rows rows,
    int width
)
{
    public PlanCosts Costs { get; } = costs;

    public string RelationName { get; } = relationName;
    public string Alias { get; } = alias;

    public Rows Rows { get; } = rows;
    public int Width { get; } = width;
}