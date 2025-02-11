using CreditConveyor.Interfaces;
using CreditConveyor.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditConveyor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditApplicationController : ControllerBase
    {
        private readonly ILogger<CreditApplicationController> _logger;
        private readonly ICreditApplicationDataService _dataService;

        public CreditApplicationController(ICreditApplicationDataService dataService, ILogger<CreditApplicationController> logger)
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
                CreditApplicationResponse result = await _dataService.GetByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreditApplicationRequest entity)
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
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CreditApplicationRequest entity)
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
