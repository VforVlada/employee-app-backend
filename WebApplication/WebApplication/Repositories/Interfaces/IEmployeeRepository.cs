using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Repositories.Interfaces
{
    public interface IEmployeeRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T newEntity);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
