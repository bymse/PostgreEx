using PostgreEx.Core.Statistics;

namespace PostgreEx.Infrastructure.Postgres;

internal class NpgsqlRelationStatistics(NpgsqlQueryExecutor queryExecutor) : IRelationStatistics
{
    public async Task<RelPages> GetRelPages(string relationName)
    {
        var relPages = await queryExecutor
            .Execute<int?>("select relpages from pg_class where relname = $1", relationName);

        return new RelPages(relPages!.Value);
    }

    public async Task<RelTuples> GetRelTuples(string relationName)
    {
        var count = await queryExecutor
            .Execute<int?>("select reltuples from pg_class where relname = $1", relationName);

        return new RelTuples(relationName, count!.Value);
    }
}