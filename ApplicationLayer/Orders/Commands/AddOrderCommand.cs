using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands
{
	public class AddOrderCommand : IRequest<bool>
	{
		[Required]
		public int UserId { get; set; }

		[Required]
		public DateTime OrderDate { get; set; }

		[Required]
		public DeliveryMethod DeliveryMethod { get; set; }

		public int TotalPrice { get; set; }

		public List<OrderItemDto> Items { get; set; }

	}

	public class OrderItemDto
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }
	}
}
