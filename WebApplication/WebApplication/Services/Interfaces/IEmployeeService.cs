using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Services.Interfaces
{
    public interface IEmployeeService<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
