


using CreditConveyor.Models;
using CreditConveyor.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace CreditConveyor.DbLayer
{
    public class CreditApplicationRepository : ICreditApplicationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CreditApplicationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> CreateAsync(CreditApplication entity)
        {
            string query = """
                INSERT INTO CreditApplications (Reason, Volume, ClientIncome, CreditProductId) 
                VALUES (@Reason, @Volume, @ClientIncome, @CreditProductIds)
            """;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                int result = await connection.ExecuteAsync(query, entity);

                return result == 1;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            string query = "DELETE FROM CreditApplications WHERE Id=@id";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                int result = await connection.ExecuteAsync(query, new { id });

                return result == 1;
            }
        }

        public async Task<List<CreditApplication>> GetAllAsync()
        {
            string query = "SELECT * FROM CreditApplications";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var result = await connection.QueryAsync<CreditApplication>(query);

                return result.ToList();
            }
        }

        public async Task<CreditApplication> GetByIdAsync(Guid id)
        {
            string query = "SELECT * FROM CreditApplications WHERE Id=@id";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var result = await connection.QuerySingleOrDefaultAsync<CreditApplication>(query, new { id });

                return result;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, CreditApplication entity)
        {
            string query = """
                UPDATE CreditApplications SET Reason=@Reason, Volume=@Volume, 
                ClientIncome=@ClientIncome, CreditProductId=@CreditProductId WHERE Id=@id
            """;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                int result = await connection.ExecuteAsync(query, 
                    new 
                    { 
                        id, 
                        entity.Reason,
                        entity.Volume,
                        entity.ClientIncome,
                        entity.CreditProductId
                    }
                );

                return result == 1;
            }
        }
    }
}
