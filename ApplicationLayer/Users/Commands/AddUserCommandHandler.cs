using Application.Common;
using Domain.Entities;
using Domain.RepositoriesInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class AddUserCommandHandler(IUserRepository userRepository) : IRequestHandler<AddUserCommand, bool>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = RequestMapper.UserCommandsToUser(request);
                return await _userRepository.Add(user, cancellationToken);
            }
            catch (Exception e)
            {
                // log
                return false;
            }

        }
    }
}
