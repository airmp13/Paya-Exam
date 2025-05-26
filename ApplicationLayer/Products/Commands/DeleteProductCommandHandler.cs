using Domain.Entities;
using Domain.RepositoriesInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public class DeleteProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand, bool>
    {
		private readonly IProductRepository _productRepository = productRepository;

		public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
                if (product != null)
                {
                    return await _productRepository.Delete(product, cancellationToken);
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
