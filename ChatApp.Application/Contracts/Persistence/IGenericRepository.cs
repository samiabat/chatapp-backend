using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> Get(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<int> Add(T entity);
        Task<bool> Exists(int id);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
