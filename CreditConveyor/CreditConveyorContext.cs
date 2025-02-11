using Microsoft.Data.SqlClient;
using System.Data;


namespace CreditConveyor
{
    public class CreditConveyorContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connection;

        public CreditConveyorContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connection);
    }
}
