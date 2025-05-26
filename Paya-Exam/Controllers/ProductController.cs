using Application.Products.Commands;
using Application.Products.Queries;
using Application.Users.Commands;
using Application.Users.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Paya_Exam.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController(IMediator mediator) : Controller
	{
		private readonly IMediator _mediator = mediator;


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			GetAllProductsQuery query = new GetAllProductsQuery();
			IEnumerable<Product> products = await _mediator.Send(query);
			return products != null ? Ok(products) : Ok("Zero product");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			GetProductByIdQuery query = new GetProductByIdQuery() { Id = id };
			Product product = await _mediator.Send(query);
			return product != null ? Ok(product) : Ok("product Not Found");
		}

		[HttpPost]
		public async Task<IActionResult> Create(AddProductCommand  addProductCommand, CancellationToken cancellationToken)
		{

			if (await _mediator.Send(addProductCommand, cancellationToken))
			{
				return Ok("Creat Product Successfully");
			}
			else return Ok("Creat Product Error!");
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateProductCommand updateProductCommand , CancellationToken cancellationToken)
		{
			if (await _mediator.Send(updateProductCommand, cancellationToken))
			{
				return Ok("Update Product Successfully");
			}
			else
				return Ok("Update Product Error!");
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int userid)
		{
			DeleteProductCommand command = new DeleteProductCommand() { Id = userid };
			if (await _mediator.Send(command))
			{
				return Ok("Delete Product Successfully");
			}
			else return Ok("Delete Product Error");
		}
	}
}
