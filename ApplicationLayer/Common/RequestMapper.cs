using Application.Orders.Commands;
using Application.Products.Commands;
using Application.Users.Commands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public static class RequestMapper
	{
		public static User UserCommandsToUser(AddUserCommand command)
		{
			return new User
			{
				FullName = command.FullName,
				Email = command.Email,
				Address = command.Address,
				PhoneNumber = command.PhoneNumber
				
			};
		}
		public static User UserCommandsToUser(UpdateUserCommand command)
		{
			return new User
			{
				Id = command.Id,
				FullName = command.FullName,
				Email = command.Email,
				Address = command.Address,
				PhoneNumber = command.PhoneNumber,
				
			};
		}

		public static Product ProductCommandsToProduct(AddProductCommand command)
		{
			return new Product
			{
				Name = command.Name,
				Price = command.Price,
				IsFragile = command.IsFragile
			};
		}

		public static Product ProductCommandsToProduct(UpdateProductCommand command)
		{
			return new Product
			{
				Id=command.Id,
				Name = command.Name,
				Price = command.Price,
				IsFragile = command.IsFragile
			};
		}

		public static Order OrderCommandsToOrder(AddOrderCommand command)
		{
			return new Order
			{
				OrderDate = command.OrderDate,
				UserId = command.UserId,
				DeliveryMethod = command.DeliveryMethod,
				TotalPrice = command.TotalPrice

			};
		}
	}
}
