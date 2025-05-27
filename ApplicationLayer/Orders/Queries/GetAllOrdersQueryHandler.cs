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
	public class GetAllOrdersQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
	{
		private readonly IOrderRepository _orderRepository = orderRepository;

		public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
		{
			try
			{
				return await _orderRepository.GetAllAsync(cancellationToken);

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
