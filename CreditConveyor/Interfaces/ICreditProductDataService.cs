using CreditConveyor.Models;

namespace CreditConveyor.Interfaces
{
    public interface ICreditProductDataService
    {
        public Task<CreditProductResponse> GetByIdAsync(Guid id);
        public Task<List<CreditProductResponse>> GetAllAsync();
        public Task<bool> DeleteAsync(Guid id);
        public Task<bool> UpdateAsync(Guid id, CreditProductRequest request);
        public Task<bool> CreateAsync(CreditProductRequest request);
    }
}
