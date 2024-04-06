using PostgreEx.Core.Settings;

namespace PostgreEx.Infrastructure.Postgres;

internal class NpgsqlCostSettingsProvider(NpgsqlQueryExecutor queryExecutor) : ICostSettingsProvider
{
    public async Task<ICostSettings> GetSettings()
    {
        var (seqPageCost, cpuTupleCost) = (await queryExecutor
                .Execute<double, double>("select current_setting('seq_page_cost'), current_setting('cpu_tuple_cost')")
            )!;

        return new CostSettings(
            new(seqPageCost),
            new(cpuTupleCost)
        );
    }
}