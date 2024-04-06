using PostgreEx.Application.Services;
using PostgreEx.Core.Output.Explained;

namespace PostgreEx.Application.Output;

public class ExplainedOutputHandler(IExplainExecutor executor, ExplainedOutputBuilder explainedOutputBuilder)
{
    public async Task<ExplainedOutput> Handle(string query)
    {
        var output = await executor.Execute(query);
        return await explainedOutputBuilder.Build(output);
    }
}