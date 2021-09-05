using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Repositories.Interfaces;

namespace WebApplication.Repositories
{
    public class DepartmentRepository : IDepartmentRepository<Department>
    {
        private readonly TestDBContext _context;

        public DepartmentRepository(TestDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.Departments.AsNoTracking().ToListAsync();
        }
    }
}
