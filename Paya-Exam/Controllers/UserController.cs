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
	public class UserController(IMediator mediator) : Controller
	{
		private readonly IMediator _mediator = mediator;

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			GetAllUsersQuery query = new GetAllUsersQuery();
			IEnumerable<User> users = await _mediator.Send(query);
			return users != null ? Ok(users) : Ok("Zero User");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			GetUserByIdQuery query = new GetUserByIdQuery() { Id = id };
			User user = await _mediator.Send(query);
			return user != null ? Ok(user) : Ok("User Not Found");
		}

		[HttpPost]
		public async Task<IActionResult> Create(AddUserCommand addUserCommand,CancellationToken cancellationToken)
		{

			if (await _mediator.Send(addUserCommand, cancellationToken))
			{
				return Ok("Creat User Successfully");
			}
			else return Ok("Creat User Error!");
		}

		[HttpPut]
		public async Task<IActionResult> Update( UpdateUserCommand updateUserCommand ,CancellationToken cancellationToken)
		{
			if(await _mediator.Send(updateUserCommand, cancellationToken))
			{
				return Ok("Update User Successfully");
			}
			else
				return Ok("Update User Error!");
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int userid)
		{
			DeleteUserCommand command = new DeleteUserCommand() {Id = userid };
			if (await _mediator.Send(command))
			{
				return Ok("Delete User Successfully");
			}
			else return Ok("Delete User Error");
		}
	}
}
