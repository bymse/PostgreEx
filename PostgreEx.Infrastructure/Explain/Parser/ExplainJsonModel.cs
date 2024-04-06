using Newtonsoft.Json;

namespace PostgreEx.Infrastructure.Explain.Parser;

public class ExplainJsonModel
{
    [JsonProperty("Plan")]
    public ExplainPlanJsonModel Plan { get; set; }
}

public class ExplainPlanJsonModel
{
    [JsonProperty("Node Type")]
    public string NodeType { get; set; }

    [JsonProperty("Relation Name")]
    public string RelationName { get; set; }

    [JsonProperty("Alias")]
    public string Alias { get; set; }

    [JsonProperty("Startup Cost")]
    public double StartupCost { get; set; }

    [JsonProperty("Total Cost")]
    public double TotalCost { get; set; }

    [JsonProperty("Plan Rows")]
    public int PlanRows { get; set; }

    [JsonProperty("Plan Width")]
    public int PlanWidth { get; set; }

    [JsonProperty("Filter")]
    public string? Filter { get; set; }

    [JsonProperty("Rows Removed by Filter")]
    public double? RowsRemovedByFilter { get; set; }

    [JsonProperty("Shared Hit Blocks")]
    public double? SharedHitBlocks { get; set; }

    [JsonProperty("Shared Read Blocks")]
    public double? SharedReadBlocks { get; set; }

    [JsonProperty("Shared Dirtied Blocks")]
    public double? SharedDirtiedBlocks { get; set; }

    [JsonProperty("Shared Written Blocks")]
    public double? SharedWrittenBlocks { get; set; }

    [JsonProperty("Local Hit Blocks")]
    public double? LocalHitBlocks { get; set; }

    [JsonProperty("Local Read Blocks")]
    public double? LocalReadBlocks { get; set; }

    [JsonProperty("Local Dirtied Blocks")]
    public double? LocalDirtiedBlocks { get; set; }

    [JsonProperty("Local Written Blocks")]
    public double? LocalWrittenBlocks { get; set; }

    [JsonProperty("Temp Read Blocks")]
    public double? TempReadBlocks { get; set; }

    [JsonProperty("Temp Written Blocks")]
    public double? TempWrittenBlocks { get; set; }

    [JsonProperty("I/O Read Time")]
    public double? IoReadTime { get; set; }

    [JsonProperty("I/O Write Time")]
    public double? IoWriteTime { get; set; }
    
    [JsonProperty("Plans")]
    public List<ExplainPlanJsonModel> Plans { get; set; }
}