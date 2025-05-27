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
	public class OrderItemRepository(AppDBContext appDBContext) : GenericRepository<OrderItem>(appDBContext), IOrderItemRepository
	{
		private readonly AppDBContext _appDBContext = appDBContext;

		public async Task<int> CalculateTotalPriceAsync(IEnumerable<OrderItem> orderItems, CancellationToken cancellationToken)
		{
			try
			{
				var productIds = orderItems.Select(i => i.ProductId).ToList();
				var products = await _appDBContext.Products.AsNoTracking()
					.Where(p => productIds.Contains(p.Id))
					.ToListAsync(cancellationToken);

				return orderItems.Sum(item =>
				{
					var product = products.First(p => p.Id == item.ProductId);
					return product.Price * item.Quantity;
				});
			}
			catch (Exception e)
			{

				throw e;
			}
			
		}
	}
}
