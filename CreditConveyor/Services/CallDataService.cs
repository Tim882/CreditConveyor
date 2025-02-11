using CreditConveyor.DbLayer;
using CreditConveyor.Models;
using CreditConveyor.Interfaces;
using CreditConveyor.Repositories.Interfaces;
using CreditConveyor.Models.Enums;

namespace CreditConveyor.Services
{
    public class CallDataService: ICallDataService
    {
        private readonly ICallRepository _repository;
        public CallDataService(ICallRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(CallRequest callRequest)
        {
            Call call = new Call
            {
                Id = new Guid(),
                AssignmentDate = callRequest.AssignmentDate,
                CallResult = callRequest.CallResult,
                IsProcessed = callRequest.IsProcessed
            };

            bool result = await _repository.CreateAsync(call);

            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            bool result = await _repository.DeleteAsync(id);

            return result;
        }

        public async Task<List<CallResponse>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            var response = result.Select(r => new CallResponse 
                {
                    Id = r.Id,
                    AssignmentDate = r.AssignmentDate, 
                    CallResult = r.CallResult,
                    IsProcessed = r.IsProcessed 
                }
            ).ToList();

            return response;
        }

        public async Task<CallResponse> GetByIdAsync(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);

            var response = new CallResponse
            {
                Id = result.Id,
                AssignmentDate = result.AssignmentDate, 
                CallResult = result.CallResult,
                IsProcessed = result.IsProcessed
            };

            return response;
        }

        public async Task<bool> UpdateAsync(Guid id, CallRequest callRequest)
        {
            Call call = new Call
            {
                Id = new Guid(),
                AssignmentDate = callRequest.AssignmentDate,
                CallResult = callRequest.CallResult,
                IsProcessed = callRequest.IsProcessed
            };

            bool result = await _repository.UpdateAsync(call);

            return result;
        }
    }
}
