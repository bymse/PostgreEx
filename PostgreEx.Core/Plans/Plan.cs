using PostgreEx.Core.Costs;

namespace PostgreEx.Core.Plans;

public abstract class Plan(
    string relationName,
    string alias,
    PlanCosts costs,
    Rows rows,
    int width,
    Plan[] plans)
{
    public PlanCosts Costs { get; } = costs;

    public string RelationName { get; } = relationName;
    public string Alias { get; } = alias;

    public Rows Rows { get; } = rows;
    public int Width { get; } = width;

    public Plan[] Plans { get; } = plans;
}