using CreditConveyor.DbLayer;
using CreditConveyor.Interfaces;
using CreditConveyor.Models;
using CreditConveyor.Repositories.Interfaces;

namespace CreditConveyor.Services
{
    public class CreditApplicationDataService: ICreditApplicationDataService
    {
        private readonly ICreditApplicationRepository _repository;

        public CreditApplicationDataService(ICreditApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(CreditApplicationRequest creditApplicationRequest)
        {
            CreditApplication creditApplication = new CreditApplication
            {
                Id = new Guid(),
                Reason = creditApplicationRequest.Reason,
                Volume = creditApplicationRequest.Volume,
                ClientIncome = creditApplicationRequest.ClientIncome,
                CreditProductId = creditApplicationRequest.CreditProductId
            };

            bool result = await _repository.CreateAsync(creditApplication);

            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            bool result = await _repository.DeleteAsync(id);

            return result;
        }

        public async Task<List<CreditApplicationResponse>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            var response = result.Select(r => new CreditApplicationResponse
                {
                    Id = r.Id,
                    Reason = r.Reason,
                    Volume = r.Volume,
                    ClientIncome = r.ClientIncome,
                    CreditProductId = r.CreditProductId
                }
            ).ToList();

            return response;
        }

        public async Task<CreditApplicationResponse> GetByIdAsync(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);

            var response = new CreditApplicationResponse
            {
                Id = result.Id,
                Reason = result.Reason,
                Volume = result.Volume,
                ClientIncome = result.ClientIncome,
                CreditProductId = result.CreditProductId
            };

            return response;
        }

        public async Task<bool> UpdateAsync(Guid id, CreditApplicationRequest creditApplicationRequest)
        {
            CreditApplication creditApplication = new CreditApplication
            {
                Id = new Guid(),
                Reason = creditApplicationRequest.Reason,
                Volume = creditApplicationRequest.Volume,
                ClientIncome = creditApplicationRequest.ClientIncome,
                CreditProductId = creditApplicationRequest.CreditProductId
            };

            bool result = await _repository.UpdateAsync(creditApplication);

            return result;
        }
    }
}
