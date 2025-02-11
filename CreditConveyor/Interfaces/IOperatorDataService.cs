using CreditConveyor.Models;

namespace CreditConveyor.Interfaces
{
    public interface IOperatorDataService
    {
        public Task<OperatorResponse> GetByIdAsync(Guid id);
        public Task<List<OperatorResponse>> GetAllAsync();
        public Task<bool> DeleteAsync(Guid id);
        public Task<bool> UpdateAsync(Guid id, OperatorRequest request);
        public Task<bool> CreateAsync(OperatorRequest request);
    }
}
