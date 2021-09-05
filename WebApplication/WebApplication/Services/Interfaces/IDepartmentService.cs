using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Services.Interfaces
{
    public interface IDepartmentService<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
