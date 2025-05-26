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
    public class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository = userRepository;

        async Task<User> IRequestHandler<GetUserByIdQuery, User>.Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            }
            catch (Exception)
            {
                //log
                return null;
            }
        }
    }
}
