using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.Exceptions;
using WebApplication.Models;
using WebApplication.Services.Interfaces;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService<Employee> _service;

        public EmployeesController(IEmployeeService<Employee> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Employee entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetAsync), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Employee entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            var oldEntity = await _service.GetByIdAsync(id);

            if (oldEntity == null)
            {
                return NotFound();
            }

            await _service.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var employee = await _service.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            try
            {
                await _service.DeleteAsync(employee);
            }
            catch (ManagerException exception)
            {
                return BadRequest(exception.Message);
            }

            return NoContent();
        }
    }
}
