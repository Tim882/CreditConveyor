using CreditConveyor.DbLayer;
using CreditConveyor.Interfaces;
using CreditConveyor.Models;
using CreditConveyor.Repositories.Interfaces;

namespace CreditConveyor.Services
{
    public class CreditProductDataService: ICreditProductDataService
    {
        private readonly ICreditProductRepository _repository;

        public CreditProductDataService(ICreditProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(CreditProductRequest creditProductRequest)
        {
            CreditProduct creditProduct = new CreditProduct
            {
                Id = new Guid(),
                Name = creditProductRequest.Name,
                Rate = creditProductRequest.Rate
            };

            bool result = await _repository.CreateAsync(creditProduct);

            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            bool result = await _repository.DeleteAsync(id);

            return result;
        }

        public async Task<List<CreditProductResponse>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            var response = result.Select(r => new CreditProductResponse
            {
                Id = r.Id,
                Name = r.Name,
                Rate = r.Rate
            }
            ).ToList();

            return response;
        }

        public async Task<CreditProductResponse> GetByIdAsync(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);

            var response = new CreditProductResponse
            {
                Id = result.Id,
                Name = result.Name,
                Rate = result.Rate
            };

            return response;
        }

        public async Task<bool> UpdateAsync(Guid id, CreditProductRequest creditProductRequest)
        {
            CreditProduct creditProduct = new CreditProduct
            {
                Id = new Guid(),
                Name = creditProductRequest.Name,
                Rate = creditProductRequest.Rate
            };

            bool result = await _repository.UpdateAsync(creditProduct);

            return result;
        }
    }
}
