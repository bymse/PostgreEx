using PostgreEx.Core.Costs;

namespace PostgreEx.Core.Plans.Nodes;

public class SeqScanPlanNode(string relationName, string alias,
    PlanCosts costs, Rows rows, int width
) : PlanNode(relationName, alias, costs, rows, width);