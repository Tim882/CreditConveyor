using CreditConveyor.Models;

namespace CreditConveyor.Interfaces
{
    public interface ICallDataService
    {
        public Task<CallResponse> GetByIdAsync(Guid id);
        public Task<List<CallResponse>> GetAllAsync();
        public Task<bool> DeleteAsync(Guid id);
        public Task<bool> UpdateAsync(Guid id, CallRequest request);
        public Task<bool> CreateAsync(CallRequest request);
    }
}
