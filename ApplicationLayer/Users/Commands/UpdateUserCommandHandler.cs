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
    public class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = RequestMapper.UserCommandsToUser(request);
                return await _userRepository.Update(user, cancellationToken);
            }
            catch (Exception)
            {
                //log
                return false;
            }
        }
    }
}
