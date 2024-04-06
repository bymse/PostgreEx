using PostgreEx.Application.Services;
using PostgreEx.Core.Output;
using PostgreEx.Infrastructure.Explain.Parser;
using PostgreEx.Infrastructure.Postgres;

namespace PostgreEx.Infrastructure.Explain;

internal class NpgsqlExplainExecutor(
    JsonExplainOutputParser jsonExplainOutputParser,
    NpgsqlQueryExecutor queryExecutor
) : IExplainExecutor
{
    public async Task<ExplainOutput> Execute(string query)
    {
        var jsonOutput = await queryExecutor.Execute<string>($"EXPLAIN (FORMAT JSON) {query}");

        if (!string.IsNullOrEmpty(jsonOutput))
        {
            return jsonExplainOutputParser.Parse(jsonOutput);
        }

        throw new InvalidOperationException("No output from EXPLAIN query");
    }
}