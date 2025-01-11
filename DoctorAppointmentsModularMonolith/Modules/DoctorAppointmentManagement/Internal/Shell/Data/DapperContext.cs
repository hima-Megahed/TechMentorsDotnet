using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DoctorAppointmentManagement.Internal.Shell.Data;
public class DapperContext
{

    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {

        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public IDbConnection CreateConnection()
        => new SqliteConnection(_connectionString);
}