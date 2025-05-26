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
    public class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
                if (user != null)
                {
                    return await _userRepository.Delete(user, cancellationToken);
                }
                else return false;
            }
            catch (Exception)
            {
                //log
                return false;
            }
        }
    }
}
