using Application.Common;
using Domain.Entities;
using Domain.Enums;
using Domain.RepositoriesInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands
{
	public class AddOrderCommandHandler(IOrderRepository orderRepository,
		IOrderItemRepository orderItemRepository,
		IProductRepository productRepository) : IRequestHandler<AddOrderCommand, bool>
	{
		private readonly IOrderRepository _orderRepository = orderRepository;
		private readonly IOrderItemRepository _orderItemRepository = orderItemRepository;
		private readonly IProductRepository _productRepository = productRepository;

		public async Task<bool> Handle(AddOrderCommand request, CancellationToken cancellationToken)
		{
			try
			{
				DateTime orderTime = DateTime.Now;
				if (!_orderRepository.IsOrderTimeValidAsync(orderTime))
					throw new Exception("Allowed hours to order from 8:00 to 19:00");

				var orderItems = request.Items.Select(i => new OrderItem
				{
					ProductId = i.ProductId,
					Quantity = i.Quantity
				}).ToList();

				int totalPrice = await _orderItemRepository.CalculateTotalPriceAsync(orderItems,cancellationToken);


				if (!_orderRepository.IsOrderPriceValidAsync(totalPrice))
					throw new Exception("Price Shoud Be Above 500000RLS");

				var productIds = request.Items.Select(i => i.ProductId);
				bool hasFragile = await _productRepository.ContainsFragileItemsAsync(productIds);


				if (hasFragile && request.DeliveryMethod != DeliveryMethod.VanguardPost)
					throw new Exception("Fragile items are only allowed with VanguardPost shipping.");

				Order order = RequestMapper.OrderCommandsToOrder(request);
				order.OrderItems = orderItems;
				order.TotalPrice = totalPrice;
				order.OrderDate = orderTime;
				return await _orderRepository.Add(order, cancellationToken);
			}
			catch (Exception e)
			{

				throw e; 
			}
		}
	}
}
