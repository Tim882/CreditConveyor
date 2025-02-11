using CreditConveyor.Models;
using CreditConveyor.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace CreditConveyor.DbLayer
{
    public class OperatorRepository : IOperatorRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public OperatorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> CreateAsync(Operator entity)
        {
            string query = """
                INSERT INTO Operators (Name) VALUES (@Name)
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
            string query = "DELETE FROM Operators WHERE Id=@id";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                int result = await connection.ExecuteAsync(query, new { id });

                return result == 1;
            }
        }

        public async Task<List<Operator>> GetAllAsync()
        {
            string query = "SELECT * FROM Operators";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var result = await connection.QueryAsync<Operator>(query);

                return result.ToList();
            }
        }

        public async Task<Operator> GetByIdAsync(Guid id)
        {
            string query = "SELECT * FROM Operators WHERE Id=@id";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var result = await connection.QuerySingleOrDefaultAsync<Operator>(query, new { id });

                return result;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, Operator entity)
        {
            string query = """
                UPDATE Operators SET Name=@Name WHERE Id=@id
            """;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                int result = await connection.ExecuteAsync(query, 
                    new { 
                        id, 
                        entity.Name
                    }
                );

                return result == 1;
            }
        }
    }
}
