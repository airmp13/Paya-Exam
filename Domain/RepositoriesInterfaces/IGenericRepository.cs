using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.RepositoriesInterfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<bool> Add(T entity,CancellationToken cancellationToken);

        Task<bool> Update(T entity, CancellationToken cancellationToken);

        Task<bool> Delete(T entity, CancellationToken cancellationToken);
    }
}
