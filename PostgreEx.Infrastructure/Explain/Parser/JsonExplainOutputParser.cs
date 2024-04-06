using Newtonsoft.Json;
using PostgreEx.Core.Output;
using PostgreEx.Core.Plans;
using PostgreEx.Core.Plans.Costs;
using PostgreEx.Core.Plans.Nodes;

namespace PostgreEx.Infrastructure.Explain.Parser;

internal class JsonExplainOutputParser
{
    public ExplainOutput Parse(string jsonOutput)
    {
        var items = JsonConvert.DeserializeObject<ExplainJsonModel[]>(jsonOutput)!;
        var model = items.First();

        return new ExplainOutput(MapPlan(model.Plan));
    }

    private static Plan MapPlan(ExplainPlanJsonModel model)
    {
        return new Plan(
            MapNode(model),
            model.Plans
                .Select(MapPlan)
                .ToArray()
        );
    }

    private static PlanNode MapNode(ExplainPlanJsonModel model)
    {
        if (model.NodeType == "Seq Scan")
        {
            return new SeqScanPlanNode(
                model.RelationName,
                model.Alias,
                new PlanCosts(model.StartupCost, model.TotalCost),
                new Rows(model.PlanRows),
                model.PlanWidth
            );
        }

        throw new InvalidOperationException("Unknown node type");
    }
}