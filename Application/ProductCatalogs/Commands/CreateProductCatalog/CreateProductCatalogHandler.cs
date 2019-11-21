using Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductCatalogs.Commands.CreateProductCatalog
{
    public class CreateProductCatalogHandler : IRequestHandler<CreateProductCatalogCommand, int>
    {
        private readonly IProductCatalogRepository _productCatalogRepository;
        private readonly IMediator _mediator;

        public CreateProductCatalogHandler(IProductCatalogRepository productCatalogRepository, IMediator mediator)
        {
            _productCatalogRepository = productCatalogRepository;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateProductCatalogCommand request, CancellationToken cancellationToken)
        {
            var productCatalogId = await _productCatalogRepository.CreateProductCatalogAsync(request, cancellationToken);

            await _mediator.Publish(new ProductCatalogCreated() { ProductCategoryId = productCatalogId }, cancellationToken);

            return productCatalogId;
        }
    }
}
