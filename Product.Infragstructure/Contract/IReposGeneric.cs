using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infragstructure.Contract
{
    public interface IReposGeneric<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int Id);
        Task<T> GetByIdAsync(int Id);
    }
}
