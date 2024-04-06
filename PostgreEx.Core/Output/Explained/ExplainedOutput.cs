namespace PostgreEx.Core.Output.Explained;

public class ExplainedOutput(ExplainedPlan plan)
{
    public ExplainedPlan Plan { get; } = plan;
}