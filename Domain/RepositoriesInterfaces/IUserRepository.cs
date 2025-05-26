using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoriesInterfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserWithOrdersAsync(int userId);

    }
}
