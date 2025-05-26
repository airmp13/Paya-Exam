using ApplicationDBContext;
using Domain.Entities;
using Domain.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository(AppDBContext appDBContext) : GenericRepository<User>(appDBContext),IUserRepository 
    {
        private readonly AppDBContext _appDBContext = appDBContext;

        public async Task<User> GetUserWithOrdersAsync(int userId)
        {
            try
            {
                return await _appDBContext.Users.Include(u => u.Orders).FirstOrDefaultAsync(u => u.Id == userId);
            }
            catch (Exception e)
            {
                // log
                return null;
            }
        }
    }
}
