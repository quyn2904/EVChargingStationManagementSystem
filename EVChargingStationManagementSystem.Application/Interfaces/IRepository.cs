using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVChargingStationManagementSystem.Application.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetAllAsync();

        Task<T?> GetByIdAsync(Guid id);

        Task<T> CreateAsync(T entity);

        Task<T?> UpdateAsync(Guid id, T entity);

        Task<T?> DeleteAsync(Guid id);
    }
}
