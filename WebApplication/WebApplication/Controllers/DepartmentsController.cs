using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Services.Interfaces;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService<Department> _service;

        public DepartmentsController(IDepartmentService<Department> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
