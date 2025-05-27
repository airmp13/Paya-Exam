using Domain.Entities;
using Domain.RepositoriesInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries
{
	public class GetOrderByIdQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrderByIdQuery, Order>
	{
		private readonly IOrderRepository _orderRepository = orderRepository;

		async Task<Order> IRequestHandler<GetOrderByIdQuery, Order>.Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
				return await _orderRepository.GetOrderWithDetailsAsync(request.Id,cancellationToken);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
