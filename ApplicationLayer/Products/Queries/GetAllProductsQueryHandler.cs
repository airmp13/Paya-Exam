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
	public class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
	{
		private readonly IProductRepository _productRepository = productRepository;

		public Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			try
			{
				return _productRepository.GetAllAsync(cancellationToken);
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
