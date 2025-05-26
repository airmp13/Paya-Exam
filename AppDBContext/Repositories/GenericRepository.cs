using ApplicationDBContext;
using Domain.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T>(AppDBContext appDBContext) : IGenericRepository<T> where T : class
    {
        private readonly AppDBContext _appDBContext = appDBContext;
        private readonly DbSet<T> _dbSet = appDBContext.Set<T>();

        public async Task<bool> Add(T entity, CancellationToken cancellationToken)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return await _appDBContext.SaveChangesAsync(cancellationToken) > 0 ? true : false;

            }
            catch (Exception e)
            {
                // log
                return false;
            }
        }

        public async Task<bool> Update(T entity, CancellationToken cancellationToken)
        {
            try
            {
                _dbSet.Update(entity);
                return await _appDBContext.SaveChangesAsync(cancellationToken) > 0 ? true : false;
            }
            catch (Exception e)
            {
                // log
                return false;
            }
        }

        public async Task<bool> Delete(T entity, CancellationToken cancellationToken)
        {
            try
            {
                _dbSet.Remove(entity);
                return await _appDBContext.SaveChangesAsync(cancellationToken) > 0 ? true : false;

            }
            catch (Exception e)
            {
                // log
                return false;
            }

        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _dbSet.ToListAsync(cancellationToken);

            }
            catch (Exception e)
            {
                // log
                return null;
            }
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _dbSet.FindAsync(id,cancellationToken);
            }
            catch (Exception e)
            {
                // log
                return null;
            }
        }

        
    }
}
