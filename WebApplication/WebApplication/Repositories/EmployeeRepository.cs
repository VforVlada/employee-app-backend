using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repositories.Interfaces
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        private readonly TestDBContext _context;

        public EmployeeRepository(TestDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee entity)
        {
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employees = await _context.Employees.Include(el => el.Department).AsNoTracking().ToListAsync();
            foreach (var employee in employees)
            {
                employee.Manager = await this.GetByIdAsync(employee.ManagerId.Value);
            }
            return employees;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.Include(el => el.Department).AsNoTracking().FirstOrDefaultAsync(el => el.Id == id);
            employee.Manager = await _context.Employees.FirstOrDefaultAsync(el => el.Id == employee.ManagerId);
            return employee;
        }

        public async Task UpdateAsync(Employee newEntity)
        {
            _context.Employees.Update(newEntity);
            await _context.SaveChangesAsync();
        }
    }
}
