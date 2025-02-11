


using CreditConveyor.Models;
using CreditConveyor.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace CreditConveyor.DbLayer
{
    public class ClientRepository : IClientRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ClientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> CreateAsync(Client entity)
        {
            string query = """
                INSERT INTO Clients (Name, Surname, Patronymic, Age, WorkOfPlace, PhoneNumber) 
                VALUES (@Name, @Surname, @Patronymic, @Age, @WorkOfPlace, @PhoneNumber)
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
            string query = "DELETE FROM Clients WHERE Id=@id";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                int result = await connection.ExecuteAsync(query, new { id });

                return result == 1;
            }
        }

        public async Task<List<Client>> GetAllAsync()
        {
            string query = "SELECT * FROM Clients";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var result = await connection.QueryAsync<Client>(query);

                return result.ToList();
            }
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            string query = "SELECT * FROM Clients WHERE Id=@id";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var result = await connection.QuerySingleOrDefaultAsync<Client>(query, new { id });

                return result;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, Client entity)
        {
            string query = """
                UPDATE Clients SET Name=@Name, Surname=@Surname, Patronymic=@Patronymic, 
                Age=@Age, WorkOfPlace=@WorkOfPlace, PhoneNumber=@PhoneNumber
            """;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                int result = await connection.ExecuteAsync(query, 
                    new 
                    { 
                        id, 
                        entity.Name, 
                        entity.Surname, 
                        entity.Patronymic, 
                        entity.Age ,
                        entity.WorkOfPlace,
                        entity.PhoneNumber
                    }
                );

                return result == 1;
            }
        }
    }
}
