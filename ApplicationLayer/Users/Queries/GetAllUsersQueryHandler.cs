using Domain.Entities;
using Domain.RepositoriesInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
	public class GetAllUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
	{
		private readonly IUserRepository _userRepository = userRepository;

		public Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
		{
			try
			{
				return _userRepository.GetAllAsync(cancellationToken);
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
