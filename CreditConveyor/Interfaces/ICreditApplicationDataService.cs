using CreditConveyor.Models;

namespace CreditConveyor.Interfaces
{
    public interface ICreditApplicationDataService
    {
        public Task<CreditApplicationResponse> GetByIdAsync(Guid id);
        public Task<List<CreditApplicationResponse>> GetAllAsync();
        public Task<bool> DeleteAsync(Guid id);
        public Task<bool> UpdateAsync(Guid id, CreditApplicationRequest request);
        public Task<bool> CreateAsync(CreditApplicationRequest request);
    }
}
