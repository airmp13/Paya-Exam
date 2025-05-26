using Domain.Entities;
using Domain.RepositoriesInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Product>
    {
		private readonly IProductRepository _productRepository = productRepository;

		async Task<Product> IRequestHandler<GetProductByIdQuery, Product>.Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            }
            catch (Exception)
            {
                //log
                return null;
            }
        }
    }
}
