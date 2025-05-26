using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoriesInterfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        bool IsOrderTimeValidAsync(DateTime orderTime);
        bool IsOrderPriceValidAsync(int totalPrice);
        Task<Order> GetOrderWithDetailsAsync(int id, CancellationToken cancellationToken);
    }
}
