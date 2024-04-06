using Microsoft.Extensions.DependencyInjection;
using PostgreEx.Application.Output;
using PostgreEx.Application.Services;
using PostgreEx.Core.Explanation.Costs;
using PostgreEx.Core.Output.Explained;
using PostgreEx.Core.Settings;
using PostgreEx.Core.Statistics;
using PostgreEx.Infrastructure.Explain;
using PostgreEx.Infrastructure.Explain.Parser;
using PostgreEx.Infrastructure.Postgres;

namespace PostgreEx.Infrastructure.DI;

public static class ServicesRegistration
{
    public static void AddServices(IServiceCollection collection, string connectionString)
    {
        AddCore(collection);
        AddApplication(collection);
        AddInfrastructure(collection, connectionString);
    }

    private static void AddCore(IServiceCollection collection)
    {
        collection.AddSingleton<ICostSettingsProvider, NpgsqlCostSettingsProvider>();
        collection.AddSingleton<IRelationStatistics, NpgsqlRelationStatistics>();
        collection.AddSingleton<CostsExplainer>();
        collection.AddSingleton<ExplainedOutputBuilder>();
    }
    
    private static void AddApplication(IServiceCollection collection)
    {
        collection.AddSingleton<IExplainExecutor, NpgsqlExplainExecutor>();
        collection.AddSingleton<ExplainedOutputHandler>();
    }
    
    private static void AddInfrastructure(IServiceCollection collection, string connectionString)
    {
        collection.AddSingleton(new NpgsqlConnectionProvider(connectionString));
        collection.AddSingleton<JsonExplainOutputParser>();
        collection.AddSingleton<NpgsqlCostSettingsProvider>();
        collection.AddSingleton<NpgsqlQueryExecutor>();
    }
}