

using CreditConveyor.Models;
using CreditConveyor.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Npgsql;
using static Dapper.SqlMapper;

namespace CreditConveyor.DbLayer
{
    public class CreditProductRepository : ICreditProductRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CreditProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> CreateAsync(CreditProduct entity)
        {
            string query = "INSERT INTO CreditProducts (Name, Rate) VALUES (@Name, @Rate)";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                int result = await connection.ExecuteAsync(query, entity);

                return result == 1;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            string query = "DELETE FROM CreditProducts WHERE Id=@id";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                int result = await connection.ExecuteAsync(query, new { id });

                return result == 1;
            }
        }

        public async Task<List<CreditProduct>> GetAllAsync()
        {
            string query = "SELECT * FROM CreditProducts";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<CreditProduct>(query);

                return result.ToList();
            }
        }

        public async Task<CreditProduct> GetByIdAsync(Guid id)
        {
            string query = "SELECT * FROM CreditProducts WHERE Id=@id";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QuerySingleOrDefaultAsync<CreditProduct>(query, new { id });

                return result;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, CreditProduct entity)
        {
            string query = "UPDATE CreditProducts SET Name=@Name, Rate=@Rate WHERE Id=@id";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                int result = await connection.ExecuteAsync(query, new { id, entity.Name, entity.Rate });

                return result == 1;
            }
        }
    }
}
