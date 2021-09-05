using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Repositories.Interfaces
{
    public interface IDepartmentRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
