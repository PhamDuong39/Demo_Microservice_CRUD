using Product.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Contract
{
    public interface IServiceGeneric<T>
    {
        Task<ApiResponse<T>> GetAllAsync();
        Task<ApiResponse<T>> AddAsync(T entity);
        Task<ApiResponse<T>> UpdateAsync(T entity);
        Task<ApiResponse<T>> DeleteAsync(int Id);
        Task<ApiResponse<T>> GetByIdAsync(int Id);
    }
}
