using PostgreEx.Core.Plans;

namespace PostgreEx.Core;

public class ExplainOutput(Plan plan)
{
    public Plan Plan { get; } = plan;
}