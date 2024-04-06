using PostgreEx.Core.Costs;

namespace PostgreEx.Core.Plans;

public class SeqScanPlan(
    string relationName,
    string alias,
    PlanCosts costs,
    Rows rows,
    int width,
    Plan[] plans
) : Plan(
    relationName,
    alias,
    costs,
    rows,
    width,
    plans
)
{
}