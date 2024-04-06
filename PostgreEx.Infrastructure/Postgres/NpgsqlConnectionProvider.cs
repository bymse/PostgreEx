using System.Data;
using Npgsql;

namespace PostgreEx.Infrastructure.Postgres;

internal class NpgsqlConnectionProvider : IDisposable, IAsyncDisposable
{
    private readonly NpgsqlConnection connection;
    
    public NpgsqlConnectionProvider(string connectionString)
    {
        connection = new NpgsqlConnection();
    }
    
    public async Task<NpgsqlConnection> Get()
    {
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        return connection;
    }

    public void Dispose()
    {
        connection.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await connection.DisposeAsync();
    }
}