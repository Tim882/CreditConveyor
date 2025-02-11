using CreditConveyor.DbLayer;
using CreditConveyor.Models;
using CreditConveyor.Interfaces;
using CreditConveyor.Repositories.Interfaces;
using CreditConveyor.Models.Enums;

namespace CreditConveyor.Services
{
    public class OperatorDataService: IOperatorDataService
    {
        private readonly IOperatorRepository _repository;
        public OperatorDataService(IOperatorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(OperatorRequest operatorRequest)
        {
            Operator callOperator = new Operator
            {
                Id = new Guid(),
                Name = operatorRequest.Name
            };

            bool result = await _repository.CreateAsync(callOperator);

            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            bool result = await _repository.DeleteAsync(id);

            return result;
        }

        public async Task<List<OperatorResponse>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            var response = result.Select(r => new OperatorResponse 
                {
                    Id = r.Id,
                    Name = r.Name
                }
            ).ToList();

            return response;
        }

        public async Task<OperatorResponse> GetByIdAsync(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);

            var response = new OperatorResponse
            {
                Id = result.Id,
                Name = result.Name
            };

            return response;
        }

        public async Task<bool> UpdateAsync(Guid id, OperatorRequest OperatorRequest)
        {
            Operator Operator = new Operator
            {
                Id = new Guid(),
                Name = OperatorRequest.Name
            };

            bool result = await _repository.UpdateAsync(Operator);

            return result;
        }
    }
}
