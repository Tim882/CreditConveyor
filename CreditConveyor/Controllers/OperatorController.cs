using CreditConveyor.Interfaces;
using CreditConveyor.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditConveyor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallController: ControllerBase
    {
        private readonly ILogger<CallController> _logger;
        private readonly ICallDataService _dataService;

        public CallController(ICallDataService dataService, ILogger<CallController> logger)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _dataService.GetAllAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                CallResponse result = await _dataService.GetByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CallRequest entity)
        {
            try
            {
                bool result = await _dataService.CreateAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CallRequest entity)
        {
            try
            {
                bool result = await _dataService.UpdateAsync(id, entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                bool result = await _dataService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
