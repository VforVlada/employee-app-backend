using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Exceptions;
using WebApplication.Models;
using WebApplication.Repositories.Interfaces;
using WebApplication.Services.Interfaces;

namespace WebApplication.Services
{
    public class EmployeeService : IEmployeeService<Employee>
    {
        private readonly IEmployeeRepository<Employee> _repository;

        public EmployeeService(IEmployeeRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Employee entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Employee entity)
        {
            var employeesFromDB = await _repository.GetAllAsync();

            if (employeesFromDB.FirstOrDefault(el => el.ManagerId == entity.Id) != null)
            {
                throw new ManagerException("Can't delete employee if he is a manager");
            }

            await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Employee entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
