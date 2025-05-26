using Application.Common;
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
    public class AddProductCommandHandler(IProductRepository productRepository) : IRequestHandler<AddProductCommand, bool>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = RequestMapper.ProductCommandsToProduct(request);
                return await _productRepository.Add(product, cancellationToken);
            }
            catch (Exception e)
            {
                // log
                return false;
            }

        }
    }
}
