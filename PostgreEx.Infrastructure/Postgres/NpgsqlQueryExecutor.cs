using Npgsql;

namespace PostgreEx.Infrastructure.Postgres;

internal class NpgsqlQueryExecutor(NpgsqlConnectionProvider connectionProvider)
{
    public async Task<T?> Execute<T>(string query, params object[] parameters)
    {
        var command = await GetCommand(query, parameters);
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return await reader.GetFieldValueAsync<T>(0);
        }

        return default;
    }

    public async Task<Tuple<T1, T2>?> Execute<T1, T2>(string query, params object[] parameters)
    {
        var command = await GetCommand(query, parameters);
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Tuple<T1, T2>(
                await reader.GetFieldValueAsync<T1>(0),
                await reader.GetFieldValueAsync<T2>(1)
            );
        }

        return null;
    }

    private async Task<NpgsqlCommand> GetCommand(string query, object[] parameters)
    {
        var connection = await connectionProvider.Get();
        var command = connection.CreateCommand();
        command.CommandText = query;

        foreach (var parameter in parameters)
        {
            command.Parameters.Add(parameter);
        }

        return command;
    }
}