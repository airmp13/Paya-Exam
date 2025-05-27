using ApplicationDBContext;
using Domain.Entities;
using Domain.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository(AppDBContext appDBContext) : GenericRepository<Product>(appDBContext) , IProductRepository
    {
        private readonly AppDBContext _appDBContext = appDBContext;

		public async Task<bool> ContainsFragileItemsAsync(IEnumerable<int> productIds)
		{
			try
			{
				return await _appDBContext.Products.AsNoTracking()
				.Where(p => productIds.Contains(p.Id))
				.AnyAsync(p => p.IsFragile);
			}
			catch (Exception e)
			{

				throw e;
			}
		}
	}
}
