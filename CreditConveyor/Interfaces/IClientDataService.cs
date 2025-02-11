using CreditConveyor.Models;

namespace CreditConveyor.Interfaces
{
    public interface IClientDataService
    {
        public Task<ClientResponse> GetByIdAsync(Guid id);
        public Task<List<ClientResponse>> GetAllAsync();
        public Task<bool> DeleteAsync(Guid id);
        public Task<bool> UpdateAsync(Guid id, ClientRequest request);
        public Task<bool> CreateAsync(ClientRequest request);
    }
}
