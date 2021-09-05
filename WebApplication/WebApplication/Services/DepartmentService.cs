using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Repositories.Interfaces;
using WebApplication.Services.Interfaces;

namespace WebApplication.Services
{
    public class DepartmentService : IDepartmentService<Department>
    {
        private readonly IDepartmentRepository<Department> _repository;

        public DepartmentService(IDepartmentRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _repository.GetAllAsync(); ;
        }
    }
}
