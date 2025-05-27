using Application.Orders.Commands;
using Application.Orders.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Paya_Exam.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController(IMediator mediator) : Controller
	{
		private readonly IMediator _mediator = mediator;

		[HttpPost]
		public async Task<IActionResult> Create(AddOrderCommand command)
		{
			try
			{
				if (await _mediator.Send(command))
					return Ok("Order Submitted ");

				else return Ok("Order Faild ");
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOrder(int id)
		{
			try
			{
				Order order = await _mediator.Send(new GetOrderByIdQuery() { Id = id});
				if (order == null)
					return NotFound();
				return Ok(order);
			}
			catch (Exception)
			{

				return Ok("Order Not Found!");
			}
			
		}

		[HttpGet]
		public async Task<IActionResult> GetAllOrders()
		{
			try
			{
				var orders = await _mediator.Send(new GetAllOrdersQuery());
				return Ok(orders);
			}
			catch (Exception)
			{

				return Ok("Error");
			}
			
		}
	}
}
