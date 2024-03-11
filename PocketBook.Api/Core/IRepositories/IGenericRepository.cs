using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketBook.Api.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Get all enties
        Task<IEnumerable<T>> GetAll();

        //Get specific entity based on Id
        Task<T> GetById(Guid id);

        Task<bool> Add(T entity);

        Task<bool> Delete(Guid id);

        // Update entity or add if it does not exist
        Task<bool> Upsert(T entity);

    }
}