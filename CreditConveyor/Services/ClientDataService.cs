using CreditConveyor.DbLayer;
using CreditConveyor.Interfaces;
using CreditConveyor.Models;
using CreditConveyor.Repositories.Interfaces;

namespace CreditConveyor.Services
{
    public class ClientDataService: IClientDataService
    {
        private readonly IClientRepository _repository;

        public ClientDataService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(ClientRequest clientRequest)
        {
            Client client = new Client
            {
                Id = new Guid(),
                Name = clientRequest.Name,
                Surname = clientRequest.Surname,
                Patronymic = clientRequest.Patronymic,
                Age = clientRequest.Age,
                WorkOfPlace = clientRequest.WorkOfPlace,
                PhoneNumber = clientRequest.PhoneNumber
            };

            bool result = await _repository.CreateAsync(client);

            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            bool result = await _repository.DeleteAsync(id);

            return result;
        }

        public async Task<List<ClientResponse>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            var response = result.Select(r => new ClientResponse
                {
                    Id = r.Id,
                    Name = r.Name,
                    Surname = r.Surname,
                    Patronymic = r.Patronymic,
                    Age = r.Age,
                    WorkOfPlace = r.WorkOfPlace,
                    PhoneNumber = r.PhoneNumber
                }
            ).ToList();

            return response;
        }

        public async Task<ClientResponse> GetByIdAsync(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);

            var response = new ClientResponse
            {
                Id = result.Id,
                Name = result.Name,
                Surname = result.Surname,
                Patronymic = result.Patronymic,
                Age = result.Age,
                WorkOfPlace = result.WorkOfPlace,
                PhoneNumber = result.PhoneNumber
            };

            return response;
        }

        public async Task<bool> UpdateAsync(Guid id, ClientRequest clientRequest)
        {
            Client client = new Client
            {
                Id = new Guid(),
                Name = clientRequest.Name,
                Surname = clientRequest.Surname,
                Patronymic = clientRequest.Patronymic,
                Age = clientRequest.Age,
                WorkOfPlace = clientRequest.WorkOfPlace,
                PhoneNumber = clientRequest.PhoneNumber
            };

            bool result = await _repository.UpdateAsync(client);

            return result;
        }
    }
}
