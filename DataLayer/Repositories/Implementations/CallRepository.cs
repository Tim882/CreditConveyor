using CreditConveyor.Models;
using CreditConveyor.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace CreditConveyor.DbLayer
{
    public class CallRepository : ICallRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CallRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> CreateAsync(Call entity)
        {
            string query = """
                INSERT INTO Calls (AssignmentDate, CallResult, IsProcessed) VALUES (@AssignmentDate, @CallResult, @IsProcessed)
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
            string query = "DELETE FROM Calls WHERE Id=@id";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                int result = await connection.ExecuteAsync(query, new { id });

                return result == 1;
            }
        }

        public async Task<List<Call>> GetAllAsync()
        {
            string query = "SELECT * FROM Calls";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var result = await connection.QueryAsync<Call>(query);

                return result.ToList();
            }
        }

        public async Task<Call> GetByIdAsync(Guid id)
        {
            string query = "SELECT * FROM Calls WHERE Id=@id";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var result = await connection.QuerySingleOrDefaultAsync<Call>(query, new { id });

                return result;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, Call entity)
        {
            string query = """
                UPDATE Calls SET AssignmentDate=@AssignmentDate, CallResult=@CallResult, IsProcessed=@IsProcessed WHERE Id=@id
            """;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                int result = await connection.ExecuteAsync(query, 
                    new { 
                        id, 
                        entity.AssignmentDate, 
                        entity.CallResult, 
                        entity.IsProcessed 
                    }
                );

                return result == 1;
            }
        }
    }
}
