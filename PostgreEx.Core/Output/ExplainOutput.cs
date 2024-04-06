using PostgreEx.Core.Plans;

namespace PostgreEx.Core.Output;

public class ExplainOutput(Plan plan)
{
    public Plan Plan { get; } = plan;
}