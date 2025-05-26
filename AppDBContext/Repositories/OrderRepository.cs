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
    public class OrderRepository(AppDBContext appDBContext) : GenericRepository<Order>(appDBContext), IOrderRepository
    {
        private readonly AppDBContext _appDBContext = appDBContext;

        private const int MinOrderPrice = 500000;
        public async Task<Order> GetOrderWithDetailsAsync(int id)
        {
            try
            {
                return await _appDBContext.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefaultAsync(o => o.Id == id);
            }
            catch (Exception e)
            {

                //log
                return null;
            }
        }

        public bool IsOrderPriceValidAsync(int totalPrice)
        {
            return  (totalPrice >= MinOrderPrice);
        }

        public bool IsOrderTimeValidAsync(DateTime orderTime)
        {
            return orderTime.TimeOfDay < new TimeSpan(19, 0, 0) && orderTime.TimeOfDay > new TimeSpan(8,0,0);
        }
    }
}
