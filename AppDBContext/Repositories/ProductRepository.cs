using ApplicationDBContext;
using Domain.Entities;
using Domain.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository(AppDBContext appDBContext) : GenericRepository<Product>(appDBContext) , IProductRepository
    {
        private readonly AppDBContext _appDBContext = appDBContext;


        
    }
}
