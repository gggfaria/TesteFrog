using System.Data;
using Npgsql;

namespace TesteFrogpay.Infra;

public class DbContext
{
    private readonly string _connectionString;
    public DbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
        => new NpgsqlConnection(_connectionString);
}