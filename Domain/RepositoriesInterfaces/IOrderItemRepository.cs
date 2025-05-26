using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoriesInterfaces
{
	public interface IOrderItemRepository : IGenericRepository<OrderItem>
	{
		Task<int> CalculateTotalPriceAsync(IEnumerable<OrderItem> orderItems, CancellationToken cancellationToken);
	}
}
