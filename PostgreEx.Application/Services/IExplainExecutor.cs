using PostgreEx.Core.Output;

namespace PostgreEx.Application.Services;

public interface IExplainExecutor
{
    Task<ExplainOutput> Execute(string query);
}